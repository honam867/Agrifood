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
import {MatPaginator} from '@angular/material/paginator';
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
  // roles: Role[] = [];
  // roleOfUsers: RoleOfUser[] = [];
  rolesOfUser: any[];
  removeRole: any = {
    userId: 0,
    roleName: '',
  };
  // dataSource: MatTableDataSource<Role>;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  sourceView: User = new User();
  constructor(
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<CRUDUserComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public userService: UserService
    // private roleService: RoleService,
    // private systemService: SystemService,
  ) { }


  ngOnInit() {
    this.user = this.data.user;
    if (this.data.action === StatusForm.DETELE) {
      this.delete();
    }
    this.isView = this.data.action === StatusForm.VIEW;
    this.isCreate = this.data.action === StatusForm.CREATE;
    this.sourceView = Object.assign({}, this.user);
    // this.roleService.getRoles().subscribe(
    //   result => {
    //     this.roles = result;
    //   }
    // );
    // this.fetchRoleinUser();
  }

  edit() {
    this.isView = false;
  }

  discard() {
    this.isView = true;
    this.sourceView = this.user;
  }

  save() {
    this.userService.updateUser(this.user.id, this.sourceView).subscribe(
      result => {
        this.isView = true;
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
            }
          );
        }
      }
    );
  }

  close() {
    this.dialogRef.close({
      action: StatusForm.VIEW,
      data: this.user,
    });
  }

  create() {
    this.userService.createUser(this.sourceView).subscribe(
      result => {
        this.dialogRef.close({
          data: result,
        });
      }
    );
  }
  // create() {
  //   // this.userService.createUser(this.sourceView).subscribe(
  //   //   result => {
  //   //     this.dialogRef.close({
  //   //       data: result,
  //   //     });
  //   //   }
  //   // );
  //   console.log(this.sourceView);
  //   const data = {
  //     email: ''
  //   }
  //   data.email = this.sourceView.email;
  //   console.log(data);

  //   // console.log(this.data.user);

  // }

  // get role of user
  // fetchRoleinUser() {
  //   this.userService.getRoleByUser(this.sourceView.id).subscribe(res => {
  //     this.rolesOfUser = res;
  //     this.dataSource = new MatTableDataSource(this.rolesOfUser);
  //     this.dataSource.paginator = this.paginator;
  //   });
  // }
  getNameofRole() {
    // this.rolesOfUser;
  }

  // popUpCrudAddRoles() {
  //   const createDialog = this.dialog.open(CrudRolesUserComponent, {
  //     height: '80%',
  //     width: '60%',
  //     data: {
  //       action: StatusForm.CREATE,
  //       roleOfUser: new RoleOfUser(this.user.id),
  //     },
  //     disableClose: true,
  //   });
  //   createDialog.afterClosed().subscribe(
  //     result => {
  //       if (result.data) { // result => data:true
  //         this.fetchRoleinUser();
  //       }
  //     }
  //   );
  // }

//   deleteRolesOfUser(roleofUser: RoleOfUser) {
//     const deleteDialog = this.dialog.open(ConfirmationComponent, {
//       data: {
//         message: 'Bạn có muốn xóa?',
//       },
//       disableClose: true,
//     });
//     this.removeRole.userId = this.sourceView.id;
//     this.removeRole.roleName = roleofUser; // => roleName
//     deleteDialog.afterClosed().subscribe(
//       result => {
//         if (result.confirmed) {

//           this.userService.deleteRoleOfUser(this.sourceView.id, this.removeRole.roleName).subscribe(
//             success => {
//               this.fetchRoleinUser();
//             }
//           );
//         }
//       }
//     );
//   }
}
