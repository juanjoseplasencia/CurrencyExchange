using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using CurrencyExchange.DataAccess.DataClasses;

namespace CurrencyExchange.DataAccess.DataContext
{
    internal class CurrencyExchangeDbInitializer : DropCreateDatabaseIfModelChanges<CurrencyExchangeDbContext>
    {
        protected override void Seed(CurrencyExchangeDbContext context) {
            var today = DateTime.Today.Date;
            var beforeToday = today.AddDays(-1);
            var dayBeforeToday = today.AddDays(-2);
            var tomorrow = today.AddDays(1);
            var dayAfterTomorrow = today.AddDays(2);

            var exchangeRatesList = new List<ExchangeRate>()
            {
              new ExchangeRate
              {
                  SourceCurrency = "USD",
                  TargetCurrency = "EUR",
                  RateDate = dayBeforeToday,
                  RateValue = 0.82M
              },
              new ExchangeRate
              {
                  SourceCurrency = "USD",
                  TargetCurrency = "PEN",
                  RateDate = dayBeforeToday,
                  RateValue = 3.32M
              },
              new ExchangeRate
              {
                  SourceCurrency = "USD",
                  TargetCurrency = "MXN",
                  RateDate = dayBeforeToday,
                  RateValue = 11200M
              },
              new ExchangeRate
              {
                  SourceCurrency = "USD",
                  TargetCurrency = "EUR",
                  RateDate = beforeToday,
                  RateValue = 0.85M
              },
              new ExchangeRate
              {
                  SourceCurrency = "USD",
                  TargetCurrency = "PEN",
                  RateDate = beforeToday,
                  RateValue = 3.3M
              },
              new ExchangeRate
              {
                  SourceCurrency = "USD",
                  TargetCurrency = "MXN",
                  RateDate = beforeToday,
                  RateValue = 12000M
              },
              new ExchangeRate
              {
                  SourceCurrency = "USD",
                  TargetCurrency = "EUR",
                  RateDate = today,
                  RateValue = 0.86M
              },
              new ExchangeRate
              {
                  SourceCurrency = "USD",
                  TargetCurrency = "PEN",
                  RateDate = today,
                  RateValue = 3.31M
              },
              new ExchangeRate
              {
                  SourceCurrency = "USD",
                  TargetCurrency = "MXN",
                  RateDate = today,
                  RateValue = 11500M
              },
              new ExchangeRate
              {
                  SourceCurrency = "USD",
                  TargetCurrency = "EUR",
                  RateDate = tomorrow,
                  RateValue = 0.82M
              },
              new ExchangeRate
              {
                  SourceCurrency = "USD",
                  TargetCurrency = "PEN",
                  RateDate = tomorrow,
                  RateValue = 3.32M
              },
              new ExchangeRate
              {
                  SourceCurrency = "USD",
                  TargetCurrency = "MXN",
                  RateDate = tomorrow,
                  RateValue = 11200M
              },
              new ExchangeRate
              {
                  SourceCurrency = "USD",
                  TargetCurrency = "EUR",
                  RateDate = dayAfterTomorrow,
                  RateValue = 0.815M
              },
              new ExchangeRate
              {
                  SourceCurrency = "USD",
                  TargetCurrency = "PEN",
                  RateDate = dayAfterTomorrow,
                  RateValue = 3.315M
              },
              new ExchangeRate
              {
                  SourceCurrency = "USD",
                  TargetCurrency = "MXN",
                  RateDate = dayAfterTomorrow,
                  RateValue = 11300M
              }

            };
            context.ExchangeRates.AddRange(exchangeRatesList);
            base.Seed(context);
        }
    }
}
