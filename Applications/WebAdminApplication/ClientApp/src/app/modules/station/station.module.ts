import { StationService } from './station.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListStationComponent } from './pages/list-station/list-station.component';
import { StationRoutingModule } from './station-routing.modules';
import { SharedModule } from 'src/app/shared/shared.module';
import { CrudStationComponent } from './components/crud-station/crud-station.component';
import { MatSelectFilterModule } from 'mat-select-filter';




@NgModule({
  declarations: [ListStationComponent, CrudStationComponent],
  imports: [
    CommonModule,
    StationRoutingModule,
    MatSelectFilterModule,
    SharedModule.forRoot()
  ],
  entryComponents:[CrudStationComponent],
  providers:[StationService]
})
export class StationModule { }
