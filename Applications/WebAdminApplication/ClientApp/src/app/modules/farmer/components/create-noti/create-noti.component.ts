import { StatusForm } from './../../../../shared/enum/status-form';
import { FarmerService } from './../../farmer.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { Notify } from './../../models/notify';
import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { Employee } from 'src/app/modules/employee/models/employee';
import { Farmer } from '../../models/farmer';

@Component({
  selector: 'app-create-noti',
  templateUrl: './create-noti.component.html',
  styleUrls: ['./create-noti.component.scss']
})
export class CreateNotiComponent implements OnInit {
  page = 1;
  displayedColumns: string[] = [
    'name',
    'action'];
  status: string;
  notification: Notify = new Notify();
  employees: Employee[] =[];
  farmers: Farmer[] = [];
  isView = true;
  isCreate = true;
  loading: boolean;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  sourceView: Notify = new Notify();
  constructor(
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<CreateNotiComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public farmerService: FarmerService

  ) { }


  ngOnInit(): void {
    this.isCreate = this.data.action === StatusForm.CREATE;
    this.fetchEmployees();
  }

  fetchEmployees() {
    this.farmerService.getEmployees().subscribe(result => {
      this.employees = result;
    });
  }

  create() {
    this.sourceView.farmerId = this.data.data;
    this.farmerService.createNotification(this.sourceView).subscribe(
      result => {
        this.dialogRef.close({
          data: result,
        });
      }
    );
  }
  close() {
    this.dialogRef.close({
      action: StatusForm.VIEW,
      data: this.notification,
    });
  }
}

