import { Farmer } from 'src/app/modules/farmer/models/farmer';
import { MilkCoupon } from './models/milkCoupon';
import { MilkingSlip } from './models/milkingSlip';
import { DashBoardTotalCow } from './models/dashboardTotalCow';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from 'src/app/shared/services/http.service';
import { OrderFood } from './models/orderFood';
@Injectable({
  providedIn: 'root'
})
export class DashBoardService {
  constructor(private http: HttpService) { }
  getTotalCow(): Observable<DashBoardTotalCow> {
    return this.http.get(`dashboard/dashboardtotalcow`);
  }
  getTotalOrderFoodBytime(startDate: string, endDate: string): Observable<OrderFood[]>{
    return this.http.get(`dashboard/orderfood/${startDate}/${endDate}`);
  }
  getMilkingSlip(startDate: string, endDate: string): Observable<MilkingSlip[]> {
    return this.http.get(`dashboard/milkingslip/${startDate}/${endDate}`);
  }
  getMilkCoupon(startDate: string, endDate: string): Observable<MilkCoupon[]> {
    return this.http.get(`dashboard/milkcoupon/${startDate}/${endDate}`);
  }
  getMilkCouponByFarmerId(startDate: string, endDate: string, farmerId: number): Observable<MilkCoupon[]> {
    return this.http.get(`dashboard/milkcoupon/${startDate}/${endDate}/${farmerId}`);
  }
  getFarmers(): Observable<Farmer[]> {
    return this.http.get(`farmer`);
  }
}
