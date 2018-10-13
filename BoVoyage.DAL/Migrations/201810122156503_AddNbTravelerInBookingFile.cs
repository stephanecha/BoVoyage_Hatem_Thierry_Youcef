namespace BoVoyage.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNbTravelerInBookingFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingFiles", "NbTraveler", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookingFiles", "NbTraveler");
        }
    }
}
