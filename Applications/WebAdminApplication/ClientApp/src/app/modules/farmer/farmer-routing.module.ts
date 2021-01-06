import { AuthGuard } from './../../shared/services/auth-guard.service';
import { FarmerListComponent } from './pages/farmer-list/farmer-list.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [{
  path: 'farmerlist',
  component: FarmerListComponent,
},];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FarmerRoutingModule { }
