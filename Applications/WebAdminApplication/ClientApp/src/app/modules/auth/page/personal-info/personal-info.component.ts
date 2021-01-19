import { Employee } from './../../../employee/models/employee';
import { Router } from '@angular/router';
import { EmployeeService } from './../../../employee/employee-service';
import { AuthService } from '../../auth.service';
import { Component, OnInit, ViewChild, Inject, Input } from '@angular/core';

@Component({
  selector: 'app-personal-info',
  templateUrl: './personal-info.component.html',
  styleUrls: ['./personal-info.component.scss']
})
export class PersonalInfoComponent implements OnInit {
  page = 1;
  displayedColumns: string[] = [
    'name',
    'action'];
  status: string;
  roles: any;
  timeout: any;
  employee: Employee = new Employee();
  loading: boolean;
  sourceView: Employee = new Employee();
  constructor(
    public employeeService: EmployeeService,
    private router: Router,
    private authService: AuthService
    // private roleService: RoleService,
    // private systemService: SystemService,
  ) { }

  ngOnInit(): void {
    this.loading = false;
    this.roles = JSON.parse(localStorage.getItem('rolelist'));
    if (!this.roles[0].includes('Employee')) {
      this.router.navigate(['error-page']);
    }
    this.employee = JSON.parse(localStorage.getItem('employeeinfo'));
    this.sourceView = Object.assign({}, this.employee);
    console.log(this.sourceView);
    if (!this.authService.isSignin()) {
      this.router.navigate(['auth/signin']);
    }
  }


  save() {
    this.authService.updateEmployee(this.employee.id, this.sourceView).subscribe(
      result => {
        this.loading = true;
        if (result) {
          this.timeout = setInterval(() => {
            this.backToIndex();
          }, 3000);
        }

      }
    );
  }

  backToIndex() {
    this.router.navigate(['auth/signin']);
    clearInterval(this.timeout);
  }

}
