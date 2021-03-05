// import { Employee } from './models/employee';
import { ValueObject } from './../../shared/models/value-object';
// import { Food } from './../../models/food';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { HttpService } from 'src/app/shared/services/http.service';
import { Food } from './models/food';
import { Province } from '../province/models/province';
// import {RoleOfUser} from './models/roleofUser';
// import {Role} from '../system/models/role';
// import { RqListRole } from 'src/app/shared/models/RqListRoles';
@Injectable({
  providedIn: 'root'
})
export class FoodService {
  constructor(private http: HttpService) { }
  getFoods(): Observable<Food[]> {
    return this.http.get(`food`);
  }

  getFoodById(foodId: number): Observable<Food> {
    return this.http.get(`food/${foodId}`);
  }

  updateFood(foodId: number, updatedFood: Food): Observable<boolean> {
    return this.http.put(`food/${foodId}`, updatedFood);
  }

  createFood(food: Food) {
    return this.http.post(`food`, food);
  }

  deleteFood(id: number) {
    return this.http.delete(`food/${id}`);
  }

  getProvinces(): Observable<Province[]> {
    return this.http.get(`province`);
  }


}
