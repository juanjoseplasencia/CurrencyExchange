using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using CurrencyExchange.DataAccess.DataContext;

namespace CurrencyExchange.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CurrencyExchangeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CurrencyExchangeDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // To be updated/used for seed/update data ONCE the database changes are managed by migrations only,
            // probably after a first deployment to production 
        }
    }
}
