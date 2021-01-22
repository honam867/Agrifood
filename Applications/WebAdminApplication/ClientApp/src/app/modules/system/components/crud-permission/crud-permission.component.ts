import { MatDialog } from '@angular/material/dialog';
import { ConfirmationComponent } from './../../../../shared/components/confirmation/confirmation.component';
import { Notification } from './../../../../shared/components/notification/notification';
import { PermissionGroupService } from './../../services/permission-group.service';
import { StatusForm } from './../../../../shared/enum/status-form';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from './../../../user/user.service';
import { SelectionModel } from '@angular/cdk/collections';
import { User } from './../../../user/models/user';
import { MatTableDataSource } from '@angular/material/table';
import { PermissionGroupDetail } from './../../models/permission-group-detail';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-crud-permission',
  templateUrl: './crud-permission.component.html',
  styleUrls: ['./crud-permission.component.scss']
})
export class CrudPermissionComponent implements OnInit {
  showLoading: boolean;
  sourceView: PermissionGroupDetail = new PermissionGroupDetail();
  source: PermissionGroupDetail = new PermissionGroupDetail();
  dataSource: any;
  userLoaded = false;
  selection = new SelectionModel<User>(true, []);
  displayedColumns: string[] = ['select', 'userName', 'email', 'phoneNumber'];
  users: User[] = [];
  isCreate: boolean;
  isView: boolean;
  isEdit: boolean;
  constructor(
    private userService: UserService,
    protected route: ActivatedRoute,
    private service: PermissionGroupService,
    private router: Router,
    private notification: Notification,
    protected dialog: MatDialog,
  ) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(
      queryParams => {
        this.isView = queryParams.action.toUpperCase() === StatusForm[StatusForm.VIEW];
        this.isCreate = queryParams.action.toUpperCase() === StatusForm[StatusForm.CREATE];
        this.isEdit = queryParams.action.toUpperCase() === StatusForm[StatusForm.EDIT];
      }
    );
    this.route.params.subscribe(
      params => {
        if (params.id > 0) {
          this.sourceView.id = params.id;
          this.service.get(this.sourceView.id).subscribe(
            result => {
              this.source = result;
              this.sourceView = Object.assign({}, this.source);
              console.log(this.sourceView);
              this.fetchUsers();
            }
          );
        }
      }
    );
    if (this.isCreate) {
      this.fetchUsers();
    }
  }

  fetchUsers() {
    this.userService.getUsers().subscribe(
      result => {
        this.users = result;
        this.dataSource = new MatTableDataSource<User>(this.users);
        this.userLoaded = true;
        if (!this.isCreate) {
          this.selection.clear();
          this.sourceView.users.forEach(
            userId => {
              const user = this.users.find((u) => u.id === userId);
              this.selection.toggle(user);
            }
          );
        }
      }
    );
  }

  addToUserList(selection) {
    return this.sourceView.users = selection.map(item => item.id)
  }

  create() {
    this.showLoading = true;
    this.addToUserList(this.selection.selected);
    this.service.post(this.sourceView).subscribe(
      result => {
        this.notification.MessageCreated();
        this.showLoading = false;
        this.router.navigate(['system/permissionlist']);
      }
    );
  }

  save() {
    this.showLoading = true;
    this.addToUserList(this.selection.selected);
    console.log(this.sourceView);
    this.service.put(this.sourceView).subscribe(
      result => {
        if (result) {
          this.notification.MessageUpdated();
          this.showLoading = false;
          this.isView = true;
        }
      }
    );
  }

  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected() ?
      this.selection.clear() :
      this.dataSource.data.forEach(row => this.selection.select(row));
  }

  /** The label for the checkbox on the passed row */
  checkboxLabel(row?: User): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.id + 1}`;
  }

  delete(deleteId: number) {
    const deleteDialog = this.dialog.open(ConfirmationComponent, {
      data: {
        message: 'Toàn bộ dữ liệu của bạn sẽ bị mất. Bạn có muốn xóa?'
      },
      disableClose: true
    });
    deleteDialog.afterClosed().subscribe(result => {
      if (result.confirmed) {
        this.service.delete(deleteId).subscribe(
          deleteResult => {
            if (deleteResult.value) {
              this.router.navigate(['system/permissionlist']);
            }
          }
        );
      }
    });
  }


}
