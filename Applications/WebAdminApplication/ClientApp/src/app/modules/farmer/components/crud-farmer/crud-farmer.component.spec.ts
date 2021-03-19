import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CrudFarmerComponent } from './crud-farmer.component';

describe('CrudFarmerComponent', () => {
  let component: CrudFarmerComponent;
  let fixture: ComponentFixture<CrudFarmerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CrudFarmerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CrudFarmerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component.farmerByres.length).toBeGreaterThan(2);
  });
});
