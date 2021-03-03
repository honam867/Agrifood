
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProvinceListComponent } from './pages/province-list/province-list.component';


const routes: Routes = [{
  path: 'provincelist',
  component: ProvinceListComponent,
},];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProvinceRoutingModule { }
