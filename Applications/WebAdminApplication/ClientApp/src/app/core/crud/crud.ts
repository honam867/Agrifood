import { Observable } from 'rxjs';

export declare abstract class CRUDService<T> {
    get(id: number): Observable<any>;
    put(entity: T): Observable<any>;
    post(entity: T): Observable<any>;
    delete(id: number): Observable<any>;
}

export declare interface CRUD<T> {
    isCreate: boolean;
    isView: boolean;
    sourceView: T;
    source: T;

    create(): any;
    edit(): any;
    save(): any;
    discard(): any;
    exit(): any;
    delete(deleteId: number): any;

    beforeCreate(): any;
    beforeSave(): any;
    beforeDiscard(): any;
    afterCreate(): any;
    afterSave(): any;
    afterDiscard(): any;
}
