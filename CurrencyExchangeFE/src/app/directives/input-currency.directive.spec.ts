import { InputCurrencyDirective } from './input-currency.directive';
import {ElementRef} from '@angular/core';
import {InputCurrencyFormatPipe} from '../pipes/input-currency-format.pipe';

describe('InputCurrencyDirective', () => {
  it('should create an instance', () => {
    const directive = new InputCurrencyDirective(new InputCurrencyFormatPipe(),
    new ElementRef(null));
    expect(directive).toBeTruthy();
  });
});
