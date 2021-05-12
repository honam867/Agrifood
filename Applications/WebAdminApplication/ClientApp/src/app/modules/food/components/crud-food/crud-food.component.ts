import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { ConfirmationComponent } from 'src/app/shared/components/confirmation/confirmation.component';
import { StatusForm } from 'src/app/shared/enum/status-form';
import { FoodService } from './../../food.service';
import { Food } from '../../models/food';
import { Province } from 'src/app/modules/province/models/province';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-crud-food',
  templateUrl: './crud-food.component.html',
  styleUrls: ['./crud-food.component.scss']
})
export class CrudFoodComponent implements OnInit {
  page = 1;
  displayedColumns: string[] = [
    'name',
    'action'];
  status: string;
  food: Food = new Food();
  provinces: Province[] = [];
  types: string[] =[
    'Thô', 'Tinh'
  ]
  isView = true;
  isCreate = true;
  loading: boolean;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  sourceView: Food = new Food();
  constructor(
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<CrudFoodComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public foodService: FoodService

  ) { }


  ngOnInit(): void {
    this.fetchProvinces();
    this.food = this.data.food;
    if (this.data.action === StatusForm.DETELE) {
      this.delete();
    }
    this.isView = this.data.action === StatusForm.VIEW;
    this.isCreate = this.data.action === StatusForm.CREATE;
    this.sourceView = Object.assign({}, this.food);
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
          this.foodService.deleteFood(this.food.id).subscribe(
            success => {
              this.dialogRef.close({
                action: StatusForm.DETELE,
                data: this.food,
              });
            }
          );
        }
      }
    );
  }


  create() {
    this.foodService.createFood(this.sourceView).subscribe(
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
      data: this.food,
    });
  }

  edit() {
    this.isView = false;
  }

  discard() {
    this.isView = true;
    this.sourceView = this.food;
  }

  save() {
    this.loading = true;
    this.foodService.updateFood(this.food.id, this.sourceView).subscribe(
      result => {
        this.isView = true;
        this.loading = false;
        this.food = this.sourceView;
      }
    );
  }

  fetchProvinces() {
    this.foodService.getProvinces().subscribe(
      res => {
        this.provinces = res;
        // this.dataSource = new MatTableDataSource(this.foods);
        // this.dataSource.paginator = this.paginator;
        // this.dataSource.sort = this.sort;
      });
  }



}
