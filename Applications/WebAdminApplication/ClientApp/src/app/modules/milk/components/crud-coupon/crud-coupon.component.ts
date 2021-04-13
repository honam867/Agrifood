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

@Component({
  selector: 'app-crud-coupon',
  templateUrl: './crud-coupon.component.html',
  styleUrls: ['./crud-coupon.component.scss']
})

export class CrudCouponComponent implements OnInit {
  page = 1;
  displayedColumns: string[] = [
    'name',
    'action'];
  status: string;
  coupon: Coupon = new Coupon();
  // provinces: Province[] = [];
  isView = true;
  isCreate = true;
  loading: boolean;
  detailsOfCoupon: any[];
  dataSource: MatTableDataSource<Detail>;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
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
  //       // this.dataSource = new MatTableDataSource(this.foods);
  //       // this.dataSource.paginator = this.paginator;
  //       // this.dataSource.sort = this.sort;
  //     });
  // }

  fetchDetailInCoupon() {
    this.couponService.getDetailByCouponId(this.sourceView.id).subscribe(res => {
      this.detailsOfCoupon = res;
      this.dataSource = new MatTableDataSource(this.detailsOfCoupon);
      this.dataSource.paginator = this.paginator;
    });
  }

  popUpAddMilkCouponDetail() {
    const createDialog = this.dialog.open(CrudDetailComponent, {
      height: '80%',
      width: '60%',
      data: {
        action: StatusForm.CREATE,
        detailOfCoupon: new DetailOfCoupon(this.coupon.id),
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


}

