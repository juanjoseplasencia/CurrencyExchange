using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using CurrencyExchange.Api.Exceptions;

namespace CurrencyExchange.Api.Filters
{
    public class ExchangeRatesExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var filteredException = actionExecutedContext.Exception;
            if (filteredException is ExchangeRatesNotFoundException)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent((filteredException as ExchangeRatesNotFoundException).Message)
                };
                actionExecutedContext.Response = response;
            }
        }
    }
}