import { ConfirmationComponent } from './../../../../shared/components/confirmation/confirmation.component';
import { StatusForm } from './../../../../shared/enum/status-form';
import { EmployeeService } from './../../employee-service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { Employee } from './../../models/employee';
import { Component, OnInit, ViewChild, Inject } from '@angular/core';

@Component({
  selector: 'app-crud-employee',
  templateUrl: './crud-employee.component.html',
  styleUrls: ['./crud-employee.component.scss']
})
export class CrudEmployeeComponent implements OnInit {
  page = 1;
  displayedColumns: string[] = [
    'name',
    'action'];
  status: string;
  employee: Employee = new Employee();
  isView = true;
  isCreate = true;
  loading: boolean;
  // rolesOfUser: any[];
  // removeRole: any = {
  //   userId: 0,
  //   roleName: '',
  // };
  // dataSource: MatTableDataSource<Role>;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  sourceView: Employee = new Employee();
  constructor(
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<CrudEmployeeComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public employeeService: EmployeeService
    // private roleService: RoleService,
    // private systemService: SystemService,
  ) { }

  ngOnInit(): void {
    this.employee = this.data.employee;
    if (this.data.action === StatusForm.DETELE) {
      this.delete();
    }
    this.isView = this.data.action === StatusForm.VIEW;
    this.isCreate = this.data.action === StatusForm.CREATE;
    this.sourceView = Object.assign({}, this.employee);
  }

  close() {
    this.dialogRef.close({
      action: StatusForm.VIEW,
      data: this.employee,
    });
  }

  create() {
    this.employeeService.createEmployee(this.sourceView).subscribe(
      result => {
        this.dialogRef.close({
          data: result,
        });
      }
    );
  }

  delete() {
    const deleteDialog = this.dialog.open(ConfirmationComponent, {
      data: {
        message: 'Bạn có muốn xóa?',
      },
      disableClose: true,
    });

    deleteDialog.afterClosed().subscribe(
      result => {
        if (result.confirmed) {
          this.employeeService.deleteEmployee(this.employee.id).subscribe(
            success => {
              this.dialogRef.close({
                action: StatusForm.DETELE,
                data: this.employee,
              });
            }
          );
        }
      }
    );
  }

  edit() {
    this.isView = false;
  }

  discard() {
    this.isView = true;
    this.sourceView = this.employee;
  }

  save() {
    this.loading = true;
    this.employeeService.updateEmployee(this.employee.id, this.sourceView).subscribe(
      result => {
        this.isView = true;
        this.loading = false;
        this.employee = this.sourceView;
      }
    );
  }

}
