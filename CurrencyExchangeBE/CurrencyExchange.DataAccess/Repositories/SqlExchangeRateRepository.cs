using System;
using System.Collections.Generic;
using System.Linq;
using CurrencyExchange.DataAccess.DataClasses;
using CurrencyExchange.DataAccess.DataContext;

namespace CurrencyExchange.DataAccess.Repositories
{
    public class SqlExchangeRateRepository : IExchangeRateRepository
    {
        private readonly ICurrencyExchangeDbContext _dbContext;

        public SqlExchangeRateRepository(ICurrencyExchangeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public SqlExchangeRateRepository()
        {
            _dbContext = new CurrencyExchangeDbContext();
        }

        private IQueryable<ExchangeRate> GetQueryForAll()
        {
            return _dbContext.ExchangeRates;
        }

        public IEnumerable<ExchangeRate> GetAll()
        {
            return GetQueryForAll().AsEnumerable();
        }

        public IEnumerable<ExchangeRate> GetBySourceAndDate(string sourceCurrency, DateTime rateDate)
        {
            return GetQueryForAll().Where(
                E => E.RateDate == rateDate &&
                E.SourceCurrency == sourceCurrency);
        }

        public IEnumerable<ExchangeRate> GetBySourceAndTargetAndDate(string sourceCurrency, string targetCurrency, DateTime rateDate)
        {
            return GetQueryForAll().Where(
                E => E.RateDate == rateDate &&
                E.SourceCurrency == sourceCurrency &&
                E.TargetCurrency == targetCurrency);
        }
        public ExchangeRate Add(ExchangeRate exchangeRate)
        {
            var exchangeRateEntity = _dbContext.ExchangeRates.Add(exchangeRate);
            _dbContext.SaveChanges();
            return exchangeRateEntity;
        }

    }
}
