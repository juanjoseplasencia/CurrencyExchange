import { Component, OnInit } from '@angular/core';
import { timer } from 'rxjs';
import { Money } from '../../models/money';
import { ExchangeService } from '../../services/exchange.service';

@Component({
  selector: 'app-exchange',
  templateUrl: './exchange.component.html',
  styleUrls: ['./exchange.component.css']
})
export class ExchangeComponent implements OnInit {
  private sourceMoney: Money = new Money(0, 'USD');
  private targetMoney: Money = new Money(0, 'EUR');

  constructor(private exchangeService: ExchangeService) { }

  ngOnInit() {
    timer(1000 * 60 * 10, 1000 * 60 * 2).subscribe(() => this.calculate());  
  }

  calculate() {
    this.exchangeService.getExchange(this.sourceMoney.currency, this.targetMoney.currency)
    .subscribe((exchange: number) => this.targetMoney.amount = exchange * this.sourceMoney.amount);
  }
}
