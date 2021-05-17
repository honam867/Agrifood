import { FarmerService } from './farmer.service';
import { SharedModule } from './../../shared/shared.module';
import { FarmerRoutingModule } from './farmer-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FarmerListComponent } from './pages/farmer-list/farmer-list.component';
import { CrudFarmerComponent } from './components/crud-farmer/crud-farmer.component';
import { ViewDetailComponent } from './components/view-detail/view-detail.component';



@NgModule({
  declarations: [FarmerListComponent, CrudFarmerComponent, ViewDetailComponent],
  imports: [
    CommonModule,
    FarmerRoutingModule,
    SharedModule.forRoot()
  ],
  entryComponents:[CrudFarmerComponent],
  providers: [FarmerService]
})
export class FarmerModule { }
