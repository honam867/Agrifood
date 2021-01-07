import { SharedModule } from './../../shared/shared.module';
import { EmployeeRoutingModule } from './employee-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeListComponent } from './pages/employee-list/employee-list.component';
import { CrudEmployeeComponent } from './components/crud-employee/crud-employee.component';



@NgModule({
  declarations: [EmployeeListComponent, CrudEmployeeComponent],
  imports: [
    CommonModule,
    EmployeeRoutingModule,
    SharedModule.forRoot()
  ]
})
export class EmployeeModule { }
