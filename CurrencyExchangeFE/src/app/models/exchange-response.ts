import { ExchangeRatePairs } from './exchange-rate-pairs';

export class ExchangeResponse {
    base: string;
    date: string;
    rates: ExchangeRatePairs;
}
