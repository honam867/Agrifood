import { Detail } from './models/detail';
import { District } from './../../models/district';
import { Province } from './../../models/province';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { HttpService } from 'src/app/shared/services/http.service';
import { Coupon } from './models/coupon';
// import {RoleOfUser} from './models/roleofUser';
// import {Role} from '../system/models/role';
// import { RqListRole } from 'src/app/shared/models/RqListRoles';
@Injectable({
  providedIn: 'root'
})
export class MilkService {
  constructor(private http: HttpService) { }

  getCoupons(): Observable<Coupon[]> {
    return this.http.get(`milkcoupon`);
  }

  getCouponById(couponId: number): Observable<Coupon> {
    return this.http.get(`milkcoupon/${couponId}`);
  }

  updateCoupon(couponId: number, updatedCoupon: Coupon): Observable<boolean> {
    return this.http.put(`milkcoupon/${couponId}`, updatedCoupon);
  }

  deleteCoupon(couponId: number) {
    return this.http.delete(`milkcoupon/${couponId}`);
  }

  createCoupon(coupon: Coupon) {
    return this.http.post(`milkcoupon`, coupon);
  }

  getDetailByCouponId(couponId: number): Observable<Coupon[]> {
    return this.http.get(`milkcoupondetail/milkcoupon/${couponId}`);
  }

  createDetail(detail: Detail) {
    return this.http.post(`milkcoupondetail`, detail);
  }

  deleteCouponDetail(detailId: number){
    return this.http.delete(`milkcoupondetail/${detailId}`);
  }

  updateCouponDetail(detailId: number, updatedDetail: Detail): Observable<boolean> {
    return this.http.put(`milkcoupon/${detailId}`, updatedDetail);
  }


  // getProvince(): Observable<Province[]> {
  //   return this.http.get(`province`)
  // }
  // getDistrictByProvinceId(provinceId: number): Observable<District[]> {
  //   return this.http.get(`district/provinceId/${provinceId}`);
  // }
  // newCode(): Observable<ValueObject> {
  //   return this.http.get(`farmer/newcode`);
  // }
  // getByres(): Observable<Byre[]> {
  //   return this.http.get(`byre`);
  // }
  // getCows(): Observable<Cow[]> {
  //   return this.http.get(`cow`);
  // }
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
