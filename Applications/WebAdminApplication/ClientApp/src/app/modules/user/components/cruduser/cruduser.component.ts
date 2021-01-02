import { Notification } from './../../../../shared/components/notification/notification';
import { ValueObject } from './../../../../shared/models/value-object';
import { UserService } from './../../user.service';
import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef, MatDialog } from '@angular/material/dialog';
import { User } from '../../models/user';
import { StatusForm } from 'src/app/shared/enum/status-form';
// import { Role } from 'src/app/modules/system/models/role';
// import { RoleOfUser } from './../../models/roleofUser';
// import { RoleService } from 'src/app/modules/system/components/role/role.service';
import { ConfirmationComponent } from 'src/app/shared/components/confirmation/confirmation.component';
// import { SystemService } from '../../../system/system.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { RoleService } from '../../role.service';
import { Role } from '../../models/role';
import { CrudRolesUserComponent } from '../crud-roles-user/crud-roles-user.component';
import { RoleOfUser } from '../../models/roleofuser';
// import { CrudRolesUserComponent } from '../../components/crud-roles-user/crud-roles-user.component';

@Component({
  selector: 'app-cruduser',
  templateUrl: './cruduser.component.html',
  styleUrls: ['./cruduser.component.scss']
})

export class CRUDUserComponent implements OnInit {
  page = 1;
  displayedColumns: string[] = [
    'name',
    'action'];
  status: string;
  user: User = new User();
  isView = true;
  isCreate = true;
  roles: Role[] = [];
  // roleOfUsers: RoleOfUser[] = [];
  rolesOfUser: any[];
  removeRole: any = {
    userId: 0,
    roleName: '',
  };
  // dataSource: MatTableDataSource<Role>;
  dataSource: MatTableDataSource<Role>;
  emailExist: boolean;
  valueObject: ValueObject = new ValueObject();
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  sourceView: User = new User();
  loading: boolean;
  constructor(
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<CRUDUserComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public userService: UserService,
    public roleService: RoleService,
    private notification: Notification

  ) { }


  ngOnInit() {
    this.user = this.data.user;
    if (this.data.action === StatusForm.DETELE) {
      this.delete();
    }
    this.isView = this.data.action === StatusForm.VIEW;
    this.isCreate = this.data.action === StatusForm.CREATE;
    this.sourceView = Object.assign({}, this.user);
    if (this.isView) {
      this.fetchRoleinUser();
    }
    this.fetchRoles();
  }

  fetchRoles() {
    this.roleService.getRoles().subscribe(result => {
      this.roles = result;
    })
  }

  // get role of user
  fetchRoleinUser() {
    this.userService.getRoleByUser(this.sourceView.id).subscribe(res => {
      this.rolesOfUser = res;
      this.dataSource = new MatTableDataSource(this.rolesOfUser);
      this.dataSource.paginator = this.paginator;
    });
  }

  edit() {
    this.isView = false;
  }

  discard() {
    this.isView = true;
    this.sourceView = this.user;
  }

  save() {
    this.loading = true;
    this.userService.updateUser(this.user.id, this.sourceView).subscribe(
      result => {
        this.isView = true;
        this.loading = false;
        this.user = this.sourceView;
      }
    );
  }

  delete() {
    const deleteDialog = this.dialog.open(ConfirmationComponent, {
      data: {
        message: 'Bạn có muốn xóa?',
      },
      disableClose: true,
    });

    deleteDialog.afterClosed().subscribe(
      result => {
        if (result.confirmed) {
          this.userService.deleteUser(this.user.id).subscribe(
            success => {
              this.dialogRef.close({
                action: StatusForm.DETELE,
                data: this.user,
              });
            }, (error) => {
              if (error.error.message === 'An error occurred while updating the entries. See the inner exception for details.') {
                this.notification.showNotification('danger', 'top', 'center', `UserName: ${this.user.userName} và Mã User: ${this.user.id} đã được sử dụng cho một trường dữ liệu khác !
                Xin hãy xóa dữ liệu đã được sử dụng trước.
                `)
              }
            }
          );
        }
      }
    );
  }

  close() {
    this.dialogRef.close({
      action: StatusForm.VIEW,
      data: this.sourceView,
    });
  }

  create() {
    this.loading = true;
    this.userService.createUser(this.sourceView).subscribe(
      result => {
        this.sourceView.id = result;
        this.loading = true;
        this.dialogRef.close({
          data: this.sourceView,
        });
      }, error => {
        this.loading = false;
      }
    );
  }

  getNameofRole() {
    // this.rolesOfUser;
  }

  popUpCrudAddRoles() {
    const createDialog = this.dialog.open(CrudRolesUserComponent, {
      height: '80%',
      width: '60%',
      data: {
        action: StatusForm.CREATE,
        roleOfUser: new RoleOfUser(this.user.id),
      },
      disableClose: true,
    });
    createDialog.afterClosed().subscribe(
      result => {
        if (result.data) { // result => data:true 
          this.fetchRoleinUser();
        }
      }
    );
  }

  deleteRolesOfUser(roleofUser: RoleOfUser) {
    const deleteDialog = this.dialog.open(ConfirmationComponent, {
      data: {
        message: 'Bạn có muốn xóa?',
      },
      disableClose: true,
    });
    this.removeRole.userId = this.sourceView.id;
    this.removeRole.roleName = roleofUser; // => roleName
    deleteDialog.afterClosed().subscribe(
      result => {
        if (result.confirmed) {
          this.userService.deleteRoleOfUser(this.sourceView.id, this.removeRole.roleName).subscribe(
            success => {
              this.fetchRoleinUser();
            })
        }
      }
    );
  }

  checkEmail(email) {
    if (email !== '') {
      this.userService.checkEmailExist(email).subscribe(result => {
        this.valueObject = result;
        if (this.valueObject.value) {
          this.emailExist = true;
        }
      })
    } else {
      this.emailExist = false;
    }
  }
}
