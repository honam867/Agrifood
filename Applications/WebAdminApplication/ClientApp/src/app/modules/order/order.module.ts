import { OrderRoutingComponent } from './order-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderListComponent } from './pages/order-list/order-list.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { CrudOrderComponent } from './components/crud-order/crud-order.component';



@NgModule({
  declarations: [OrderListComponent, CrudOrderComponent],
  imports: [
    CommonModule,
    OrderRoutingComponent,
    SharedModule.forRoot()
  ],
  entryComponents:[CrudOrderComponent],

})
export class OrderModule { }
