import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrudProvinceComponent } from './crud-province.component';

describe('CrudProvinceComponent', () => {
  let component: CrudProvinceComponent;
  let fixture: ComponentFixture<CrudProvinceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CrudProvinceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CrudProvinceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
