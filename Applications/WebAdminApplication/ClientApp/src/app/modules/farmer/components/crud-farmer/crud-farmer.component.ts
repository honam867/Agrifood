import { ValueObject } from './../../../../shared/models/value-object';
import { District } from './../../../../models/district';
import { Province } from './../../../../models/province';
import { ConfirmationComponent } from './../../../../shared/components/confirmation/confirmation.component';
import { StatusForm } from './../../../../shared/enum/status-form';
import { FarmerService } from './../../farmer.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Farmer } from './../../models/farmer';
import { MatPaginator } from '@angular/material/paginator';
import { Component, OnInit, ViewChild, Inject } from '@angular/core';

@Component({
  selector: 'app-crud-farmer',
  templateUrl: './crud-farmer.component.html',
  styleUrls: ['./crud-farmer.component.scss']
})
export class CrudFarmerComponent implements OnInit {
  page = 1;
  displayedColumns: string[] = [
    'name',
    'action'];
  status: string;
  farmer: Farmer = new Farmer();
  isView = true;
  isCreate = true;
  districts: District[] = [];
  // roles: Role[] = [];
  // roleOfUsers: RoleOfUser[] = [];
  rolesOfUser: any[];
  removeRole: any = {
    userId: 0,
    roleName: '',
  };
  provinces: Province[] = [];
  valueObject: ValueObject = new ValueObject();

  // dataSource: MatTableDataSource<Role>;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  sourceView: Farmer = new Farmer();
  constructor(
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<CrudFarmerComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public farmerService: FarmerService
    // private roleService: RoleService,
    // private systemService: SystemService,
  ) { }

  ngOnInit(): void {
    this.farmer = this.data.farmer;
    if (this.data.action === StatusForm.DETELE) {
      this.delete();
    }
    this.isView = this.data.action === StatusForm.VIEW;
    this.isCreate = this.data.action === StatusForm.CREATE;
    this.sourceView = Object.assign({}, this.farmer);
    this.fetchProvince();
    if (this.isView) {
      this.fetchDistrict(this.sourceView.provinceId);
    } else {
      this.fetchNewcode();
    }
  }

  fetchNewcode() {
    this.farmerService.newCode().subscribe(result => {
      this.valueObject = result;
      this.sourceView.code = this.valueObject.value;
    });
  }

  getDistrict(provinceId: number) {
    this.farmerService.getDistrictByProvinceId(provinceId).subscribe(result => {
      this.districts = result;
    });
  }


  fetchProvince() {
    this.farmerService.getProvince().subscribe(result => {
      this.provinces = result;
    });
  }

  fetchDistrict(proviceId: number) {
    this.farmerService.getDistrictByProvinceId(proviceId).subscribe(result => {
      this.districts = result;
    });
  }

  edit() {
    this.isView = false;
  }

  save() {
    this.farmerService.updateFarmer(this.farmer.id, this.sourceView).subscribe(
      result => {
        this.isView = true;
        this.farmer = this.sourceView;
      }
    );
  }

  discard() {
    this.isView = true;
    this.sourceView = this.farmer;
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
          this.farmerService.deleteFarmer(this.farmer.id).subscribe(
            success => {
              this.dialogRef.close({
                action: StatusForm.DETELE,
                data: this.farmer,
              });
            }
          );
        }
      }
    );
  }

  create() {
    this.farmerService.createFarmer(this.sourceView).subscribe(
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
      data: this.farmer,
    });
  }
}
