import { SharedModule } from './../../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SystemRoutingModule } from './system-routing.module';
import { PermissionPagesComponent } from './pages/permission-pages/permission-pages.component';
import { CrudPermissionComponent } from './components/crud-permission/crud-permission.component';


@NgModule({
  declarations: [PermissionPagesComponent, CrudPermissionComponent],
  imports: [
    CommonModule,
    SystemRoutingModule,
    SharedModule.forRoot()
  ],
  entryComponents: [],
  providers: []
})
export class SystemModule { }
