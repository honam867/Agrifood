import { Coupon } from './../../models/coupon';
import { CrudCouponComponent } from './../../components/crud-coupon/crud-coupon.component';
import { StatusForm } from 'src/app/shared/enum/status-form';
import { MilkService } from './../../milk.service';
import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-coupon',
  templateUrl: './coupon.component.html',
  styleUrls: ['./coupon.component.scss']
})
export class CouponComponent implements OnInit {
  value = '';
  page = 1;
  showLoad = false;
  displayedColumns: string[] = ['farmer', 'scaleCode', 'employee'];
  dataSource: MatTableDataSource<Coupon>;
  coupons: Coupon[] = [];
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(
    public dialog: MatDialog,
    public couponService: MilkService
  ) { }

  ngOnInit(): void {
    this.fetchCoupons();
  }
  afterClose(result: any) {
    const coupon = result.data;
    if (result.action === StatusForm.VIEW) {
      const employeeIndex = this.coupons.map(p => p.id).indexOf(coupon.id);
      this.coupons[employeeIndex] = coupon;
      this.dataSource.data = this.coupons;
    } else if (result.action === StatusForm.DETELE) {
      const employeeIndex = this.coupons.indexOf(coupon);
      if (employeeIndex !== -1) {
        this.coupons.splice(employeeIndex, 1);
        this.dataSource.data = this.coupons;
      }
    }
  }

  viewDetail(coupon: Coupon) {
    const viewDialog = this.dialog.open(CrudCouponComponent, {
      height: '75%',
      width: '80%',
      data: {
        action: StatusForm.VIEW,
        coupon,
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

  fetchCoupons() {
    this.couponService.getCoupons().subscribe(
      res => {
        this.coupons = res;
        this.dataSource = new MatTableDataSource(this.coupons);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
  }

  createCoupon() {
    const createDialog = this.dialog.open(CrudCouponComponent, {
      height: '75%',
      width: '80%',
      data: {
        action: StatusForm.CREATE,
        coupon: new Coupon(),
      },
      disableClose: true,
    });

    createDialog.afterClosed().subscribe(
      result => {
        this.couponService.getCouponById(result.data).subscribe(
          createdProvince => {
            if (createdProvince !== null) {
              this.coupons.push(createdProvince);
              this.dataSource.data = this.coupons;
            }
          }
        );
      }
    );
  }


}

