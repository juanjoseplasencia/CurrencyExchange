import {Directive, ElementRef, HostListener, Input} from '@angular/core';
import {InputCurrencyFormatPipe} from '../pipes/input-currency-format.pipe';

@Directive({
  selector: '[appInputCurrency]'
})
export class InputCurrencyDirective {
  private inputElement: HTMLInputElement;
  @Input('currency') currency: string;

  constructor(private currencyFormatPipe: InputCurrencyFormatPipe, private elementRef: ElementRef) {
    this.inputElement = this.elementRef.nativeElement;
  }

  @HostListener('focus', ['$event.target.value'])
  onFocus(value) {
    this.inputElement.value = '';
  }

  @HostListener('blur', ['$event.target.value'])
  onBlur(value) {
    this.inputElement.value = this.currencyFormatPipe.transform(value, this.currency);
  }

}
