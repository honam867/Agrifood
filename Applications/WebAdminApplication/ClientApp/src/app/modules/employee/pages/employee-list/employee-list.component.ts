import { EmployeeService } from './../../employee-service';
import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Employee } from './../../models/employee';
import { MatTableDataSource } from '@angular/material/table';
import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {

  page = 1;
  showLoad = false;
  displayedColumns: string[] = ['userName', 'name', 'phoneNumber', 'email', 'bank', 'action'];
  dataSource: MatTableDataSource<Employee>;
  employees: Employee[] = [];
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(
    public dialog: MatDialog,
    // public farmerService: FarmerService
    public employeeService: EmployeeService
  ) { }

  ngOnInit(): void {
    // NOTE vua fetch xong employees
    this.fetchEmployees();
  }

  fetchEmployees() {
    this.employeeService.getEmployees().subscribe(
      res => {
        this.employees = res;
        console.log(this.employees);
        this.dataSource = new MatTableDataSource(this.employees);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
  }

}
