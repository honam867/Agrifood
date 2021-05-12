import { Province } from './../province/models/province';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { HttpService } from 'src/app/shared/services/http.service';
import { Station } from './models/station';
import { District } from 'src/app/models/district';
@Injectable({
  providedIn: 'root'
})
export class StationService {
  constructor(private http: HttpService) { }

  getStations(): Observable<Station[]> {
    return this.http.get(`milkcollectionstation`);
  }

  getStationById(stationId: number): Observable<Station> {
    return this.http.get(`milkcollectionstation/${stationId}`);
  }

  updateStation(stationId: number, updatedStation: Station): Observable<boolean> {
    return this.http.put(`milkcollectionstation/${stationId}`, updatedStation);
  }

  deleteStation(stationId: number) {
    return this.http.delete(`milkcollectionstation/${stationId}`);
  }

  createStation(station: Station) {
    return this.http.post(`milkcollectionstation`, station);
  }

  getProvince(): Observable<Province[]> {
    return this.http.get(`province`)
  }
  getDistrictByProvinceId(provinceId: number): Observable<District[]> {
    return this.http.get(`district/provinceId/${provinceId}`);
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
