import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
declare var $: any;
@Injectable({
    providedIn: 'root'
})
export class Notification {
    constructor(
        private snackBar: MatSnackBar,
    ) { }
    openSnackBar(message: string, action: string) {
        this.snackBar.open(message, action, {
            duration: 4000,
            verticalPosition: 'top'
        });
    }
    MessageCreated() {
        this.openSnackBar('Đã thêm thành công!', 'Tắt');
    }
    MessageUpdated() {
        this.openSnackBar('Đã cập nhật thành công!', 'Tắt');
    }
    MessageDeleted() {
        this.openSnackBar('Đã xóa thành công!', 'Tắt');
    }

    showNotification(type: string, from: any, align: any, message: string) {
        // const type = ['info', 'success', 'warning', 'danger'];
        $.notify({
            icon: "notifications",
            message: message

        }, {
            type: type,
            timer: 3000,
            placement: {
                from: from,
                align: align
            },
            template: '<div data-notify="container" class="col-xl-4 col-lg-4 col-11 col-sm-4 col-md-4 alert alert-{0} alert-with-icon" role="alert">' +
                '<button mat-button  type="button" aria-hidden="true" class="close mat-button" data-notify="dismiss">  <i class="material-icons">close</i></button>' +
                '<i class="material-icons" data-notify="icon">notifications</i> ' +
                '<span data-notify="title">{1}</span> ' +
                '<span data-notify="message">{2}</span>' +
                '<div class="progress" data-notify="progressbar">' +
                '<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
                '</div>' +
                '<a href="{3}" target="{4}" data-notify="url"></a>' +
                '</div>'
        });
    }
}
