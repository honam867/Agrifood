import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from 'src/app/shared/services/http.service';
import { PermissionGroup } from '../models/permission-group';
import { PermissionGroupDetail } from '../models/permission-group-detail';
import { CRUDService } from 'src/app/core/crud/crud';

@Injectable({
    providedIn: 'root'
})

export class PermissionGroupService implements CRUDService<PermissionGroupDetail> {
    constructor(
        private http: HttpService,
    ) {
    }

    get(id: number): Observable<any> {
        return this.http.get(`permissiongroup/${id}`);
    }

    put(entity: PermissionGroupDetail): Observable<any> {
        return this.http.put(`permissiongroup/${entity.id}`, entity);
    }

    post(entity: PermissionGroupDetail): Observable<any> {
        return this.http.post(`permissiongroup`, entity);
    }

    delete(id: number): Observable<any> {
        return this.http.delete(`permissiongroup/${id}`);
    }

    getPermissionGroup(): Observable<PermissionGroup[]> {
        return this.http.get(`permissiongroup`);
    }
}
