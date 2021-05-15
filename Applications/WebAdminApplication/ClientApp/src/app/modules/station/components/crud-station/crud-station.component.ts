import { MatTableDataSource } from '@angular/material/table';
import { StorageTank } from './../../../milk/models/storage';
import { Province } from './../../../province/models/province';
import { ConfirmationComponent } from './../../../../shared/components/confirmation/confirmation.component';
import { StatusForm } from './../../../../shared/enum/status-form';
import { StationService } from './../../station.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { Station } from '../../models/station';
import { District } from 'src/app/models/district';

@Component({
  selector: 'app-crud-station',
  templateUrl: './crud-station.component.html',
  styleUrls: ['./crud-station.component.scss']
})
export class CrudStationComponent implements OnInit {
  page = 1;
  displayedColumns: string[] = [
    'name',
    'action'];
  status: string;
  districts: District[] = [];
  station: Station = new Station();
  isView = true;
  provinces: Province[] = [];
  storageTanks: StorageTank[] =[];
  filteredProvinces: Province[] =[];
  filteredDistricts: District[] =[];
  isCreate = true;
  loading: boolean;
  // rolesOfUser: any[];
  // removeRole: any = {
  //   userId: 0,
  //   roleName: '',
  // };
  storageTankSource: MatTableDataSource<StorageTank>;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  displayedColumnsStorageTank: string[] =['name', 'quantity'];
  sourceView: Station = new Station();
  constructor(
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<CrudStationComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public stationService: StationService
    // private roleService: RoleService,
    // private systemService: SystemService,
  ) { }

  ngOnInit(): void {
    this.station = this.data.station;
    if (this.data.action === StatusForm.DETELE) {
      this.delete();
    }
    this.isView = this.data.action === StatusForm.VIEW;
    this.isCreate = this.data.action === StatusForm.CREATE;
    this.sourceView = Object.assign({}, this.station);
    this.fetchProvince();
    if (!!this.isView) {
      this.getDistrict(this.sourceView.provinceId);
      this.getStorageTanks(this.sourceView.id);
    }

  }


  getDistrict(provinceId) {
    this.stationService.getDistrictByProvinceId(provinceId).subscribe(result => {
      this.districts = result;
      this.filteredDistricts = this.districts;
    });
  }

  getStorageTanks(milkCollectionStationId: number) {
    this.stationService.getTanks().subscribe(result => {
      this.storageTanks = result.filter(tank => tank.milkCollectionStationId == milkCollectionStationId);
      this.storageTankSource = new MatTableDataSource(this.storageTanks);
    });
  }

  fetchProvince() {
    this.stationService.getProvince().subscribe(result => {
      this.provinces = result;
      this.filteredProvinces = this.provinces;
    });
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
          this.stationService.deleteStation(this.station.id).subscribe(
            success => {
              this.dialogRef.close({
                action: StatusForm.DETELE,
                data: this.station,
              });
            }
          );
        }
      }
    );
  }

  create() {
    this.stationService.createStation(this.sourceView).subscribe(
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
      data: this.station,
    });
  }

  edit() {
    this.isView = false;
  }

  discard() {
    this.isView = true;
    this.sourceView = this.station;
  }

  save() {
    this.loading = true;
    this.stationService.updateStation(this.station.id, this.sourceView).subscribe(
      result => {
        this.isView = true;
        this.loading = false;
        this.station = this.sourceView;
      }
    );
  }

}
