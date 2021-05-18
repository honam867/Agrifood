import { DashBoardRoutingModule } from './dashboard-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardListComponent } from './pages/dashboard-list/dashboard-list.component';
import { SharedModule } from 'src/app/shared/shared.module';



@NgModule({
  declarations: [DashboardListComponent],
  imports: [
    CommonModule,
    DashBoardRoutingModule,
    SharedModule.forRoot()
  ]
})
export class DashboardModule { }
