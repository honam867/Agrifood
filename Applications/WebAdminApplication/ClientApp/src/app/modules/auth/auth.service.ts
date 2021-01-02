import { EMPLOYEEINFO, ROLES, USERINFO } from './../../shared/constant';
import { Injectable, isDevMode } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import decode from 'jwt-decode';
import { HttpService } from 'src/app/shared/services/http.service';
import { GlobalConfig } from 'src/app/shared/global-config';
import { PERMISSION } from 'src/app/shared/constant';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(
    private http: HttpService,
    private router: Router,
    private jwtHelper: JwtHelperService
  ) { }

  signIn(formData: any): Observable<any> {
    return this.http.post(`auth/signin`, formData);
  }

  forgotPassword(formData: any): Observable<any> {
    return this.http.post(`auth/forgotpassword`, formData);

  }

  resetPassword(formData: any): Observable<any> {
    return this.http.put(`auth/resetpassword`, formData);
  }

  logout() {
    if (localStorage.getItem(environment.tokenKey)) {
      localStorage.removeItem(environment.tokenKey);
    }
    this.router.navigate(['auth/signin']);
  }

  isSignin() {
    const token = localStorage.getItem(environment.tokenKey);
    // Check whether the token is expired and return
    // true or false
    if (token != null && token !== 'undefined') {
      const tokenKey = JSON.parse(token);
      const currentToken = tokenKey.access_token;
      if (this.jwtHelper.isTokenExpired(currentToken)) {
        localStorage.removeItem(environment.tokenKey);
      }
      return !this.jwtHelper.isTokenExpired(currentToken);
    }
    return false;
  }

  storageUserInfo() {
    const token = localStorage.getItem(environment.tokenKey);
    const tokenPayload = decode(token);
    localStorage.setItem(USERINFO, tokenPayload.userInfo);
  }


  // storageRoles() {
  //   const token = localStorage.getItem(environment.tokenKey);
  //   const tokenPayload = decode(token);
  //   const roles = Object.values(tokenPayload);
  //   const listRoles = { roles: roles[1] }
  //   localStorage.setItem(ROLES, JSON.stringify(listRoles.roles));
  // }
  // storagePermission() {
  //   const token = localStorage.getItem(environment.tokenKey);
  //   const tokenPayload = decode(token);
  //   localStorage.setItem(PERMISSION, tokenPayload.permission);
  // }

  changePassword(formData: any): Observable<any> {
    return this.http.put(`auth/changepassword`, formData);
  }

  importMenuDeFault() {
    return this.http.postNotBody(`menu/insertdefault`);
  }
  importMenuRoleSysterm() {
    return this.http.postNotBody(`menurolepermission/addtoadmin`);
  }

  getAvatarUrl(): string {
    const token = localStorage.getItem(environment.tokenKey);
    const tokenPayload = decode(token);
    return tokenPayload.avatarURL;
  }
}
