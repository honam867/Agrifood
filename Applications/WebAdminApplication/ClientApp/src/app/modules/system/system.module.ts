import { SharedModule } from './../../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SystemRoutingModule } from './system-routing.module';
import { PermissionPagesComponent } from './pages/permission-pages/permission-pages.component';


@NgModule({
  declarations: [PermissionPagesComponent],
  imports: [
    CommonModule,
    SystemRoutingModule,
    SharedModule.forRoot()
  ],
  entryComponents: [],
  providers: []
})
export class SystemModule { }
