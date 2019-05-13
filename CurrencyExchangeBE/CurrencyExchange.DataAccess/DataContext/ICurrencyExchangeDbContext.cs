using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using CurrencyExchange.DataAccess.DataClasses;

namespace CurrencyExchange.DataAccess.DataContext
{
    public interface ICurrencyExchangeDbContext
    {
        DbSet<ExchangeRate> ExchangeRates { get; set; }
        int SaveChanges();
    }
}
