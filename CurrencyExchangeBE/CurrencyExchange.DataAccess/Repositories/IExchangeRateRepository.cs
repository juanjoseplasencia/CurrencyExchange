using System;
using System.Collections.Generic;
using CurrencyExchange.DataAccess.DataClasses;

namespace CurrencyExchange.DataAccess.Repositories
{
    public interface IExchangeRateRepository : IRepository<ExchangeRate>
    {
        IEnumerable<ExchangeRate> GetBySourceAndDate(string sourceCurrency, DateTime rateDate);
        IEnumerable<ExchangeRate> GetBySourceAndTargetAndDate(string sourceCurrency, string targetCurrency, DateTime rateDate);
    }
}
