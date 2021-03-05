import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { StatusForm } from 'src/app/shared/enum/status-form';
import { CrudFoodComponent } from '../../components/crud-food/crud-food.component';
import { FoodService } from '../../food.service';
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
  displayedColumns: string[] = ['type', 'name', 'code','province'];
  dataSource: MatTableDataSource<Food>;
  foods: Food[] = [];
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(
    public dialog: MatDialog,
    public foodService:FoodService
  ) { }

  ngOnInit(): void {
    this.fetchFoods();
  }
  afterClose(result: any) {
    const food = result.data;
    if (result.action === StatusForm.VIEW) {
      const employeeIndex = this.foods.map(p => p.id).indexOf(food.id);
      this.foods[employeeIndex] = food;
      this.dataSource.data = this.foods;
    } else if (result.action === StatusForm.DETELE) {
      const employeeIndex = this.foods.indexOf(food);
      if (employeeIndex !== -1) {
        this.foods.splice(employeeIndex, 1);
        this.dataSource.data = this.foods;
      }
    }
  }

  viewDetail(food: Food) {
    const viewDialog = this.dialog.open(CrudFoodComponent, {
      height: '75%',
      width: '80%',
      data: {
        action: StatusForm.VIEW,
        food,
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

  fetchFoods() {
    this.foodService.getFoods().subscribe(
      res => {
        this.foods = res;
        this.dataSource = new MatTableDataSource(this.foods);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
  }

  createFood() {
    const createDialog = this.dialog.open(CrudFoodComponent, {
      height: '75%',
      width: '80%',
      data: {
        action: StatusForm.CREATE,
        food: new Food(),
      },
      disableClose: true,
    });

    createDialog.afterClosed().subscribe(
      result => {
        this.foodService.getFoodById(result.data).subscribe(
          createdProvince => {
            if (createdProvince !== null) {
              this.foods.push(createdProvince);
              this.dataSource.data = this.foods;
            }
          }
        );
      }
    );
  }


}
