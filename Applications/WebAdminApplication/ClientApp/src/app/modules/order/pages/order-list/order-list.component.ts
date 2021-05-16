import { CrudOrderComponent } from './../../components/crud-order/crud-order.component';
import { StatusForm } from 'src/app/shared/enum/status-form';
import { OrderService } from './../../order.service';
import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Order } from './../../models/order';
import { MatTableDataSource } from '@angular/material/table';
import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.scss']
})
export class OrderListComponent implements OnInit {
  value = '';
  page = 1;
  showLoad = false;
  displayedColumns: string[] = ['employee', 'farmer', 'foodName', 'quantity', 'createdDate'];
  dataSource: MatTableDataSource<Order>;
  orders: Order[] = [];
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(
    public dialog: MatDialog,
    public orderService: OrderService
  ) { }

  ngOnInit(): void {
    this.fetchOrders();
  }
  // afterClose(result: any) {
  //   const order = result.data;
  //   if (result.action === StatusForm.VIEW) {
  //     const employeeIndex = this.orders.map(p => p.id).indexOf(order.id);
  //     this.orders[employeeIndex] = order;
  //     this.dataSource.data = this.orders;
  //   } else if (result.action === StatusForm.DETELE) {
  //     const employeeIndex = this.orders.indexOf(order);
  //     if (employeeIndex !== -1) {
  //       this.orders.splice(employeeIndex, 1);
  //       this.dataSource.data = this.orders;
  //     }
  //   }
  // }


  createOrder() {
    const createDialog = this.dialog.open(CrudOrderComponent, {
      height: '75%',
      width: '80%',
      data: {
        action: StatusForm.CREATE,
        order: new Order(),
      },
      disableClose: true,
    });

    createDialog.afterClosed().subscribe(
      result => {
        this.orderService.getOrderById(result.data).subscribe(
          createdOrder => {
            if (createdOrder !== null) {
              this.orders.push(createdOrder);
              this.dataSource.data = this.orders;
            }
          }
        );
      }
    );
  }

  viewDetail(order: Order) {
    const viewDialog = this.dialog.open(CrudOrderComponent, {
      height: '75%',
      width: '80%',
      data: {
        action: StatusForm.VIEW,
        order,
      },
      disableClose: true,
    });
    viewDialog.afterClosed().subscribe(
      result => {
        this.fetchOrders();
      }
    );
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  fetchOrders() {
    this.orderService.getOrders().subscribe(
      res => {
        this.orders = res;
        this.dataSource = new MatTableDataSource(this.orders);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
  }


}

