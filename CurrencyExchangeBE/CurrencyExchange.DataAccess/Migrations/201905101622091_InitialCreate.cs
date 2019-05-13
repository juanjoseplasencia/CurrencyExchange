namespace CurrencyExchange.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExchangeRate",
                c => new
                    {
                        ExchangeRateId = c.Int(nullable: false, identity: true),
                        SourceCurrency = c.String(),
                        TargetCurrency = c.String(),
                        RateDate = c.DateTime(nullable: false),
                        RateValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ExchangeRateId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExchangeRate");
        }
    }
}
