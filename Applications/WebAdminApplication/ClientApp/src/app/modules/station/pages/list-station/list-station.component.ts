import { StationService } from './../../station.service';
import { StatusForm } from './../../../../shared/enum/status-form';
import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Station } from '../../models/station';
import { CrudStationComponent } from '../../components/crud-station/crud-station.component';

@Component({
  selector: 'app-list-station',
  templateUrl: './list-station.component.html',
  styleUrls: ['./list-station.component.scss']
})
export class ListStationComponent implements OnInit {
  value = '';
  page = 1;
  showLoad = false;
  displayedColumns: string[] = ['name', 'typeOfMilkId', 'code', 'districtId', 'address', 'phoneNumber', 'email'];
  dataSource: MatTableDataSource<Station>;
  stations: Station[] = [];
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(
    public dialog: MatDialog,
    public stationService: StationService
  ) { }

  ngOnInit(): void {
    this.fetchStations();
  }

  afterClose(result: any) {
    const station = result.data;
    if (result.action === StatusForm.VIEW) {
      const employeeIndex = this.stations.map(p => p.id).indexOf(station.id);
      this.stations[employeeIndex] = station;
      this.dataSource.data = this.stations;
    } else if (result.action === StatusForm.DETELE) {
      const employeeIndex = this.stations.indexOf(station);
      if (employeeIndex !== -1) {
        this.stations.splice(employeeIndex, 1);
        this.dataSource.data = this.stations;
      }
    }
  }

  viewDetail(station: Station) {
    const viewDialog = this.dialog.open(CrudStationComponent, {
      height: '75%',
      width: '80%',
      data: {
        action: StatusForm.VIEW,
        station,
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

  fetchStations() {
    this.stationService.getStations().subscribe(
      res => {
        this.stations = res;
        this.dataSource = new MatTableDataSource(this.stations);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
  }

  createStation() {
    const createDialog = this.dialog.open(CrudStationComponent, {
      height: '75%',
      width: '80%',
      data: {
        action: StatusForm.CREATE,
        station: new Station(),
      },
      disableClose: true,
    });

    createDialog.afterClosed().subscribe(
      result => {
        this.stationService.getStationById(result.data).subscribe(
          createdStation => {
            if (createdStation !== null) {
              this.stations.push(createdStation);
              this.dataSource.data = this.stations;
            }
          }
        );
      }
    );
  }

}

