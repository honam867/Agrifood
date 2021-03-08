import { AuthGuard } from './../../shared/services/auth-guard.service';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FoodListComponent } from './pages/food-list/food-list.component';


const routes: Routes = [{
  path: 'foodlist',
  component: FoodListComponent,
},];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FoodRoutingModule { }
