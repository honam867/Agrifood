
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListStationComponent } from './pages/list-station/list-station.component';


const routes: Routes = [{
  path: 'milkstation',
  component: ListStationComponent,
},];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StationRoutingModule { }
