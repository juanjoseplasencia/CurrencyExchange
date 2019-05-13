using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CurrencyExchange.BusinessLogic;
using CurrencyExchange.Api.Models;
using CurrencyExchange.Api.Exceptions;

namespace CurrencyExchange.Api.Controllers.Test
{
    [TestClass]
    public class ExchangeRateControllerTests
    {
        private static Dictionary<string, decimal> GetRatesList()
        {
            return new Dictionary<string, decimal>
            {
                { "EUR" , 0.85M},
                { "PEN" , 3.30M},
                { "MXN" , 12000.00M}
            };
        }

        private static ICurrencyExchangeBL currencyExchangeBl;
        private static Mock<ICurrencyExchangeBL> mockCurrencyExchangeBlHappyPath;
        private static Mock<ICurrencyExchangeBL> mockCurrencyExchangeBlNotFound;

        private static void InitializeMocks()
        {
            mockCurrencyExchangeBlHappyPath = new Mock<ICurrencyExchangeBL>();
            mockCurrencyExchangeBlHappyPath.Setup(m => m.GetExchangeRates(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>())).Returns(GetRatesList);
            mockCurrencyExchangeBlNotFound = new Mock<ICurrencyExchangeBL>();
            mockCurrencyExchangeBlNotFound.Setup(m => m.GetExchangeRates(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>())).Returns(new Dictionary<string, decimal>());
        }

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            InitializeMocks();
        }

        [TestMethod]
        public void GetExchangeRates_HappyPath()
        {
            currencyExchangeBl = mockCurrencyExchangeBlHappyPath.Object;
            var controller = new ExchangeRateController(currencyExchangeBl);
            string sourceCurrency = "USD";
            string targetCurrency = "EUR";
            var result = controller.GetExchangeRates(sourceCurrency, targetCurrency);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<ExchangeRateResponse>));
            var content = (result as OkNegotiatedContentResult<ExchangeRateResponse>).Content;
            Assert.IsNotNull(content);
            Assert.IsInstanceOfType(content, typeof(ExchangeRateResponse));
            Assert.IsNotNull(content.Rates);
            Assert.AreEqual(GetRatesList().Count, content.Rates.Count);
        }

        [ExpectedException(typeof(ExchangeRatesNotFoundException))]
        [TestMethod]
        public void GetExchangeRates_NotFound()
        {
            currencyExchangeBl = mockCurrencyExchangeBlNotFound.Object;
            var controller = new ExchangeRateController(currencyExchangeBl);
            string sourceCurrency = "USD";
            string targetCurrency = "EUR";
            var exceptionMessage = string.IsNullOrEmpty(targetCurrency)
                ? $"No exchange rates found for currency {sourceCurrency}"
                : $"No exchange rate found from {sourceCurrency} to {targetCurrency}";
            var result = controller.GetExchangeRates(sourceCurrency, targetCurrency);
            Assert.ThrowsException<ExchangeRatesNotFoundException>(
                () => controller.GetExchangeRates(sourceCurrency), exceptionMessage);
        }

    }
}
