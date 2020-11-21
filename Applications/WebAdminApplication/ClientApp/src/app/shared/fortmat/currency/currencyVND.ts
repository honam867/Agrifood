import { CurrencyPipe } from '@angular/common';
import { Injectable } from '@angular/core';
@Injectable({
  providedIn: 'root'
})
export class CurrencyVND {
  currency: any;
  constructor(private currencyPipe: CurrencyPipe) {

  }
  formatToVND(value: any) {
    this.currency = this.currencyPipe.transform(value, 'VND', '');
    return this.currency;
  }
}
