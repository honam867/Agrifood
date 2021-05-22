import { DashBoardTotalCow } from './models/dashboardTotalCow';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from 'src/app/shared/services/http.service';
@Injectable({
  providedIn: 'root'
})
export class DashBoardService {
  constructor(private http: HttpService) { }
  getTotalCow(): Observable<DashBoardTotalCow> {
    return this.http.get(`dashboard/dashboardtotalcow`);
  }

}
