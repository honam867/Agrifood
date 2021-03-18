import { ValueObject } from './../../shared/models/value-object';
import { District } from './../../models/district';
import { Province } from './../../models/province';
import { Farmer } from './models/farmer';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { HttpService } from 'src/app/shared/services/http.service';
import { Byre } from './models/byre';
// import {RoleOfUser} from './models/roleofUser';
// import {Role} from '../system/models/role';
// import { RqListRole } from 'src/app/shared/models/RqListRoles';
@Injectable({
  providedIn: 'root'
})
export class FarmerService {
  constructor(private http: HttpService) { }

  getFarmers(): Observable<Farmer[]> {
    return this.http.get(`farmer`);
  }

  getFarmerById(farmerId: number): Observable<Farmer> {
    return this.http.get(`farmer/${farmerId}`);
  }

  updateFarmer(farmerId: number, updatedFarmer: Farmer): Observable<boolean> {
    return this.http.put(`farmer/${farmerId}`, updatedFarmer);
  }

  deleteFarmer(farmerId: number) {
    return this.http.delete(`farmer/${farmerId}`);
  }

  createFarmer(farmer: Farmer) {
    return this.http.post(`farmer`, farmer);
  }
  getProvince(): Observable<Province[]> {
    return this.http.get(`province`)
  }
  getDistrictByProvinceId(provinceId: number): Observable<District[]> {
    return this.http.get(`district/provinceId/${provinceId}`);
  }
  newCode(): Observable<ValueObject> {
    return this.http.get(`farmer/newcode`);
  }
  getByres(): Observable<Byre[]> {
    return this.http.get(`byre`);
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
