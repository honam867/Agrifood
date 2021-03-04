import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { StatusForm } from 'src/app/shared/enum/status-form';
import { CrudFoodComponent } from '../../components/crud-food/crud-food.component';
import { Food } from '../../models/food';

@Component({
  selector: 'app-food-list',
  templateUrl: './food-list.component.html',
  styleUrls: ['./food-list.component.scss']
})
export class FoodListComponent implements OnInit {
  value = '';
  page = 1;
  showLoad = false;
  displayedColumns: string[] = ['type', 'name', 'code'];
  dataSource: MatTableDataSource<Food>;
  foods: Food[] = [];
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(
    public dialog: MatDialog,
    // public provinceService: ProvinceService
  ) { }

  ngOnInit(): void {
    // this.fetchProvinces();
  }
  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
  createFood() {
    const createDialog = this.dialog.open(CrudFoodComponent, {
      height: '75%',
      width: '80%',
      data: {
        action: StatusForm.CREATE,
        province: new Food(),
      },
      disableClose: true,
    });

    // createDialog.afterClosed().subscribe(
    //   result => {
    //     this.provinceService.getProvinceById(result.data).subscribe(
    //       createdProvince => {
    //         if (createdProvince !== null) {
    //           this.provinces.push(createdProvince);
    //           this.dataSource.data = this.provinces;
    //         }
    //       }
    //     );
    //   }
    // );
  }


}
