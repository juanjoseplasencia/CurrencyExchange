import { Component, OnInit } from '@angular/core';
import { timer } from 'rxjs';
import { ExchangeRatePairs } from '../../models/exchange-rate-pairs';
import { ExchangeService } from '../../services/exchange.service';

@Component({
  selector: 'app-exchange-rates-list',
  templateUrl: './exchange-rates-list.component.html',
  styleUrls: ['./exchange-rates-list.component.css']
})
export class ExchangeRatesListComponent implements OnInit {
  private exchangeRatePairs: ExchangeRatePairs = {'EUR': 0.8}; // To avoid null object error
  private sourceCurrency = 'USD';
  private targetCurrency = 'EUR';

  constructor(private exchangeService: ExchangeService) { }

  ngOnInit() {
    this.loadExchangeRates();
    timer(1000 * 60 * 10, 1000 * 60 * 2).subscribe(() => this.loadExchangeRates());
  }

  loadExchangeRates() {
    this.exchangeService.getExchanges(this.sourceCurrency).subscribe(
      exrates => this.exchangeRatePairs = exrates
    );
  }

  keys(): Array<string> {
    return Object.keys(this.exchangeRatePairs).filter(rt => rt == this.targetCurrency);
  }
}
