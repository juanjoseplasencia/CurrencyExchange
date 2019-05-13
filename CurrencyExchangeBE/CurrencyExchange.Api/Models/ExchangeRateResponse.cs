using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CurrencyExchange.Api.Models
{
    [DataContract]
    public class ExchangeRateResponse
    {
        [DataMember(Name = "base")]
        public string Base { get; set; }

        [DataMember(Name = "date")]
        public string Date { get; set; }

        [DataMember(Name = "rates")]
        public Dictionary<string, decimal> Rates { get; set; }
    }
}