import { Farmer } from './../../../farmer/models/farmer';
import { FarmerService } from './../../../farmer/farmer.service';
import { ConfirmationComponent } from './../../../../shared/components/confirmation/confirmation.component';
import { UserService } from './../../user.service';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Component, OnInit, ViewChild, Inject, Input } from '@angular/core';
import { StatusForm } from 'src/app/shared/enum/status-form';
import { CRUDUserComponent } from '../../components/cruduser/cruduser.component';
import { User } from '../../models/user';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { map } from 'jquery';
import { reduce } from 'rxjs/operators';
@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  @Input() fromFarmerList: boolean;
  @Input() farmer: Farmer;
  page = 1;
  showLoad = false;
  displayedColumns: string[] = ['userName', 'email', 'phoneNumber', 'role', 'status', 'action'];
  dataSource: MatTableDataSource<User>;
  users: User[] = [];
  user2s: User[] = [];
  farmers: Farmer[] = [];
  filterUsedUserId = [];
  isUserList = true;
  isAddUser = false;
  list: any;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(
    public dialog: MatDialog,
    public userService: UserService,
    public farmerService: FarmerService,
  ) { }

  ngOnInit(): void {

    // this.isAddUser = this.data.action === StatusForm.EDIT; //2
    if (this.fromFarmerList) {
      this.fetchUsers();
      this.fetchUsedUserId();
    } else {
      this.fetchUsers();
    }
  }

  edit() {
    this.isAddUser = true; //3
  }

  // NOTE comment 3 dong 123 la user list chay lại bình thường

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

  fetchUsers() {
    this.userService.getUsers().subscribe(
      res => {
        this.users = res;
        if (!this.fromFarmerList) {
          this.dataSource = new MatTableDataSource(this.users);
          this.dataSource.paginator = this.paginator;
          this.dataSource.sort = this.sort;
        }
      });
  }

  fetchUsedUserId() {
    this.farmerService.getFarmers().subscribe(
      res => {
        this.farmers = res;

        for (let index = 0; index < this.farmers.length; index++) {
          if (this.farmers[index].hasOwnProperty('userId')) {
            this.filterUsedUserId.push(this.farmers[index].userId);
          }
        }
        // console.log(this.filterUsedUserId);
        const result = this.filterUsedUserId.map((item, index) => (

          {
            id: this.filterUsedUserId[index],
          }
        )
        )
        //     console.log(result);
        // for (var i = this.users.length - 1; i >= 0; i--) {
        //   for (var j = 0; j < result.length; j++) {
        //     if (this.users[i].id === result[j].id) {
        //       this.users.splice(i, 1);
        //       }
        //     }
        //   }
        this.users.map((user, indexUser) => result.map((result1, indexResult) => {
              if (this.users[indexUser].id === result[indexResult].id) {
                this.users.splice(indexUser, 1)
                this.dataSource = new MatTableDataSource(this.users);
                this.dataSource.paginator = this.paginator;
                this.dataSource.sort = this.sort;
              }
            }
          )
        )
        console.log(this.users);
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
    if (!this.fromFarmerList) {
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
    } else{
      const confirmEditDialog = this.dialog.open(ConfirmationComponent, {
        data: {
          message: 'Bạn có muốn gán hộ nông dân cho tài khoản này ?',
        },
        disableClose: true,
      });

      confirmEditDialog.afterClosed().subscribe(
        result => {
          if (result.confirmed) {
            this.farmer.userId = user.id
            this.farmerService.updateFarmer(this.farmer.id, this.farmer).subscribe(
              result =>{
                console.log(result);
              }
            );
          }
        }
      );
    }
    }



}
