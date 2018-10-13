namespace BoVoyage.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TravelWithoutUnique : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Insurances", "IX_PriceType");
            DropIndex("dbo.Travels", "IX_DatesPriceTravelAgencyDestination");
            CreateIndex("dbo.Insurances", "InsuranceTypeID");
            CreateIndex("dbo.Travels", "TravelAgencyID");
            CreateIndex("dbo.Travels", "DestinationID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Travels", new[] { "DestinationID" });
            DropIndex("dbo.Travels", new[] { "TravelAgencyID" });
            DropIndex("dbo.Insurances", new[] { "InsuranceTypeID" });
            CreateIndex("dbo.Travels", new[] { "DepartureDate", "ReturnDate", "PricePerPerson", "TravelAgencyID", "DestinationID" }, unique: true, name: "IX_DatesPriceTravelAgencyDestination");
            CreateIndex("dbo.Insurances", new[] { "Price", "InsuranceTypeID" }, unique: true, name: "IX_PriceType");
        }
    }
}
