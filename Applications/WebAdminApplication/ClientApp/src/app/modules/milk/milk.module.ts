import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CouponComponent } from './pages/coupon/coupon.component';
import { CrudCouponComponent } from './components/crud-coupon/crud-coupon.component';
import { MilkRoutingModule } from './milk-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CrudDetailComponent } from './components/crud-detail/crud-detail.component';



@NgModule({
  declarations: [CouponComponent, CrudCouponComponent, CrudDetailComponent],
  imports: [
    CommonModule,
    MilkRoutingModule,
    SharedModule.forRoot()
  ],
  entryComponents:[CrudCouponComponent]
})
export class MilkModule { }
