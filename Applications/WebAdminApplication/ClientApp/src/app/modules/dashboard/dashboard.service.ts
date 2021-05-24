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
}
