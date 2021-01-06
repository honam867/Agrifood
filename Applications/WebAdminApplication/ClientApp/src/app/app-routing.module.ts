import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ContentComponent } from './layout/content/content.component';
const routes: Routes = [
  {
    path: '',
    redirectTo: 'homepage',
    pathMatch: 'full'
  },
  {
    path: 'auth',
    loadChildren: () =>
      import('./modules/auth/auth.module').then(mod => mod.AuthModule)
  },
  {
    path: '',
    component: ContentComponent,
    children: [
      {
        path: 'employee',
        loadChildren: () =>
          import('./modules/employee/employee.module').then(mod => mod.EmployeeModule)
      },
      {
        path: 'farmer',
        loadChildren: () =>
          import('./modules/farmer/farmer.module').then(mod => mod.FarmerModule)
      },
      {
        path: 'user',
        loadChildren: () =>
          import('./modules/user/user.module').then(mod => mod.UserModule)
      },
      {
        path: 'reports',
        loadChildren: () =>
          import('./modules/reports/reports.module').then(mod => mod.ReportsModule)
      },
      {
        path: 'report',
        loadChildren: () =>
          import('./modules/report/report.module').then(mod => mod.ReportModule)
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
