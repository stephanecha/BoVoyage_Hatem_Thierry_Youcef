namespace BoVoyage.DAL.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class Init : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"dbo.Authentifications",
				c => new
				{
					ID = c.Int(nullable: false, identity: true),
					Email = c.String(nullable: false, maxLength: 60),
					Password = c.String(nullable: false, maxLength: 250),
				})
				.PrimaryKey(t => t.ID)
				.Index(t => t.Email, unique: true);

			CreateTable(
				"dbo.BookingFiles",
				c => new
				{
					ID = c.Int(nullable: false, identity: true),
					SequentialNb = c.String(nullable: false, maxLength: 60),
					CreditCardNb = c.String(nullable: false, maxLength: 40),
					NbTraveler = c.Int(nullable: false),
					PricePerPerson = c.Decimal(nullable: false, storeType: "money"),
					TotalPrice = c.Decimal(nullable: false, storeType: "money"),
					State = c.Byte(nullable: false),
					CustomerID = c.Int(nullable: false),
					TravelID = c.Int(nullable: false),
				})
				.PrimaryKey(t => t.ID)
				.ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: false)
				.ForeignKey("dbo.Travels", t => t.TravelID, cascadeDelete: false)
				.Index(t => t.SequentialNb, unique: true)
				.Index(t => t.CustomerID)
				.Index(t => t.TravelID);

			CreateTable(
				"dbo.Customers",
				c => new
				{
					ID = c.Int(nullable: false, identity: true),
					CreatedOn = c.DateTime(nullable: false),
					AuthentificationID = c.Int(nullable: false),
					Civility = c.String(nullable: false, maxLength: 20),
					LastName = c.String(nullable: false, maxLength: 30),
					FirstName = c.String(nullable: false, maxLength: 30),
					Address = c.String(nullable: false, maxLength: 60),
					PhoneNumber = c.String(nullable: false, maxLength: 20),
					BirthDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
				})
				.PrimaryKey(t => t.ID)
				.ForeignKey("dbo.Authentifications", t => t.AuthentificationID, cascadeDelete: false)
				.Index(t => t.AuthentificationID);

			CreateTable(
				"dbo.Insurances",
				c => new
				{
					ID = c.Int(nullable: false, identity: true),
					Price = c.Decimal(nullable: false, storeType: "money"),
					Description = c.String(nullable: false, maxLength: 250),
					InsuranceTypeID = c.Int(nullable: false),
				})
				.PrimaryKey(t => t.ID)
				.ForeignKey("dbo.InsuranceTypes", t => t.InsuranceTypeID, cascadeDelete: false)
				.Index(t => t.InsuranceTypeID);

			CreateTable(
				"dbo.InsuranceTypes",
				c => new
				{
					ID = c.Int(nullable: false, identity: true),
					Type = c.String(nullable: false, maxLength: 40),
				})
				.PrimaryKey(t => t.ID)
				.Index(t => t.Type, unique: true);

			CreateTable(
				"dbo.Travels",
				c => new
				{
					ID = c.Int(nullable: false, identity: true),
					DepartureDate = c.DateTime(nullable: false),
					ReturnDate = c.DateTime(nullable: false),
					AvailablePlaces = c.Int(nullable: false),
					PricePerPerson = c.Decimal(nullable: false, storeType: "money"),
					TravelAgencyID = c.Int(nullable: false),
					DestinationID = c.Int(nullable: false),
				})
				.PrimaryKey(t => t.ID)
				.ForeignKey("dbo.Destinations", t => t.DestinationID, cascadeDelete: false)
				.ForeignKey("dbo.TravelAgencies", t => t.TravelAgencyID, cascadeDelete: false)
				.Index(t => t.TravelAgencyID)
				.Index(t => t.DestinationID);

			CreateTable(
				"dbo.Destinations",
				c => new
				{
					ID = c.Int(nullable: false, identity: true),
					Continent = c.String(nullable: false, maxLength: 40),
					Country = c.String(nullable: false, maxLength: 40),
					Area = c.String(nullable: false, maxLength: 40),
					City = c.String(nullable: false, maxLength: 40),
					Description = c.String(nullable: false, maxLength: 500),
				})
				.PrimaryKey(t => t.ID)
				.Index(t => new { t.Continent, t.Country, t.Area, t.City }, unique: true, name: "IX_ContinentCountryAreaCity");

			CreateTable(
				"dbo.TravelAgencies",
				c => new
				{
					ID = c.Int(nullable: false, identity: true),
					Name = c.String(nullable: false, maxLength: 40),
				})
				.PrimaryKey(t => t.ID)
				.Index(t => t.Name, unique: true);

			CreateTable(
				"dbo.Travelers",
				c => new
				{
					ID = c.Int(nullable: false, identity: true),
					SequentialNb = c.String(nullable: false, maxLength: 60),
					BookingFileID = c.Int(nullable: false),
					Civility = c.String(nullable: false, maxLength: 20),
					LastName = c.String(nullable: false, maxLength: 30),
					FirstName = c.String(nullable: false, maxLength: 30),
					Address = c.String(nullable: false, maxLength: 60),
					PhoneNumber = c.String(nullable: false, maxLength: 20),
					BirthDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
				})
				.PrimaryKey(t => t.ID)
				.ForeignKey("dbo.BookingFiles", t => t.BookingFileID, cascadeDelete: false)
				.Index(t => t.SequentialNb, unique: true)
				.Index(t => t.BookingFileID);

			CreateTable(
				"dbo.SalesManagers",
				c => new
				{
					ID = c.Int(nullable: false, identity: true),
					AuthentificationID = c.Int(nullable: false),
					Civility = c.String(nullable: false, maxLength: 20),
					LastName = c.String(nullable: false, maxLength: 30),
					FirstName = c.String(nullable: false, maxLength: 30),
					Address = c.String(nullable: false, maxLength: 60),
					PhoneNumber = c.String(nullable: false, maxLength: 20),
					BirthDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
				})
				.PrimaryKey(t => t.ID)
				.ForeignKey("dbo.Authentifications", t => t.AuthentificationID, cascadeDelete: false)
				.Index(t => t.AuthentificationID);

			CreateTable(
				"dbo.InsuranceBookingFiles",
				c => new
				{
					Insurance_ID = c.Int(nullable: false),
					BookingFile_ID = c.Int(nullable: false),
				})
				.PrimaryKey(t => new { t.Insurance_ID, t.BookingFile_ID })
				.ForeignKey("dbo.Insurances", t => t.Insurance_ID, cascadeDelete: false)
				.ForeignKey("dbo.BookingFiles", t => t.BookingFile_ID, cascadeDelete: false)
				.Index(t => t.Insurance_ID)
				.Index(t => t.BookingFile_ID);
		}

		public override void Down()
		{
			DropForeignKey("dbo.SalesManagers", "AuthentificationID", "dbo.Authentifications");
			DropForeignKey("dbo.Travelers", "BookingFileID", "dbo.BookingFiles");
			DropForeignKey("dbo.Travels", "TravelAgencyID", "dbo.TravelAgencies");
			DropForeignKey("dbo.Travels", "DestinationID", "dbo.Destinations");
			DropForeignKey("dbo.BookingFiles", "TravelID", "dbo.Travels");
			DropForeignKey("dbo.Insurances", "InsuranceTypeID", "dbo.InsuranceTypes");
			DropForeignKey("dbo.InsuranceBookingFiles", "BookingFile_ID", "dbo.BookingFiles");
			DropForeignKey("dbo.InsuranceBookingFiles", "Insurance_ID", "dbo.Insurances");
			DropForeignKey("dbo.BookingFiles", "CustomerID", "dbo.Customers");
			DropForeignKey("dbo.Customers", "AuthentificationID", "dbo.Authentifications");
			DropIndex("dbo.InsuranceBookingFiles", new[] { "BookingFile_ID" });
			DropIndex("dbo.InsuranceBookingFiles", new[] { "Insurance_ID" });
			DropIndex("dbo.SalesManagers", new[] { "AuthentificationID" });
			DropIndex("dbo.Travelers", new[] { "BookingFileID" });
			DropIndex("dbo.Travelers", new[] { "SequentialNb" });
			DropIndex("dbo.TravelAgencies", new[] { "Name" });
			DropIndex("dbo.Destinations", "IX_ContinentCountryAreaCity");
			DropIndex("dbo.Travels", new[] { "DestinationID" });
			DropIndex("dbo.Travels", new[] { "TravelAgencyID" });
			DropIndex("dbo.InsuranceTypes", new[] { "Type" });
			DropIndex("dbo.Insurances", new[] { "InsuranceTypeID" });
			DropIndex("dbo.Customers", new[] { "AuthentificationID" });
			DropIndex("dbo.BookingFiles", new[] { "TravelID" });
			DropIndex("dbo.BookingFiles", new[] { "CustomerID" });
			DropIndex("dbo.BookingFiles", new[] { "SequentialNb" });
			DropIndex("dbo.Authentifications", new[] { "Email" });
			DropTable("dbo.InsuranceBookingFiles");
			DropTable("dbo.SalesManagers");
			DropTable("dbo.Travelers");
			DropTable("dbo.TravelAgencies");
			DropTable("dbo.Destinations");
			DropTable("dbo.Travels");
			DropTable("dbo.InsuranceTypes");
			DropTable("dbo.Insurances");
			DropTable("dbo.Customers");
			DropTable("dbo.BookingFiles");
			DropTable("dbo.Authentifications");
		}
	}
}