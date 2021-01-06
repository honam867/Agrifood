import { CrudPermissionComponent } from './components/crud-permission/crud-permission.component';
import { PermissionPagesComponent } from './pages/permission-pages/permission-pages.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {
    path: 'permissionlist',
    component: PermissionPagesComponent
  },
  {
    path: 'permissiongroup/:id',
    component: CrudPermissionComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SystemRoutingModule { }
