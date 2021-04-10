import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CowListComponent } from './pages/cow-list/cow-list.component';
import { CowRoutingModule } from './cow-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CrudCowComponent } from './components/crud-cow/crud-cow.component';
import { CowService } from './cow-service';



@NgModule({
  declarations: [CowListComponent, CrudCowComponent],
  imports: [
    CommonModule,
    CowRoutingModule,
    SharedModule.forRoot()
  ],
  entryComponents:[CrudCowComponent],
  providers:[CowService]
})
export class CowModule { }
