import { CRUD, CRUDService } from './crud';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { StatusForm } from 'src/app/shared/enum/status-form';
import { ConfirmationComponent } from 'src/app/shared/components/confirmation/confirmation.component';
import { PREVIOUS_URL } from 'src/app/shared/constant';
import { OnInit } from '@angular/core';

export abstract class BaseCRUDPage<T> implements CRUD<T>, OnInit {
    isCreate: boolean;
    isView: boolean;
    id: number;
    sourceView: T;
    source: T;
    constructor(
        protected route: ActivatedRoute,
        protected router: Router,
        protected dialog: MatDialog,
        protected service: CRUDService<T>
    ) {
    }

    ngOnInit() {
        this.route.queryParams.subscribe(
            queryParams => {
                this.isView = queryParams.action.toUpperCase() === StatusForm[StatusForm.VIEW];
                this.isCreate = queryParams.action.toUpperCase() === StatusForm[StatusForm.CREATE];
            }
        );
        this.route.params.subscribe(
            params => {
                if (params.id > 0) {
                    this.id = params.id;
                    this.service.get(this.id).subscribe(
                        result => {
                            this.source = result;
                            this.sourceView = Object.assign({}, this.source);
                            this.afterLoadData();
                        }
                    );
                }
            }
        );
    }

    afterLoadData() { }
    beforeCreate() { }
    beforeSave() { }
    beforeDiscard() { }
    afterCreate() { }
    afterSave() { }
    afterDiscard() { }
    create() {
        this.beforeCreate();
        this.service.post(this.sourceView).subscribe(
            result => {
                this.afterCreate();
                this.router.navigate([localStorage.getItem(PREVIOUS_URL)]);
            }
        );
    }

    edit() {
        this.isView = false;
    }

    save() {
        this.beforeSave();
        this.service.put(this.sourceView).subscribe(
            result => {
                if (result) {
                    this.isView = true;
                    this.afterSave();
                }
            }
        );
    }

    discard() {
        this.beforeDiscard();
        this.isView = true;
        this.sourceView = Object.assign({}, this.source);
        this.afterDiscard();
    }

    exit() {
        const exitDialog = this.dialog.open(ConfirmationComponent, {
            data: {
                message: 'Bạn có muốn thoát?'
            },
            disableClose: true
        });

        exitDialog.afterClosed().subscribe(result => {
            if (result.confirmed) {
                if (localStorage.getItem(PREVIOUS_URL)) {
                    this.router.navigate([localStorage.getItem(PREVIOUS_URL)]);
                } else {
                    this.router.navigate(['']);
                }
            }
        });
    }

    delete(deleteId: number) {
        const deleteDialog = this.dialog.open(ConfirmationComponent, {
            data: {
                message: 'Toàn bộ dữ liệu của bạn sẽ bị mất. Bạn có muốn xóa?'
            },
            disableClose: true
        });
        deleteDialog.afterClosed().subscribe(result => {
            if (result.confirmed) {
                this.service.delete(deleteId).subscribe(
                    deleteResult => {
                        if (deleteResult.value) {
                            if (localStorage.getItem(PREVIOUS_URL)) {
                                this.router.navigate([localStorage.getItem(PREVIOUS_URL)]);
                            } else {
                                this.router.navigate(['']);
                            }
                        }
                    }
                );
            }
        });
    }
}
