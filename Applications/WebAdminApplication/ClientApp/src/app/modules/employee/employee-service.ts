import { Employee } from './models/employee';
import { ValueObject } from './../../shared/models/value-object';
import { District } from './../../models/district';
import { Province } from './../../models/province';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { HttpService } from 'src/app/shared/services/http.service';
// import {RoleOfUser} from './models/roleofUser';
// import {Role} from '../system/models/role';
// import { RqListRole } from 'src/app/shared/models/RqListRoles';
@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  constructor(private http: HttpService) { }

  getEmployees(): Observable<Employee[]> {
    return this.http.get(`employee`);
  }

  getEmployeeById(employeeId: number): Observable<Employee> {
    return this.http.get(`employee/${employeeId}`);
  }

  updateEmployee(employeeId: number, updatedEmployee: Employee): Observable<boolean> {
    return this.http.put(`employee/${employeeId}`, updatedEmployee);
  }

  deleteEmployee(employeeId: number) {
    return this.http.delete(`employee/${employeeId}`);
  }

  createEmployee(employee: Employee) {
    return this.http.post(`employee`, employee);
  }
  // getRoleByUser(farmerId: number): Observable<Farmer[]> {
  //   return this.http.get(`user/role/${userId}`);
  // }
  // addRolesOfUser(rqrole: RqListRole)  {
  //   return this.http.post(`user/addlistrole`, rqrole);
  // }
  // deleteRoleOfUser(userId: number, role: string ) {
  //   return this.http.delete(`user/${userId}/${role}`);
  // }
  // role
  // getRoles(): Observable<RoleOfUser[]> {
  //   return this.http.get(`role`);
  // }
  // getRoleNotExist(userId: number): Observable<Role[]> {
  //   return this.http.get(`role/rolenotexists/${userId}`);
  // }

}
