import { CrudCowComponent } from './../../components/crud-cow/crud-cow.component';
import { StatusForm } from 'src/app/shared/enum/status-form';
import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Cow } from 'src/app/modules/farmer/models/cow';
import { CowService } from '../../cow-service';

@Component({
  selector: 'app-cow-list',
  templateUrl: './cow-list.component.html',
  styleUrls: ['./cow-list.component.scss']
})

export class CowListComponent implements OnInit {
  value = '';
  page = 1;
  showLoad = false;
  displayedColumns: string[] = ['name', 'gender', 'byreId'];
  dataSource: MatTableDataSource<Cow>;
  cows: Cow[] = [];
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(
    public dialog: MatDialog,
    public cowService: CowService
  ) { }

  ngOnInit(): void {
    this.fetchCows();
  }
  afterClose(result: any) {
    const cow = result.data;
    if (result.action === StatusForm.VIEW) {
      const employeeIndex = this.cows.map(p => p.id).indexOf(cow.id);
      this.cows[employeeIndex] = cow;
      this.dataSource.data = this.cows;
    } else if (result.action === StatusForm.DETELE) {
      const employeeIndex = this.cows.indexOf(cow);
      if (employeeIndex !== -1) {
        this.cows.splice(employeeIndex, 1);
        this.dataSource.data = this.cows;
      }
    }
  }

  viewDetail(cow: Cow) {
    const viewDialog = this.dialog.open(CrudCowComponent, {
      height: '75%',
      width: '80%',
      data: {
        action: StatusForm.VIEW,
        cow,
      },
      disableClose: true,
    });
    viewDialog.afterClosed().subscribe(
      result => {
        this.afterClose(result);
      }
    );
  }


  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  fetchCows() {
    this.cowService.getCows().subscribe(
      res => {
        this.cows = res;
        this.dataSource = new MatTableDataSource(this.cows);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
  }

  // createCoupon() {
  //   const createDialog = this.dialog.open(CrudCowComponent, {
  //     height: '75%',
  //     width: '80%',
  //     data: {
  //       action: StatusForm.CREATE,
  //       cow: new Cow(),
  //     },
  //     disableClose: true,
  //   });

  //   createDialog.afterClosed().subscribe(
  //     result => {
  //       this.couponService.getCouponById(result.data).subscribe(
  //         createdProvince => {
  //           if (createdProvince !== null) {
  //             this.coupons.push(createdProvince);
  //             this.dataSource.data = this.coupons;
  //           }
  //         }
  //       );
  //     }
  //   );
  // }


}
