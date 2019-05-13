using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data.Entity.ModelConfiguration.Conventions;
using CurrencyExchange.DataAccess.DataClasses;

namespace CurrencyExchange.DataAccess.DataContext
{
    [DbConfigurationType(typeof(CurrencyExchangeDbConfiguration))]
    public class CurrencyExchangeDbContext : DbContext, ICurrencyExchangeDbContext
    {
        public CurrencyExchangeDbContext() : base("CurrencyExchangeDbContext") {
            Database.SetInitializer(new CurrencyExchangeDbInitializer());
        }

        public virtual DbSet<ExchangeRate> ExchangeRates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder); //
        }
    }

    internal class CurrencyExchangeDbConfiguration : DbConfiguration
    {
        public CurrencyExchangeDbConfiguration()
        {
            this.SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
        }
    }

}
