import { ConfirmationComponent } from 'src/app/shared/components/confirmation/confirmation.component';
import { StatusForm } from 'src/app/shared/enum/status-form';
import { OrderService } from './../../order.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { Order } from './../../models/order';
import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { Employee } from 'src/app/modules/employee/models/employee';
import { Farmer } from 'src/app/modules/farmer/models/farmer';
import { Food } from 'src/app/modules/food/models/food';

@Component({
  selector: 'app-crud-order',
  templateUrl: './crud-order.component.html',
  styleUrls: ['./crud-order.component.scss']
})
export class CrudOrderComponent implements OnInit {
  page = 1;
  displayedColumns: string[] = [
    'name',
    'action'];
  status: string;
  order: Order = new Order();
  employees: Employee[] =[];
  farmers: Farmer[] = [];
  foods: Food[]= [];
  isView = true;
  isCreate = true;
  loading: boolean;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  sourceView: Order = new Order();
  constructor(
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<CrudOrderComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public orderService: OrderService

  ) { }

  ngOnInit(): void {
    this.order = this.data.order;
    if (this.data.action === StatusForm.DETELE) {
      this.delete();
    }
    this.isView = this.data.action === StatusForm.VIEW;
    this.isCreate = this.data.action === StatusForm.CREATE;
    this.sourceView = Object.assign({}, this.order);
    this.fetchEmployees();
    this.fetchFarmers();
    this.fetchFoods();
  }

  fetchFoods() {
    this.orderService.getFoods().subscribe(result => {
      this.foods = result;
    });
  }

  fetchFarmers() {
    this.orderService.getFarmers().subscribe(result => {
      this.farmers = result;
    });
  }

  fetchEmployees() {
    this.orderService.getEmployees().subscribe(result => {
      this.employees = result;
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
          this.orderService.deleteOrder(this.order.id).subscribe(
            success => {
              this.dialogRef.close({
                action: StatusForm.DETELE,
                data: this.order,
              });
            }
          );
        }
      }
    );
  }


  create() {
    this.orderService.createOrder(this.sourceView).subscribe(
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
      data: this.order,
    });
  }

  edit() {
    this.isView = false;
  }

  discard() {
    this.isView = true;
    this.sourceView = this.order;
  }

  save() {
    this.loading = true;
    this.orderService.updateOrder(this.order.id, this.sourceView).subscribe(
      result => {
        this.isView = true;
        this.loading = false;
        this.order = this.sourceView;
      }
    );
  }
}

