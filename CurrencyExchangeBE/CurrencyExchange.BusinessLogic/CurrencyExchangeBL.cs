using System;
using System.Collections.Generic;
using System.Linq;
using CurrencyExchange.DataAccess.Repositories;

namespace CurrencyExchange.BusinessLogic
{
    public class CurrencyExchangeBL : ICurrencyExchangeBL
    {
        private readonly IExchangeRateRepository _repository;

        public CurrencyExchangeBL(IExchangeRateRepository repository)
        {
            _repository = repository;
        }

        public Dictionary<string, decimal> GetExchangeRates(string sourceCurrency, string targetCurrency, DateTime rateDate)
        {
            var rateValues = string.IsNullOrEmpty(targetCurrency)
                ? _repository.GetBySourceAndDate(sourceCurrency, rateDate)
                : _repository.GetBySourceAndTargetAndDate(sourceCurrency, targetCurrency, rateDate);
            Dictionary<string, decimal> returnValues = new Dictionary<string, decimal>();
            rateValues.ToList().ForEach((E) =>
            {
                returnValues.Add(E.TargetCurrency, E.RateValue);
            });

            return returnValues;
        }

    }
}
