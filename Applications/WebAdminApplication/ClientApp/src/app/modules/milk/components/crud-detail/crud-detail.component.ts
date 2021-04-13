import { Detail } from './../../models/detail';
import { StatusForm } from './../../../../shared/enum/status-form';
import { MilkService } from './../../milk.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { SelectionModel } from '@angular/cdk/collections';
import { FormGroup } from '@angular/forms';
import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { DetailOfCoupon } from '../../models/detailOfCoupon';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-crud-detail',
  templateUrl: './crud-detail.component.html',
  styleUrls: ['./crud-detail.component.scss']
})
export class CrudDetailComponent implements OnInit {
  displayedColumns: string[] = [
    'select',
    'name',
  ];
  form: FormGroup;
  isView = true;
  isCreate = true;
  name = [];
  // roles: Role[] = [];
  details: Detail[] = [];
  DetailsSelected: Detail[] = [];
  sourceView: DetailOfCoupon = new DetailOfCoupon();
  detailOfCoupon: DetailOfCoupon = new DetailOfCoupon();
  dataSource: MatTableDataSource<Detail>;
  selection = new SelectionModel<Detail>(true, []);
  detail : Detail = new Detail;
  // rqListRoles: RqListRole = new RqListRole();
  loaded = false;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  constructor(
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<CrudDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private couponService: MilkService,
    private snackBar: MatSnackBar
  ) {

  }

  ngOnInit() {
    this.detailOfCoupon = this.data.detailOfCoupon;
    this.isView = this.data.action === StatusForm.VIEW;
    this.isCreate = this.data.action === StatusForm.CREATE;
    this.sourceView = Object.assign({}, this.detailOfCoupon);
  }


  edit() {
    this.isView = false;
  }

  close() {
    this.dialogRef.close({
      action: StatusForm.VIEW,
      data: this.detailOfCoupon
    });
  }

  create() {
    this.couponService.createDetail(this.detail).subscribe(
      result => {
        if (result.value) {
          this.dialogRef.close({
            data: result,
          });
          this.snackBar.open('Đã thêm !', 'Tắt');
        }

      }
      , error => {
        if (error.error.message === 'Code Exists') {
          // this.CreateCus = false;
        }
      });
  }



}
