import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrudCowComponent } from './crud-cow.component';

describe('CrudCowComponent', () => {
  let component: CrudCowComponent;
  let fixture: ComponentFixture<CrudCowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CrudCowComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CrudCowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
