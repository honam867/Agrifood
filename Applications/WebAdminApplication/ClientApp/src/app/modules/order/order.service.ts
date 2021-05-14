import { Order } from './models/order';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from 'src/app/shared/services/http.service';
import { Employee } from '../employee/models/employee';
import { Farmer } from '../farmer/models/farmer';
@Injectable({
  providedIn: 'root'
})
export class OrderService {
  constructor(private http: HttpService) { }

  getOrders(): Observable<Order[]> {
    return this.http.get(`order`);
  }

  getOrderById(orderId: number): Observable<Order> {
    return this.http.get(`order/${orderId}`);
  }

  updateOrder(orderId: number, updatedOrder: Order): Observable<boolean> {
    return this.http.put(`order/${orderId}`, updatedOrder);
  }

  deleteOrder(orderId: number) {
    return this.http.delete(`order/${orderId}`);
  }

  createOrder(order: Order) {
    return this.http.post(`order`, order);
  }

  // getDetailByCouponId(couponId: number): Observable<Coupon[]> {
  //   return this.http.get(`milkcoupondetail/milkcoupon/${couponId}`);
  // }

  // createDetail(detail: Detail) {
  //   return this.http.post(`milkcoupondetail`, detail);
  // }

  // deleteCouponDetail(detailId: number){
  //   return this.http.delete(`milkcoupondetail/${detailId}`);
  // }

  // updateCouponDetail(detailId: number, updatedDetail: Detail): Observable<boolean> {
  //   return this.http.put(`milkcoupon/${detailId}`, updatedDetail);
  // }

  getEmployees(): Observable<Employee[]> {
    return this.http.get(`employee`);
  }

  getFarmers(): Observable<Farmer[]> {
    return this.http.get(`farmer`);
  }

  // getStations(): Observable<Station[]> {
  //   return this.http.get(`milkcollectionstation`);
  // }

  // getTanks(): Observable<StorageTank[]> {
  //   return this.http.get(`storagetank`);
  // }

  // updateStorageTank(storageTankId: number, updatedStorageTank: StorageTank): Observable<boolean> {
  //   return this.http.put(`storagetank/${storageTankId}`, updatedStorageTank);
  // }

  // getTankById(tankId: number): Observable<Coupon> {
  //   return this.http.get(`storagetank/${tankId}`);
  // }

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
