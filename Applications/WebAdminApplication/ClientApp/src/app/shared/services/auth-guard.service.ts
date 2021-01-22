import { AuthService } from 'src/app/modules/auth/auth.service';
import { Injectable } from '@angular/core';
import { CanActivate, CanActivateChild, CanLoad, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate, CanActivateChild, CanLoad {
  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  // canActivate() {
  //   const test = this.authService.storagePermission();
  //   console.log("🚀 ~ file: auth-guard.service.ts ~ line 15 ~ AuthGuard ~ canActivate ~ test", JSON.parse(test.farmerPermission))
  //   console.log(typeof (test))

  //   console.log('i am checking to see if you are logged in');
  //   return true;
  // }

  canActivate() {
    const getPermissionFarmerFromDecodeToken = this.authService.storagePermission();
    const test = getPermissionFarmerFromDecodeToken.roles;
    if (test.includes("Admin" || "SysAdmin")) {
      return true;
    } else {
      return this.router.navigate(['error-page']);
    }
  }

  canLoad() {
    const getPermissionFarmerFromDecodeToken = this.authService.storagePermission();
    const accessFarmer = JSON.parse(getPermissionFarmerFromDecodeToken.farmerPermission);
    if (JSON.parse(accessFarmer.CanAccessFarmer)) {
      return true
    } else {
      return this.router.navigate(['error-page']);
    }
  }

  canActivateChild() {
    return true;
  }

}
