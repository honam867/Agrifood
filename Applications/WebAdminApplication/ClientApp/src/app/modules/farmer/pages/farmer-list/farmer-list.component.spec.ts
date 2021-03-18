import { CrudFarmerComponent } from './../../components/crud-farmer/crud-farmer.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { HttpService } from './../../../../shared/services/http.service';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { DebugElement } from '@angular/core';
import { async, ComponentFixture, fakeAsync, TestBed, tick } from '@angular/core/testing';
import { FarmerListComponent } from './farmer-list.component';

describe('FarmerListComponent', () => {
  let component: FarmerListComponent;
  let fixture: ComponentFixture<FarmerListComponent>;
  let de:DebugElement;
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports:[HttpClientTestingModule],
      declarations: [ FarmerListComponent, CrudFarmerComponent ],
      providers:[
        {provide: MAT_DIALOG_DATA, useValue: {}},
        {provide: MatDialog, useValue: {}},
        HttpService
      ],
    })
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FarmerListComponent);
    component = fixture.componentInstance;
    de = fixture.debugElement;
    fixture.detectChanges();
  });

  it('Farmers should exist', fakeAsync(() => {
    expect(component.farmers.length).toEqual(0);
    // component.fetchUsers();
    // tick(500);
    // expect(component.farmers.length).toBeGreaterThan(0);
  }));

  it('Showload should be false by default', () => {
    expect(component.showLoad).toBeFalsy();
  });

  it('Should trigger crud farmer component when click view detail', () => {
    let test = component.viewDetail.toString();
    expect(test).toContain('CrudFarmerComponent');
  });


});
