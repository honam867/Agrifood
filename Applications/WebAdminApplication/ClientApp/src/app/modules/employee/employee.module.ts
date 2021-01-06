import { SharedModule } from './../../shared/shared.module';
import { EmployeeRoutingModule } from './employee-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeListComponent } from './pages/employee-list/employee-list.component';



@NgModule({
  declarations: [EmployeeListComponent],
  imports: [
    CommonModule,
    EmployeeRoutingModule,
    SharedModule.forRoot()
  ]
})
export class EmployeeModule { }
