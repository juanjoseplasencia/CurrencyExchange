using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CurrencyExchange.BusinessLogic;
using CurrencyExchange.Api.Models;
using CurrencyExchange.Api.Exceptions;
using CurrencyExchange.Api.Filters;


namespace CurrencyExchange.Api.Controllers
{
    [RoutePrefix("api/ExchangeRate")]
    public class ExchangeRateController : ApiController
    {
        private readonly ICurrencyExchangeBL _businessLogic;

        public ExchangeRateController(ICurrencyExchangeBL businessLogic) {
            _businessLogic = businessLogic;
        }

        // GET: api/ExchangeRate/exchangerates?sourceCurrency=USD
        // GET: api/ExchangeRate/exchangerates?sourceCurrency=USD&targetCurrency=EUR
        [Route("exchangerates")]
        [ResponseType(typeof(ExchangeRateResponse))]
        [ExchangeRatesExceptionFilter]
        public IHttpActionResult GetExchangeRates(string sourceCurrency, string targetCurrency = null)
        {
            DateTime today = DateTime.Today.Date;
            var exchangeRates = _businessLogic.GetExchangeRates(sourceCurrency, targetCurrency, today);
            if (exchangeRates.Count == 0)
            {
                var exceptionMessage = string.IsNullOrEmpty(targetCurrency)
                    ? $"No exchange rates found for currency {sourceCurrency}"
                    : $"No exchange rate found from {sourceCurrency} to {targetCurrency}";
                throw new ExchangeRatesNotFoundException(exceptionMessage);
            }

            var response = new ExchangeRateResponse
            {
                Base = sourceCurrency,
                Date = today.ToString("yyyy-MM-dd"),
                Rates = exchangeRates
            };

            return Ok(response);
        }
    }
}
