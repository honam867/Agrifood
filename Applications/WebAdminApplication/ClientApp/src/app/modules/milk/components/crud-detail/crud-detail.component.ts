import { ConfirmationComponent } from 'src/app/shared/components/confirmation/confirmation.component';
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
  page = 1;
  displayedColumns: string[] = [
    'name',
    'action'];
  status: string;
  detail: Detail = new Detail();
  isView = true;
  isCreate = true;
  loading: boolean;
  // rolesOfUser: any[];
  // removeRole: any = {
  //   userId: 0,
  //   roleName: '',
  // };
  // dataSource: MatTableDataSource<Role>;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  sourceView: Detail = new Detail();
  constructor(
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<CrudDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public couponService: MilkService
    // private roleService: RoleService,
    // private systemService: SystemService,
  ) { }

  ngOnInit(): void {
    this.detail = this.data.detail;
    if (this.data.action === StatusForm.DETELE) {
      this.delete();
    }
    this.isView = this.data.action === StatusForm.VIEW;
    this.isCreate = this.data.action === StatusForm.CREATE;
    this.sourceView = Object.assign({}, this.detail);
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
          this.couponService.deleteCouponDetail(this.detail.id).subscribe(
            success => {
              this.dialogRef.close({
                action: StatusForm.DETELE,
                data: this.detail,
              });
            }
          );
        }
      }
    );
  }

  create() {
    this.sourceView.milkCouponId = this.data.couponId;
    this.couponService.createDetail(this.sourceView).subscribe(
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
      data: this.detail,
    });
  }

  edit() {
    this.isView = false;
  }

  discard() {
    this.isView = true;
    this.sourceView = this.detail;
  }

  save() {
    this.loading = true;
    this.couponService.updateCouponDetail(this.detail.id, this.sourceView).subscribe(
      result => {
        this.isView = true;
        this.loading = false;
        this.detail = this.sourceView;
      }
    );
  }

}
