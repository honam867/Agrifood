import { ConfirmationComponent } from './../../../../shared/components/confirmation/confirmation.component';
import { StatusForm } from './../../../../shared/enum/status-form';
import { ProvinceService } from './../../province.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { Province } from './../../models/province';
import { Component, OnInit, ViewChild, Inject } from '@angular/core';

@Component({
  selector: 'app-crud-province',
  templateUrl: './crud-province.component.html',
  styleUrls: ['./crud-province.component.scss']
})
export class CrudProvinceComponent implements OnInit {
  page = 1;
  displayedColumns: string[] = [
    'name',
    'action'];
  status: string;
  province: Province = new Province();
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
  sourceView: Province = new Province();
  constructor(
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<CrudProvinceComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public ProvinceService: ProvinceService
    // private roleService: RoleService,
    // private systemService: SystemService,
  ) { }

  ngOnInit(): void {
    this.province = this.data.province;
    if (this.data.action === StatusForm.DETELE) {
      this.delete();
    }
    this.isView = this.data.action === StatusForm.VIEW;
    this.isCreate = this.data.action === StatusForm.CREATE;
    this.sourceView = Object.assign({}, this.province);
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
          this.ProvinceService.deleteProvince(this.province.id).subscribe(
            success => {
              this.dialogRef.close({
                action: StatusForm.DETELE,
                data: this.province,
              });
            }
          );
        }
      }
    );
  }

  create() {
    this.ProvinceService.createProvince(this.sourceView).subscribe(
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
      data: this.province,
    });
  }

  edit() {
    this.isView = false;
  }

  discard() {
    this.isView = true;
    this.sourceView = this.province;
  }

  save() {
    this.loading = true;
    this.ProvinceService.updateProvince(this.province.id, this.sourceView).subscribe(
      result => {
        this.isView = true;
        this.loading = false;
        this.province = this.sourceView;
      }
    );
  }

}
