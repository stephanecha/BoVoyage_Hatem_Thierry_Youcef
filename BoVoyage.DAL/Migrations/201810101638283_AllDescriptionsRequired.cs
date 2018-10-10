namespace BoVoyage.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllDescriptionsRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Insurances", "Description", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Destinations", "Description", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Destinations", "Description", c => c.String());
            AlterColumn("dbo.Insurances", "Description", c => c.String());
        }
    }
}
