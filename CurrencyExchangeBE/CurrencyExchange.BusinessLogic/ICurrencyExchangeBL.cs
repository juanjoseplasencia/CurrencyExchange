using System;
using System.Collections.Generic;

namespace CurrencyExchange.BusinessLogic
{
    public interface ICurrencyExchangeBL
    {
        Dictionary<string, decimal> GetExchangeRates(string sourceCurrency, string targetCurrency, DateTime rateDate);
    }
}
