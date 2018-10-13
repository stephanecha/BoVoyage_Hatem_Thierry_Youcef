namespace BoVoyage.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCreatedOn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "CreatedOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CreatedOn", c => c.DateTime(nullable: false));
        }
    }
}
