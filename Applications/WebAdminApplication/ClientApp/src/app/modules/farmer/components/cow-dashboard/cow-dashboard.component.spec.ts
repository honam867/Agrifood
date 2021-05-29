import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CowDashboardComponent } from './cow-dashboard.component';

describe('CowDashboardComponent', () => {
  let component: CowDashboardComponent;
  let fixture: ComponentFixture<CowDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CowDashboardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CowDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
