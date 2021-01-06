import { RoleOfUser } from './../../models/roleofuser';
import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { StatusForm } from 'src/app/shared/enum/status-form';
import { SelectionModel } from '@angular/cdk/collections';
import { Notification } from './../../../../shared/components/notification/notification';
import {
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialog
} from '@angular/material/dialog';
import { UserService } from './../../user.service';
import { FormBuilder, FormGroup, FormArray, FormControl, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Role } from '../../models/role';
import { RqListRole } from '../../models/RqListRoles';
@Component({
  selector: 'app-crud-roles-user',
  templateUrl: './crud-roles-user.component.html',
  styleUrls: ['./crud-roles-user.component.scss']
})

export class CrudRolesUserComponent implements OnInit {
  displayedColumns: string[] = [
    'select',
    'name',
  ];
  form: FormGroup;
  isView = true;
  isCreate = true;
  name = [];
  roles: Role[] = [];
  RolesSelected: Role[] = [];
  sourceView: RoleOfUser = new RoleOfUser();
  roleOfUser: RoleOfUser = new RoleOfUser();
  dataSource: MatTableDataSource<Role>;
  selection = new SelectionModel<Role>(true, []);
  rqListRoles: RqListRole = new RqListRole();
  loaded = false;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  constructor(
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<CrudRolesUserComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private userService: UserService,
    private snackBar: MatSnackBar,
    private notification: Notification
  ) {

  }

  ngOnInit() {
    this.roleOfUser = this.data.roleOfUser;
    this.isView = this.data.action === StatusForm.VIEW;
    this.isCreate = this.data.action === StatusForm.CREATE;
    this.sourceView = Object.assign({}, this.roleOfUser);
    this.fetchRoleNotExist();
  }

  fetchRoleNotExist() {
    this.userService.getRoleNotExist(this.sourceView.userId).subscribe(
      res => {
        this.roles = res;
        this.dataSource = new MatTableDataSource<Role>(this.roles);
        this.dataSource.paginator = this.paginator;
        this.loaded = true;
      }, error => {
        if (error.error.message === 'You need the role of Admin or SysAdmin to perform this action.') {
          this.notification.showNotification('danger', 'top', 'center', "Bạn phải có vai trò là Admin hoặc Sysadmin để thực hiện.")
        }
      });
  }

  edit() {
    this.isView = false;
  }

  close() {
    this.dialogRef.close({
      action: StatusForm.VIEW,
      data: this.roleOfUser
    });
  }

  create() {
    this.rqListRoles.roles = this.selection.selected;
    this.rqListRoles.userId = this.sourceView.userId;
    this.userService.addRolesOfUser(this.rqListRoles).subscribe(
      result => {
        if (result.value) {
          this.dialogRef.close({
            data: result,
          });
          this.notification.openSnackBar('Đã thêm !', 'Tắt');
        }

      }
      , error => {
        if (error.error.message === 'Code Exists') {
          // this.CreateCus = false;
        }
      });
  }

  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  masterToggle() {
    this.isAllSelected() ?
      this.selection.clear() :
      this.dataSource.data.forEach(role => this.selection.select(role));
  }

  checkboxLabel(row?: Role): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.id + 1}`;
  }

}
