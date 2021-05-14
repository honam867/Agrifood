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
  displayedColumns: string[] = ['farmer', 'employee', 'foodId', 'createdDate'];
  dataSource: MatTableDataSource<Order>;
  orders: Order[] = [];
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(
    public dialog: MatDialog,
    public orderService: OrderService
  ) { }

  ngOnInit(): void {
    this.fetchCoupons();
  }
  afterClose(result: any) {
    const coupon = result.data;
    if (result.action === StatusForm.VIEW) {
      const employeeIndex = this.orders.map(p => p.id).indexOf(coupon.id);
      this.orders[employeeIndex] = coupon;
      this.dataSource.data = this.orders;
    } else if (result.action === StatusForm.DETELE) {
      const employeeIndex = this.orders.indexOf(coupon);
      if (employeeIndex !== -1) {
        this.orders.splice(employeeIndex, 1);
        this.dataSource.data = this.orders;
      }
    }
  }

  // viewDetail(order: Order) {
  //   const viewDialog = this.dialog.open(CrudCouponComponent, {
  //     height: '75%',
  //     width: '80%',
  //     data: {
  //       action: StatusForm.VIEW,
  //       order,
  //     },
  //     disableClose: true,
  //   });
  //   viewDialog.afterClosed().subscribe(
  //     result => {
  //       this.afterClose(result);
  //     }
  //   );
  // }


  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  fetchCoupons() {
    this.orderService.getOrders().subscribe(
      res => {
        this.orders = res;
        this.dataSource = new MatTableDataSource(this.orders);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
  }

  // createCoupon() {
  //   const createDialog = this.dialog.open(CrudCouponComponent, {
  //     height: '75%',
  //     width: '80%',
  //     data: {
  //       action: StatusForm.CREATE,
  //       order: new Order(),
  //     },
  //     disableClose: true,
  //   });

  //   createDialog.afterClosed().subscribe(
  //     result => {
  //       this.orderService.getCouponById(result.data).subscribe(
  //         createdOrder => {
  //           if (createdOrder !== null) {
  //             this.orders.push(createdOrder);
  //             this.dataSource.data = this.orders;
  //           }
  //         }
  //       );
  //     }
  //   );
  // }


}

