import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ExchangeComponent } from './components/exchange/exchange.component';
import { ExchangeRatesListComponent } from './components/exchange-rates-list/exchange-rates-list.component';
import { TopSectionComponent } from './components/top-section/top-section.component';

import { InputCurrencyFormatPipe } from './pipes/input-currency-format.pipe';
import { InputCurrencyDirective } from './directives/input-currency.directive';

import { ExchangeService } from './services/exchange.service';

@NgModule({
  declarations: [
    AppComponent,
    ExchangeComponent,
    ExchangeRatesListComponent,
    TopSectionComponent,
    InputCurrencyFormatPipe,
    InputCurrencyDirective
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    ExchangeService,
    InputCurrencyFormatPipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
