namespace BoVoyage.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonWithoutUnique : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Customers", "IX_UniquePerson");
            DropIndex("dbo.Travelers", "IX_UniquePerson");
            DropIndex("dbo.SalesManagers", "IX_UniquePerson");
        }
        
        public override void Down()
        {
            CreateIndex("dbo.SalesManagers", new[] { "Civility", "LastName", "FirstName", "Address" }, unique: true, name: "IX_UniquePerson");
            CreateIndex("dbo.Travelers", new[] { "Civility", "LastName", "FirstName", "Address" }, unique: true, name: "IX_UniquePerson");
            CreateIndex("dbo.Customers", new[] { "Civility", "LastName", "FirstName", "Address" }, unique: true, name: "IX_UniquePerson");
        }
    }
}
