import { AddFarmerToUserComponent } from './../../../user/components/add-farmer-to-user/add-farmer-to-user.component';
import { User } from './../../../user/models/user';
import { UserListComponent } from './../../../user/pages/user-list/user-list.component';
import { ConfirmationComponent } from 'src/app/shared/components/confirmation/confirmation.component';
import { StatusForm } from './../../../../shared/enum/status-form';
import { CrudFarmerComponent } from './../../components/crud-farmer/crud-farmer.component';
import { FarmerService } from './../../farmer.service';
import { Farmer } from './../../models/farmer';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-farmer-list',
  templateUrl: './farmer-list.component.html',
  styleUrls: ['./farmer-list.component.scss']
})
export class FarmerListComponent implements OnInit {

  page = 1;
  showLoad = false;
  displayedColumns: string[] = ['name', 'address', 'phoneNumber', 'createDate', 'isBlock', 'action'];
  dataSource: MatTableDataSource<Farmer>;
  farmers: Farmer[] = [];
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(
    public dialog: MatDialog,
    public farmerService: FarmerService
  ) { }

  ngOnInit(): void {
    this.fetchUsers();
  }

  createFarmer() {
    const createDialog = this.dialog.open(CrudFarmerComponent, {
      height: '75%',
      width: '80%',
      data: {
        action: StatusForm.CREATE,
        farmer: new Farmer(),
      },
      disableClose: true,
    });

    createDialog.afterClosed().subscribe(
      result => {
        this.farmerService.getFarmerById(result.data).subscribe(
          createdFarmer => {
            if (createdFarmer !== null) {
              this.farmers.push(createdFarmer);
              this.dataSource.data = this.farmers;
            }
          }
        );
      }
    );
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  afterClose(result: any) {
    const user = result.data;
    if (result.action === StatusForm.VIEW) {
      const userIndex = this.farmers.map(p => p.id).indexOf(user.id);
      this.farmers[userIndex] = user;
      this.dataSource.data = this.farmers;
    } else if (result.action === StatusForm.DETELE) {
      const userIndex = this.farmers.indexOf(user);
      if (userIndex !== -1) {
        this.farmers.splice(userIndex, 1);
        this.dataSource.data = this.farmers;
      }
    }
  }

  addUser(farmer: Farmer) {
    const addUserDialog = this.dialog.open(AddFarmerToUserComponent, {
      width: '80%',
      data: {
        fromFarmerList: true,
        farmer
      },
      disableClose: true,
    });

    addUserDialog.afterClosed().subscribe(
      result => {
        this.afterClose(result);
      }
    );
  }

  editFarmer(farmer: Farmer) {
    const editDialog = this.dialog.open(CrudFarmerComponent, {
      width: '80%',
      data: {
        action: StatusForm.EDIT,
        farmer,
      },
      disableClose: true,
    });

    editDialog.afterClosed().subscribe(
      result => {
        this.afterClose(result);
      }
    );
  }

  viewDetail(farmer: Farmer) {
    const viewDialog = this.dialog.open(CrudFarmerComponent, {
      height: '75%',
      width: '80%',
      data: {
        action: StatusForm.VIEW,
        farmer,
      },
      disableClose: true,
    });

    viewDialog.afterClosed().subscribe(
      result => {
        this.afterClose(result);
      }
    );
  }

  deleteFarmer(farmer: Farmer) {
    const deleteDialog = this.dialog.open(ConfirmationComponent, {
      data: {
        message: 'Bạn có muốn xóa?',
      },
      disableClose: true,
    });

    deleteDialog.afterClosed().subscribe(
      result => {
        if (result.confirmed) {
          this.farmerService.deleteFarmer(farmer.id).subscribe(
            success => {
              const userIndex = this.farmers.indexOf(farmer);
              if (userIndex !== -1) {
                this.farmers.splice(userIndex, 1);
                this.dataSource.data = this.farmers;
              }
            }
          );
        }
      }
    );
  }

  fetchUsers() {
    this.farmerService.getFarmers().subscribe(
      res => {
        this.farmers = res;
        this.dataSource = new MatTableDataSource(this.farmers);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
  }

  // fetchUsedUserId() {
  //   this.farmerService.getFarmers().subscribe(
  //     res => {
  //       this.farmers = res;
  //       let filterUsedUserId =[];
  //       for (let index = 0; index < this.farmers.length; index++) {
  //         if (this.farmers[index].hasOwnProperty('userId')) {
  //           filterUsedUserId.push(this.farmers[index].userId);
  //         }
  //       }
  //       console.log(filterUsedUserId);
  //     });
  // }

}
