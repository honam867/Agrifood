import { ProvinceService } from './province.service';
import { SharedModule } from './../../shared/shared.module';
import { ProvinceRoutingModule } from './province-routing.modules';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProvinceListComponent } from './pages/province-list/province-list.component';
import { CrudProvinceComponent } from './components/crud-province/crud-province.component';



@NgModule({
  declarations: [ProvinceListComponent, CrudProvinceComponent],
  imports: [
    CommonModule,
    ProvinceRoutingModule,
    SharedModule.forRoot()
  ],
  entryComponents:[CrudProvinceComponent],
  providers: [ProvinceService]
})
export class ProvinceModule { }
