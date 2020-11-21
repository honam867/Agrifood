import { CRUD, CRUDService } from './crud';
import { MatDialog, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Inject } from '@angular/core';
import { StatusForm } from 'src/app/shared/enum/status-form';
import { ConfirmationComponent } from 'src/app/shared/components/confirmation/confirmation.component';

export abstract class BaseCRUDDialog<T> implements CRUD<T> {
    isCreate: boolean;
    isView: boolean;
    sourceView: T;
    source: T;

    constructor(
        protected dialog: MatDialog,
        protected dialogRef: MatDialogRef<any>,
        @Inject(MAT_DIALOG_DATA) public data: any,
        protected service: CRUDService<T>
    ) {
        this.isView = this.data.action === StatusForm.VIEW;
        this.isCreate = this.data.action === StatusForm.CREATE;
        if (data.id) {

            this.service.get(data.id).subscribe(
                result => {

                    this.source = result;
                    this.sourceView = Object.assign({}, this.source);
                }
            );
        }
    }

    beforeCreate() { }
    beforeSave() { }
    beforeDiscard() { }
    afterCreate() { }
    afterSave() { }
    afterDiscard() { }

    create() {
        this.beforeCreate();
        this.service.post(this.sourceView).subscribe(result => {
            this.dialogRef.close({
                data: result
            });
            this.afterCreate();
        });
    }

    edit() {
        this.isView = false;
    }

    save() {
        this.beforeSave();
        this.service.put(this.sourceView).subscribe(
            result => {
                this.isView = true;
                this.source = Object.assign({}, this.sourceView);
                this.afterSave();
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
    }

    delete(deleteId: number) {
        const deleteDialog = this.dialog.open(ConfirmationComponent, {
            data: {
                message: 'Bạn có muốn xóa?',
            },
            disableClose: true,
        });

        deleteDialog.afterClosed().subscribe(
            result => {
                if (result.confirmed) {
                    this.service.delete(deleteId).subscribe(
                        rs => {
                            this.dialogRef.close({
                                action: StatusForm.DETELE,
                                id: deleteId,
                            });
                        }
                    );
                }
            }
        );
    }

    close() {
        this.dialogRef.close({
            action: StatusForm.VIEW,
            data: this.source
        });
    }

}
