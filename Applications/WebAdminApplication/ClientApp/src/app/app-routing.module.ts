import { ErrorPagesComponent } from './layout/error-pages/error-pages.component';
import { AuthGuard } from './shared/services/auth-guard.service';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ContentComponent } from './layout/content/content.component';
// NOTE canActive for route need special role, canLoad need permission
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
        path: 'employee',
        loadChildren: () =>
          import('./modules/employee/employee.module').then(mod => mod.EmployeeModule)
      },
      {
        path: 'order',
        loadChildren: () =>
          import('./modules/order/order.module').then(mod => mod.OrderModule)
      },
      {
        path: 'province',
        loadChildren: () =>
          import('./modules/province/province.module').then(mod => mod.ProvinceModule)
      },
      {
        path: 'food',
        loadChildren: () =>
          import('./modules/food/food.module').then(mod => mod.FoodModule)
      },
      {
        path: 'farmer',
        canLoad: [AuthGuard],
        loadChildren: () =>
          import('./modules/farmer/farmer.module').then(mod => mod.FarmerModule),
      },
      {
        path: 'milk',
        canLoad: [AuthGuard],
        loadChildren: () =>
          import('./modules/milk/milk.module').then(mod => mod.MilkModule),
      },
      {
        path: 'milk',
        canLoad: [AuthGuard],
        loadChildren: () =>
          import('./modules/station/station.module').then(mod => mod.StationModule),
      },
      {
        path: 'farmer',
        canLoad: [AuthGuard],
        loadChildren: () =>
          import('./modules/cow/cow.module').then(mod => mod.CowModule),
      },
      {
        path: 'user',
        loadChildren: () =>
          import('./modules/user/user.module').then(mod => mod.UserModule),
        canActivate: [AuthGuard]
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
      {
        path: 'system',
        canActivate: [AuthGuard]
        ,
        loadChildren: () => import('./modules/system/system.module').then(m => m.SystemModule)
      }
    ]
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
