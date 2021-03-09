// import { Employee } from './models/employee';
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
export class ProvinceService {
  constructor(private http: HttpService) { }

  getProvinces(): Observable<Province[]> {
    return this.http.get(`province`);
  }

  getProvinceById(provinceId: number): Observable<Province> {
    return this.http.get(`province/${provinceId}`);
  }

  updateProvince(provinceId: number, updatedProvince: Province): Observable<boolean> {
    return this.http.put(`province/${provinceId}`, updatedProvince);
  }

  deleteProvince(provinceId: number) {
    return this.http.delete(`province/${provinceId}`);
  }

  createProvince(province: Province) {
    return this.http.post(`province`, province);
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
