import { ConfirmationComponent } from './../../../../shared/components/confirmation/confirmation.component';
import { UserService } from './../../user.service';
import { MatDialog } from '@angular/material/dialog';
import { Component, OnInit, ViewChild } from '@angular/core';
import { StatusForm } from 'src/app/shared/enum/status-form';
import { CRUDUserComponent } from '../../components/cruduser/cruduser.component';
import { User } from '../../models/user';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {

  page = 1;
  showLoad = false;
  displayedColumns: string[] = ['userName', 'email', 'phoneNumber', 'role', 'status', 'action'];
  dataSource: MatTableDataSource<User>;
  users: User[] = [];

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(
    public dialog: MatDialog,
    public userService: UserService
  ) { }

  ngOnInit(): void {
    this.fetchUsers();
  }
  createUser() {
    const createDialog = this.dialog.open(CRUDUserComponent, {
      height: '75%',
      width: '80%',
      data: {
        action: StatusForm.CREATE,
        user: new User(),
      },
      disableClose: true,
    });

    createDialog.afterClosed().subscribe(
      result => {
        this.userService.getUserById(result.data).subscribe(
          createdUser => {
            if (createdUser !== null) {
              this.users.push(createdUser);
              this.dataSource.data = this.users;
            }
          }
        );
      }
    );
  }

  // fetchUsers() {
  //     this.userService.getUsers().subscribe(result => {
  //       console.log(result);
  //     })
  // }

  fetchUsers() {
    this.userService.getUsers().subscribe(
      res => {
        this.users = res;
        this.dataSource = new MatTableDataSource(this.users);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  editUser(user: User) {
    const editDialog = this.dialog.open(CRUDUserComponent, {
      width: '80%',
      data: {
        action: StatusForm.EDIT,
        user,
      },
      disableClose: true,
    });

    editDialog.afterClosed().subscribe(
      result => {
        this.afterClose(result);
      }
    );
  }
  afterClose(result: any) {
    const user = result.data;
    if (result.action === StatusForm.VIEW) {
      const userIndex = this.users.map(p => p.id).indexOf(user.id);
      this.users[userIndex] = user;
      this.dataSource.data = this.users;
    } else if (result.action === StatusForm.DETELE) {
      const userIndex = this.users.indexOf(user);
      if (userIndex !== -1) {
        this.users.splice(userIndex, 1);
        this.dataSource.data = this.users;
      }
    }
  }
  deleteUser(user: User) {
    const deleteDialog = this.dialog.open(ConfirmationComponent, {
      data: {
        message: 'Bạn có muốn xóa?',
      },
      disableClose: true,
    });

    deleteDialog.afterClosed().subscribe(
      result => {
        if (result.confirmed) {
          this.userService.deleteUser(user.id).subscribe(
            success => {
              const userIndex = this.users.indexOf(user);
              if (userIndex !== -1) {
                this.users.splice(userIndex, 1);
                this.dataSource.data = this.users;
              }
            }
          );
        }
      }
    );
  }

  viewDetail(user: User) {
    const viewDialog = this.dialog.open(CRUDUserComponent, {
      height: '75%',
      width: '80%',
      data: {
        action: StatusForm.VIEW,
        user,
      },
      disableClose: true,
    });

    viewDialog.afterClosed().subscribe(
      result => {
        this.afterClose(result);
      }
    );
  }


}
