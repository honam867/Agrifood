import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { ConfirmationComponent } from 'src/app/shared/components/confirmation/confirmation.component';
import { StatusForm } from 'src/app/shared/enum/status-form';
import { FoodService } from './../../food.service';
import { Food } from '../../models/food';

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
  isView = true;
  isCreate = true;
  loading: boolean;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  sourceView: Food = new Food();
  constructor(
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<CrudFoodComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public FoodService: FoodService
    
  ) { }


  ngOnInit(): void {
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

    // deleteDialog.afterClosed().subscribe(
    //   result => {
    //     if (result.confirmed) {
    //       this.ProvinceService.deleteProvince(this.province.id).subscribe(
    //         success => {
    //           this.dialogRef.close({
    //             action: StatusForm.DETELE,
    //             data: this.province,
    //           });
    //         }
    //       );
    //     }
    //   }
    // );
  }
  
  edit() {
    this.isView = false;
  }
  close() {
    this.dialogRef.close({
      action: StatusForm.VIEW,
      data: this.food,
    });
  }



}
