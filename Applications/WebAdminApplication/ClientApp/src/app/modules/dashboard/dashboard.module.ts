import { DashBoardService } from './dashboard.service';
import { DashBoardRoutingModule } from './dashboard-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardListComponent } from './pages/dashboard-list/dashboard-list.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { MatSelectFilterModule } from 'mat-select-filter';




@NgModule({
  declarations: [DashboardListComponent],
  imports: [
    CommonModule,
    DashBoardRoutingModule,
    MatSelectFilterModule,
    SharedModule.forRoot()
  ],
  providers:[DashBoardService]
})
export class DashboardModule { }
