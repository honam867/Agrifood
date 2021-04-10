import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CowListComponent } from './pages/cow-list/cow-list.component';


const routes: Routes = [{
  path: 'cowlist',
  component: CowListComponent,
},];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CowRoutingModule { }
