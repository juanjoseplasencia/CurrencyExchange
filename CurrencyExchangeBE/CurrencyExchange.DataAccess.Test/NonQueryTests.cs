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
    public class NonQueryTests
    {
        [TestMethod]
        public void CreateExchangeRate()
        {
            var exchangeRate = new ExchangeRate
            {
                SourceCurrency = "USD",
                TargetCurrency = "EUR",
                RateDate = DateTime.Today.Date,
                RateValue = 0.85M
            };

            var mockContext = new Mock<ICurrencyExchangeDbContext>();

            var mockSet = new Mock<DbSet<ExchangeRate>>();

            mockContext.Setup(m => m.ExchangeRates).Returns(mockSet.Object);

            var repository = new SqlExchangeRateRepository(mockContext.Object);
            repository.Add(exchangeRate);

            mockSet.Verify(m => m.Add(It.IsAny<ExchangeRate>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

    }
}
