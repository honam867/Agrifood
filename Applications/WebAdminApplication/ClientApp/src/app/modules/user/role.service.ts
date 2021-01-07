import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { HttpService } from 'src/app/shared/services/http.service';
import { Role } from './models/role';

@Injectable({
    providedIn: 'root'
})
export class RoleService {
    constructor(private http: HttpService, private router: Router) { }

    getRoles(): Observable<Role[]> {
        return this.http.get(`role`);
    }
}
