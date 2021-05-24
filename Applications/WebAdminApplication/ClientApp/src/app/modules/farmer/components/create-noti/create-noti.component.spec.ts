import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateNotiComponent } from './create-noti.component';

describe('CreateNotiComponent', () => {
  let component: CreateNotiComponent;
  let fixture: ComponentFixture<CreateNotiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateNotiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateNotiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
