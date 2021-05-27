import { UsingData } from './models/usingData';
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
  getTotalCowByFarmerId(farmerId: number): Observable<DashBoardTotalCow> {
    return this.http.get(`dashboard/dashboardtotalcow/${farmerId}`);
  }
  getTotalOrderFoodBytime(startDate: string, endDate: string): Observable<OrderFood[]>{
    return this.http.get(`dashboard/orderfood/${startDate}/${endDate}`);
  }
  getTotalOrderFoodByTimeAndFarmerId(startDate: string, endDate: string, farmerId: number): Observable<OrderFood[]>{
    return this.http.get(`dashboard/orderfood/${startDate}/${endDate}/${farmerId}`);
  }
  getMilkingSlip(startDate: string, endDate: string): Observable<MilkingSlip[]> {
    return this.http.get(`dashboard/milkingslip/${startDate}/${endDate}`);
  }
  getMilkingSlipByFarmerId(startDate: string, endDate: string, farmerId: number): Observable<MilkingSlip[]> {
    return this.http.get(`dashboard/milkingslip/${startDate}/${endDate}/${farmerId}`);
  }
  getMilkCoupon(startDate: string, endDate: string): Observable<MilkCoupon[]> {
    return this.http.get(`dashboard/milkcoupon/${startDate}/${endDate}`);
  }
  getMilkCouponByFarmerId(startDate: string, endDate: string, farmerId: number): Observable<MilkCoupon[]> {
    return this.http.get(`dashboard/milkcoupon/${startDate}/${endDate}/${farmerId}`);
  }
  getUsingDataByYear(year: number): Observable<UsingData[]> {
    return this.http.get(`dashboard/using/${year}`);
  }
  getUsingDataByYearAndFarmerId(year: number, farmerId: number): Observable<UsingData[]> {
    return this.http.get(`dashboard/using/${year}/${farmerId}`);
  }
}
