namespace BoVoyage.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutDesPictures : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DestinationPictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 150),
                        ContentType = c.String(nullable: false, maxLength: 150),
                        Content = c.Binary(nullable: false),
                        DestinationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Destinations", t => t.DestinationID, cascadeDelete: false)
                .Index(t => t.DestinationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DestinationPictures", "DestinationID", "dbo.Destinations");
            DropIndex("dbo.DestinationPictures", new[] { "DestinationID" });
            DropTable("dbo.DestinationPictures");
        }
    }
}
