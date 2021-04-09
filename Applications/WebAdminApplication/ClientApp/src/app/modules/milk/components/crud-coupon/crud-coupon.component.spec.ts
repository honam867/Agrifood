import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrudCouponComponent } from './crud-coupon.component';

describe('CrudCouponComponent', () => {
  let component: CrudCouponComponent;
  let fixture: ComponentFixture<CrudCouponComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CrudCouponComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CrudCouponComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
