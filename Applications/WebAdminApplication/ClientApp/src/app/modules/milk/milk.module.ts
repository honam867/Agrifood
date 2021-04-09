import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CouponComponent } from './pages/coupon/coupon.component';
import { CrudCouponComponent } from './components/crud-coupon/crud-coupon.component';
import { MilkRoutingModule } from './milk-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';



@NgModule({
  declarations: [CouponComponent, CrudCouponComponent],
  imports: [
    CommonModule,
    MilkRoutingModule,
    SharedModule.forRoot()
  ],
  entryComponents:[CrudCouponComponent]
})
export class MilkModule { }
