import { StatusForm } from 'src/app/shared/enum/status-form';
import { CowService } from './../../cow-service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { Cow } from '../../models/cow';


@Component({
  selector: 'app-crud-cow',
  templateUrl: './crud-cow.component.html',
  styleUrls: ['./crud-cow.component.scss']
})

export class CrudCowComponent implements OnInit {
  page = 1;
  displayedColumns: string[] = [
    'name',
    'action'];
  status: string;
  cow: Cow = new Cow();
  // provinces: Province[] = [];
  isView = true;
  isCreate = true;
  loading: boolean;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  sourceView: Cow = new Cow();
  constructor(
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<CrudCowComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public cowService: CowService

  ) { }


  ngOnInit(): void {
    // this.fetchProvinces();
    this.cow = this.data.cow;
    // if (this.data.action === StatusForm.DETELE) {
    //   this.delete();
    // }
    this.isView = this.data.action === StatusForm.VIEW;
    this.isCreate = this.data.action === StatusForm.CREATE;
    this.sourceView = Object.assign({}, this.cow);
  }
  // delete() {
  //   const deleteDialog = this.dialog.open(ConfirmationComponent, {
  //     data: {
  //       message: 'Bạn có muốn xóa?',
  //     },
  //     disableClose: true,
  //   });

  //   deleteDialog.afterClosed().subscribe(
  //     result => {
  //       if (result.confirmed) {
  //         this.couponService.deleteCoupon(this.coupon.id).subscribe(
  //           success => {
  //             this.dialogRef.close({
  //               action: StatusForm.DETELE,
  //               data: this.coupon,
  //             });
  //           }
  //         );
  //       }
  //     }
  //   );
  // }


  // create() {
  //   this.couponService.createCoupon(this.sourceView).subscribe(
  //     result => {
  //       this.dialogRef.close({
  //         data: result,
  //       });
  //     }
  //   );
  // }
  close() {
    this.dialogRef.close({
      action: StatusForm.VIEW,
      data: this.cow,
    });
  }

  // edit() {
  //   this.isView = false;
  // }

  // discard() {
  //   this.isView = true;
  //   this.sourceView = this.coupon;
  // }

  // save() {
  //   this.loading = true;
  //   this.couponService.updateCoupon(this.coupon.id, this.sourceView).subscribe(
  //     result => {
  //       this.isView = true;
  //       this.loading = false;
  //       this.coupon = this.sourceView;
  //     }
  //   );
  // }

  // fetchProvinces() {
  //   this.foodService.getProvinces().subscribe(
  //     res => {
  //       this.provinces = res;
  //       // this.dataSource = new MatTableDataSource(this.foods);
  //       // this.dataSource.paginator = this.paginator;
  //       // this.dataSource.sort = this.sort;
  //     });
  // }



}

