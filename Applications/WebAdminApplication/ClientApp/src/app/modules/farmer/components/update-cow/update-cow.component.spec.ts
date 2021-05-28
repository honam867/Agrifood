import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateCowComponent } from './update-cow.component';

describe('UpdateCowComponent', () => {
  let component: UpdateCowComponent;
  let fixture: ComponentFixture<UpdateCowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateCowComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateCowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
