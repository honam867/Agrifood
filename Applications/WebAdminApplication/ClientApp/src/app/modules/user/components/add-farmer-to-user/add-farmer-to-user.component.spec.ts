import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddFarmerToUserComponent } from './add-farmer-to-user.component';

describe('AddFarmerToUserComponent', () => {
  let component: AddFarmerToUserComponent;
  let fixture: ComponentFixture<AddFarmerToUserComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddFarmerToUserComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddFarmerToUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
