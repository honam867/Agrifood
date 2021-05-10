import { MatSort } from '@angular/material/sort';
import { DetailOfCoupon } from './../../models/detailOfCoupon';
import { ConfirmationComponent } from 'src/app/shared/components/confirmation/confirmation.component';
import { StatusForm } from 'src/app/shared/enum/status-form';
import { MilkService } from './../../milk.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { Coupon } from '../../models/coupon';
import { Detail } from '../../models/detail';
import { MatTableDataSource } from '@angular/material/table';
import { CrudDetailComponent } from '../crud-detail/crud-detail.component';
import { Employee } from 'src/app/modules/employee/models/employee';
import { Farmer } from 'src/app/modules/farmer/models/farmer';
import { Station } from 'src/app/modules/station/models/station';
import { StorageTank } from '../../models/storage';

@Component({
  selector: 'app-crud-coupon',
  templateUrl: './crud-coupon.component.html',
  styleUrls: ['./crud-coupon.component.scss']
})

export class CrudCouponComponent implements OnInit {
  page = 1;
  displayedColumns: string[] = [
    'quantity','typeMilk', 'action'];
  status: string;
  coupon: Coupon = new Coupon();
  // provinces: Province[] = [];
  employees: Employee[] =[];
  farmers: Farmer[] = [];
  milkStations: Station[] = [];
  storageTanks: StorageTank[] = [];
  isView = true;
  isCreate = true;
  loading: boolean;
  detailsOfCoupon: any[];
  detailId: any;
  dataSource: MatTableDataSource<Detail>;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  sourceView: Coupon = new Coupon();
  constructor(
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<CrudCouponComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public couponService: MilkService

  ) { }


  ngOnInit(): void {
    // this.fetchProvinces();
    this.coupon = this.data.coupon;
    if (this.data.action === StatusForm.DETELE) {
      this.delete();
    }
    this.fetchDetailInCoupon();
    this.fetchEmployees();
    this.fetchFarmers();
    this.fetchStations();

    if (this.isView) {
      this.getStorageTanks(this.coupon.milkCollectionStationId);
    }
    // this.getStorageTanks();
    this.isView = this.data.action === StatusForm.VIEW;
    this.isCreate = this.data.action === StatusForm.CREATE;
    this.sourceView = Object.assign({}, this.coupon);
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
          this.couponService.deleteCoupon(this.coupon.id).subscribe(
            success => {
              this.dialogRef.close({
                action: StatusForm.DETELE,
                data: this.coupon,
              });
            }
          );
        }
      }
    );
  }


  create() {
    this.couponService.createCoupon(this.sourceView).subscribe(
      result => {
        this.dialogRef.close({
          data: result,
        });
      }
    );
  }
  close() {
    this.dialogRef.close({
      action: StatusForm.VIEW,
      data: this.coupon,
    });
  }

  edit() {
    this.isView = false;
  }

  discard() {
    this.isView = true;
    this.sourceView = this.coupon;
  }

  save() {
    this.loading = true;
    this.couponService.updateCoupon(this.coupon.id, this.sourceView).subscribe(
      result => {
        this.isView = true;
        this.loading = false;
        this.coupon = this.sourceView;
      }
    );
  }

  // fetchProvinces() {
  //   this.foodService.getProvinces().subscribe(
  //     res => {
  //       this.provinces = res;
  //       // this.dataSource = new MatTableDataSource(this.foods );
  //       // this.dataSource.paginator = this.paginator;
  //       // this.dataSource.sort = this.sort;
  //     });
  // }

  fetchDetailInCoupon() {
    this.couponService.getDetailByCouponId(this.coupon.id).subscribe(res => {
      this.detailsOfCoupon = res;
      this.dataSource = new MatTableDataSource(this.detailsOfCoupon);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  fetchEmployees() {
    this.couponService.getEmployees().subscribe(result => {
      this.employees = result;
    });
  }

  fetchFarmers() {
    this.couponService.getFarmers().subscribe(result => {
      this.farmers = result;
    });
  }

  fetchStations() {
    this.couponService.getStations().subscribe(result => {
      this.milkStations = result;
    });
  }

  getStorageTanks(milkCollectionStationId: number) {
    this.couponService.getTanks().subscribe(result => {
      this.storageTanks = result.filter(tank => tank.milkCollectionStationId == milkCollectionStationId);
      console.log(this.storageTanks);
    });
  }

  popUpAddMilkCouponDetail() {
    const createDialog = this.dialog.open(CrudDetailComponent, {
      height: '80%',
      width: '60%',
      data: {
        action: StatusForm.CREATE,
        couponId : this.coupon.id
      },
      disableClose: true,
    });
    createDialog.afterClosed().subscribe(
      result => {
        if (result.data) { // result => data:true
          this.fetchDetailInCoupon();
        }
      }
    );
  }

  deleteDetailOfCoupon(detailOfCoupon: DetailOfCoupon) {
    this.detailId = detailOfCoupon.id;
    const deleteDialog = this.dialog.open(ConfirmationComponent, {
      data: {
        message: 'Bạn có muốn xóa?',
      },
      disableClose: true,
    });
    deleteDialog.afterClosed().subscribe(
      result => {
        if (result.confirmed) {
          this.couponService.deleteCouponDetail(this.detailId).subscribe(
            success => {
              this.fetchDetailInCoupon();
            })
        }
      }
    );
  }


}

