import { OrderRoutingComponent } from './order-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderListComponent } from './pages/order-list/order-list.component';
import { SharedModule } from 'src/app/shared/shared.module';



@NgModule({
  declarations: [OrderListComponent],
  imports: [
    CommonModule,
    OrderRoutingComponent,
    SharedModule.forRoot()
  ]
})
export class OrderModule { }
