import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FoodListComponent } from './pages/food-list/food-list.component';
import { FoodRoutingModule } from './food-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CrudFoodComponent } from './components/crud-food/crud-food.component';



@NgModule({
  declarations: [FoodListComponent, CrudFoodComponent],
  imports: [
    FoodRoutingModule,
    CommonModule,
    SharedModule.forRoot()
  ],
  entryComponents:[CrudFoodComponent],
})
export class FoodModule { }
