import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from 'src/app/shared/services/http.service';
import { User } from './models/user';
import { RoleOfUser } from './models/roleofuser';
import { Role } from './models/role';
import { RqListRole } from './models/RqListRoles';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpService) { }

  getUsers(): Observable<User[]> {
    return this.http.get(`user`);
  }

  getUserById(userId: number): Observable<User> {
    return this.http.get(`user/${userId}`);
  }

  updateUser(userId: number, updatedUser: User): Observable<boolean> {
    return this.http.put(`user/${userId}`, updatedUser);
  }

  deleteUser(userId: number) {
    return this.http.delete(`user/${userId}`);
  }

  createUser(user: User) {
    return this.http.post(`user`, user);
  }
  getRoleByUser(userId: number): Observable<User[]> {
    return this.http.get(`user/role/${userId}`);
  }
  addRolesOfUser(rqrole: RqListRole) {
    return this.http.post(`user/addlistrole`, rqrole);
  }
  deleteRoleOfUser(userId: number, role: string) {
    return this.http.delete(`user/${userId}/${role}`);
  }
  // role
  getRoles(): Observable<RoleOfUser[]> {
    return this.http.get(`role`);
  }
  getRoleNotExist(userId: number): Observable<Role[]> {
    return this.http.get(`role/rolenotexists/${userId}`);
  }
  checkEmailExist(email: string): Observable<any> {
    return this.http.get(`user/emailchecking/${email}`);
  }

}
