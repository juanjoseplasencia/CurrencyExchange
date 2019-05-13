using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyExchange.DataAccess.DataClasses
{
    public class ExchangeRate
    {
        public int ExchangeRateId { get; set; }

        public string SourceCurrency { get; set; }

        public string TargetCurrency { get; set; }

        public DateTime RateDate { get; set; }

        public decimal RateValue { get; set; }
    }
}
