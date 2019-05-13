using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using CurrencyExchange.DataAccess.DataClasses;
using CurrencyExchange.DataAccess.DataContext;
using CurrencyExchange.DataAccess.Repositories;

namespace CurrencyExchange.DataAccess.Test
{
    [TestClass]
    public class QueryTests
    {
        private static DateTime today = DateTime.Today.Date;
        private static readonly IQueryable<ExchangeRate> mockData = new List<ExchangeRate>
            {
              new ExchangeRate {
                  SourceCurrency = "USD",
                  TargetCurrency = "EUR",
                  RateDate = new DateTime(2019, 5, 1),
                  RateValue =  0.85M
              },
              new ExchangeRate
              {
                  SourceCurrency = "USD",
                  TargetCurrency = "PEN",
                  RateDate = new DateTime(2019, 5, 1),
                  RateValue = 3.3M
              },
              new ExchangeRate
              {
                  SourceCurrency = "USD",
                  TargetCurrency = "MXN",
                  RateDate = new DateTime(2019, 5, 1),
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
              }
            }.AsQueryable();
        private static ICurrencyExchangeDbContext currencyExchangeDbContext;

        private static void InitializeMocks()
        {
            var mockContext = new Mock<ICurrencyExchangeDbContext>();
            var mockSet = new Mock<DbSet<ExchangeRate>>();
            mockSet.As<IQueryable<ExchangeRate>>().Setup(m => m.Provider).Returns(mockData.Provider);
            mockSet.As<IQueryable<ExchangeRate>>().Setup(m => m.Expression).Returns(mockData.Expression);
            mockSet.As<IQueryable<ExchangeRate>>().Setup(m => m.ElementType).Returns(mockData.ElementType);
            mockSet.As<IQueryable<ExchangeRate>>().Setup(m => m.GetEnumerator()).Returns(mockData.GetEnumerator());
            mockContext.Setup(c => c.ExchangeRates).Returns(mockSet.Object);
            currencyExchangeDbContext = mockContext.Object;
        }

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            InitializeMocks();
        }

        [TestMethod]
        public void GetAllExchangeRates()
        {
            var repository = new SqlExchangeRateRepository(currencyExchangeDbContext);
            var exchangeRates = repository.GetAll().ToList();

            Assert.AreEqual(6, exchangeRates.Count);
            Assert.AreEqual("USD", exchangeRates[0].SourceCurrency);
            Assert.AreEqual("PEN", exchangeRates[1].TargetCurrency);
            Assert.AreEqual("USD", exchangeRates[2].SourceCurrency);
            Assert.AreEqual("EUR", exchangeRates[3].TargetCurrency);
            Assert.AreEqual("USD", exchangeRates[4].SourceCurrency);
            Assert.AreEqual("MXN", exchangeRates[5].TargetCurrency);

        }

        [TestMethod]
        public void GetExchangeRatesBySourceAndDate()
        {
            var sourceCurrency = "USD";
            var repository = new SqlExchangeRateRepository(currencyExchangeDbContext);
            var exchangeRates = repository.GetBySourceAndDate(sourceCurrency, today).ToList();

            Assert.AreEqual(3, exchangeRates.Count);
            Assert.IsTrue(exchangeRates.All(E => E.SourceCurrency == sourceCurrency));
            Assert.IsTrue(exchangeRates.All(E => E.RateDate == today));
        }

        [TestMethod]
        public void GetExchangeRatesBySourceAndTargetAndDate()
        {
            var sourceCurrency = "USD";
            var targetCurrency = "EUR";
            var repository = new SqlExchangeRateRepository(currencyExchangeDbContext);
            var exchangeRates = repository.GetBySourceAndTargetAndDate(sourceCurrency, targetCurrency, today).ToList();

            Assert.AreEqual(1, exchangeRates.Count);
            Assert.IsTrue(exchangeRates.All(E => E.SourceCurrency == sourceCurrency));
            Assert.IsTrue(exchangeRates.All(E => E.TargetCurrency == targetCurrency));
            Assert.IsTrue(exchangeRates.All(E => E.RateDate == today));
        }
    }
}
