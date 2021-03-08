import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrudFoodComponent } from './crud-food.component';

describe('CrudFoodComponent', () => {
  let component: CrudFoodComponent;
  let fixture: ComponentFixture<CrudFoodComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CrudFoodComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CrudFoodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
