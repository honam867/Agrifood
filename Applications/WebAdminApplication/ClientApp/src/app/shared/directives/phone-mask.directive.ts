import { Directive, HostListener } from '@angular/core';
import { NgControl } from '@angular/forms';

@Directive({
    selector: '[appPhoneMask]',
})
export class PhoneMaskDirective {

    constructor(public ngControl: NgControl) { }

    @HostListener('ngModelChange', ['$event'])
    onModelChange(event) {
        let newVal = event.toString().replace(/\D/g, '');
        if (newVal.length === 0) {
            newVal = '';
        } else if (newVal.length <= 3) {
            newVal = newVal.replace(/^(\d{0,3})/, '$1');
        } else if (newVal.length <= 6) {
            newVal = newVal.replace(/^(\d{0,3})(\d{0,3})/, '$1$2');
        } else if (newVal.length <= 10) {
            newVal = newVal.replace(/^(\d{0,3})(\d{0,3})(\d{0,4})/, '$1$2$3');
        } else {
            newVal = newVal.substring(0, 10);
            newVal = newVal.replace(/^(\d{0,3})(\d{0,3})(\d{0,4})/, '$1$2$3');
        }
        this.ngControl.valueAccessor.writeValue(newVal);
    }
}
