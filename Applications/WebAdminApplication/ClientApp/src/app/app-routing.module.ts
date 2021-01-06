import { ErrorPagesComponent } from './layout/error-pages/error-pages.component';
import { AuthGuard } from './shared/services/auth-guard.service';
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
    path: 'error-page',
    component: ErrorPagesComponent,
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
        path: 'farmer',
        loadChildren: () =>
          import('./modules/farmer/farmer.module').then(mod => mod.FarmerModule),
        canActivate: [AuthGuard]
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
      { path: 'system', loadChildren: () => import('./modules/system/system.module').then(m => m.SystemModule) }
    ]
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
