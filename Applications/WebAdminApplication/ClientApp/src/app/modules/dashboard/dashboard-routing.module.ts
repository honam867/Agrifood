import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardListComponent } from './pages/dashboard-list/dashboard-list.component';


const routes: Routes = [{
  path: 'dashboard',
  component: DashboardListComponent
},];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashBoardRoutingModule { }
