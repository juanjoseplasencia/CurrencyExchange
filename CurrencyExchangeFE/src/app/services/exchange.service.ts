import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs'; // RxJS v6+
import { of } from 'rxjs'; // RxJS v6+
import { catchError, map } from 'rxjs/operators';
import { ExchangeResponse } from '../models/exchange-response';
import { ExchangeRatePairs } from '../models/exchange-rate-pairs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ExchangeService {
  private endpoint = `${environment.apiUrl}/ExchangeRate/exchangerates?`;
  constructor(private httpService: HttpClient) { }

  getExchange(inputCurrency: string, outputCurrency: string): Observable<number> {
    const exchangeEndPoint = this.endpoint + `sourceCurrency=${inputCurrency}&targetCurrency=${outputCurrency}`;
    return this.httpService.get<ExchangeResponse>(exchangeEndPoint)
    .pipe(
      map((response) => response.rates[outputCurrency]),
      catchError(this.handleError<number>('exchange', 0))
    );
  }

  getExchanges(inputCurrency: string): Observable<ExchangeRatePairs> {
    const exchangeEndPoint = this.endpoint + `sourceCurrency=${inputCurrency}`;
    return this.httpService.get<ExchangeResponse>(exchangeEndPoint)
      .pipe(
        map((response) => response.rates),
        catchError(this.handleError<ExchangeRatePairs>('exchanges', {}))
      );
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
       console.log(error.error);
      return of(result as T);
    };
  }

}
