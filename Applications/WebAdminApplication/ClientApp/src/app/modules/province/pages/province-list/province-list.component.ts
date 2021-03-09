import { CrudProvinceComponent } from './../../components/crud-province/crud-province.component';
import { StatusForm } from 'src/app/shared/enum/status-form';
import { ProvinceService } from './../../province.service';
import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Province } from './../../../../models/province';
import { MatTableDataSource } from '@angular/material/table';
import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-province-list',
  templateUrl: './province-list.component.html',
  styleUrls: ['./province-list.component.scss']
})
export class ProvinceListComponent implements OnInit {
  value = '';
  page = 1;
  showLoad = false;
  displayedColumns: string[] = ['type', 'name', 'code'];
  dataSource: MatTableDataSource<Province>;
  provinces: Province[] = [];
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(
    public dialog: MatDialog,
    public provinceService: ProvinceService
  ) { }

  ngOnInit(): void {
    this.fetchProvinces();
  }

  afterClose(result: any) {
    const province = result.data;
    if (result.action === StatusForm.VIEW) {
      const employeeIndex = this.provinces.map(p => p.id).indexOf(province.id);
      this.provinces[employeeIndex] = province;
      this.dataSource.data = this.provinces;
    } else if (result.action === StatusForm.DETELE) {
      const employeeIndex = this.provinces.indexOf(province);
      if (employeeIndex !== -1) {
        this.provinces.splice(employeeIndex, 1);
        this.dataSource.data = this.provinces;
      }
    }
  }

  viewDetail(province: Province) {
    const viewDialog = this.dialog.open(CrudProvinceComponent, {
      height: '75%',
      width: '80%',
      data: {
        action: StatusForm.VIEW,
        province,
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

  fetchProvinces() {
    this.provinceService.getProvinces().subscribe(
      res => {
        this.provinces = res;
        this.dataSource = new MatTableDataSource(this.provinces);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
  }

  createProvince() {
    const createDialog = this.dialog.open(CrudProvinceComponent, {
      height: '75%',
      width: '80%',
      data: {
        action: StatusForm.CREATE,
        province: new Province(),
      },
      disableClose: true,
    });

    createDialog.afterClosed().subscribe(
      result => {
        this.provinceService.getProvinceById(result.data).subscribe(
          createdProvince => {
            if (createdProvince !== null) {
              this.provinces.push(createdProvince);
              this.dataSource.data = this.provinces;
            }
          }
        );
      }
    );
  }

}
