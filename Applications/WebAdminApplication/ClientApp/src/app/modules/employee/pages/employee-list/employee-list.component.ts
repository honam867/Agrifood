import { CRUDUserComponent } from './../../../user/components/cruduser/cruduser.component';
import { ConfirmationComponent } from './../../../../shared/components/confirmation/confirmation.component';
import { CrudEmployeeComponent } from './../../components/crud-employee/crud-employee.component';
import { StatusForm } from './../../../../shared/enum/status-form';
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
  value='';
  page = 1;
  showLoad = false;
  displayedColumns: string[] = ['userName', 'name', 'phoneNumber', 'email', 'bank', 'accountNumber', 'action'];
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


  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  afterClose(result: any) {
    const employee = result.data;
    if (result.action === StatusForm.VIEW) {
      const employeeIndex = this.employees.map(p => p.id).indexOf(employee.id);
      this.employees[employeeIndex] = employee;
      this.dataSource.data = this.employees;
    } else if (result.action === StatusForm.DETELE) {
      const employeeIndex = this.employees.indexOf(employee);
      if (employeeIndex !== -1) {
        this.employees.splice(employeeIndex, 1);
        this.dataSource.data = this.employees;
      }
    }
  }

  editEmployee(employee: Employee) {
    const editDialog = this.dialog.open(CrudEmployeeComponent, {
      height: '90%',
      width: '90%',
      data: {
        action: StatusForm.EDIT,
        employee,
      },
      disableClose: true,
    });

    editDialog.afterClosed().subscribe(
      result => {
        this.afterClose(result);
      }
    );
  }

  viewDetail(employee: Employee) {
    const viewDialog = this.dialog.open(CrudEmployeeComponent, {
      height: '75%',
      width: '80%',
      data: {
        action: StatusForm.VIEW,
        employee,
      },
      disableClose: true,
    });

    viewDialog.afterClosed().subscribe(
      result => {
        this.afterClose(result);
      }
    );
  }

  deleteEmployee(employee: Employee) {
    const deleteDialog = this.dialog.open(ConfirmationComponent, {
      data: {
        message: 'Bạn có muốn xóa?',
      },
      disableClose: true,
    });

    deleteDialog.afterClosed().subscribe(
      result => {
        if (result.confirmed) {
          this.employeeService.deleteEmployee(employee.id).subscribe(
            success => {
              const employeeIndex = this.employees.indexOf(employee);
              if (employeeIndex !== -1) {
                this.employees.splice(employeeIndex, 1);
                this.dataSource.data = this.employees;
              }
            }
          );
        }
      }
    );
  }

  createEmployee() {
    const createDialog = this.dialog.open(CRUDUserComponent, {
      height: '90%',
      width: '90%',
      data: {
        action: StatusForm.CREATE,
        employee: new Employee(),
      },
      disableClose: true,
    });

    createDialog.afterClosed().subscribe(
      result => {
        this.employeeService.getEmployeeById(result.data).subscribe(
          createdFarmer => {
            if (createdFarmer !== null) {
              this.employees.push(createdFarmer);
              this.dataSource.data = this.employees;
            }
          }
        );
      }
    );
  }

}
