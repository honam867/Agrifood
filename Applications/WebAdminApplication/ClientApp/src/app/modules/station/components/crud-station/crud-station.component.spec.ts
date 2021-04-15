import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrudStationComponent } from './crud-station.component';

describe('CrudStationComponent', () => {
  let component: CrudStationComponent;
  let fixture: ComponentFixture<CrudStationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CrudStationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CrudStationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
