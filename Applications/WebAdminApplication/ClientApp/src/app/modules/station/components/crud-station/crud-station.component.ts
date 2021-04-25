import { ConfirmationComponent } from './../../../../shared/components/confirmation/confirmation.component';
import { StatusForm } from './../../../../shared/enum/status-form';
import { StationService } from './../../station.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { Station } from '../../models/station';

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
  station: Station = new Station();
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