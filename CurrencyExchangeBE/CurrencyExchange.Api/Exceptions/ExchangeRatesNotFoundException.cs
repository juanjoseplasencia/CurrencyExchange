using System;

namespace CurrencyExchange.Api.Exceptions
{
    public class ExchangeRatesNotFoundException : Exception
    {
        public ExchangeRatesNotFoundException(string message) : base(message)
        {

        }
    }
}