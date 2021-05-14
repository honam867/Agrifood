import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrderListComponent } from './pages/order-list/order-list.component';


const routes: Routes = [{
  path: 'orderlist',
  component: OrderListComponent,
},];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrderRoutingComponent { }
