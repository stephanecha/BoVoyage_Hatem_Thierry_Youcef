namespace BoVoyage.DAL.Migrations
{
	using BoVoyage.DAL.Entites;
	using System;
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<BoVoyage.DAL.Context.DataContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(BoVoyage.DAL.Context.DataContext context)
		{
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method
			//  to avoid creating duplicate seed data.

			context.TravelAgencies.AddOrUpdate(x => x.ID,
				new TravelAgency() { ID = 1, Name = "Les voyages de Charly" },
				new TravelAgency() { ID = 2, Name = "Les merveilles du monde" },
				new TravelAgency() { ID = 3, Name = "Les destinations de rêves" }
			);

			context.Destinations.AddOrUpdate(x => x.ID,
				new Destination()
				{
					ID = 1,
					Continent = "Europe",
					Country = "France",
					Area = "IDF",
					City = "Paris",
					Description = "La ville lumiere"
				},
				new Destination()
				{
					ID = 2,
					Continent = "Asie",
					Country = "Chine",
					Area = "Est",
					City = "Shanghai",
					Description = "Visite dans le monde moderne"
				},
				new Destination()
				{
					ID = 3,
					Continent = "Afrique",
					Country = "Togo",
					Area = "South",
					City = "Lome",
					Description = "Chez Marcel"
				},
				new Destination()
				{
					ID = 4,
					Continent = "Amerique du Sud",
					Country = "Argentine",
					Area = "Nord",
					City = "Bueno Aires",
					Description = "De la viande et du tango"
				}
			);

			context.Travels.AddOrUpdate(x => x.ID,
				new Travel()
				{
					ID = 1,
					DepartureDate = DateTime.Parse("2018/10/29"),
					ReturnDate = DateTime.Parse("2018/11/01"),
					AvailablePlaces = 150,
					PricePerPerson = 1999.0m,
					TravelAgencyID = 3,
					DestinationID = 1
				},
				new Travel()
				{
					ID = 2,
					DepartureDate = DateTime.Parse("2018/11/05"),
					ReturnDate = DateTime.Parse("2018/11/15"),
					AvailablePlaces = 44,
					PricePerPerson = 450.0m,
					TravelAgencyID = 2,
					DestinationID = 4
				},
				new Travel()
				{
					ID = 3,
					DepartureDate = DateTime.Parse("2019/10/02"),
					ReturnDate = DateTime.Parse("2019/10/25"),
					AvailablePlaces = 15,
					PricePerPerson = 680.0m,
					TravelAgencyID = 3,
					DestinationID = 3
				},
				new Travel()
				{
					ID = 4,
					DepartureDate = DateTime.Parse("2018/10/28"),
					ReturnDate = DateTime.Parse("2018/11/20"),
					AvailablePlaces = 25,
					PricePerPerson = 479.0m,
					TravelAgencyID = 1,
					DestinationID = 4
				},
				new Travel()
				{
					ID = 5,
					DepartureDate = DateTime.Parse("2018/11/01"),
					ReturnDate = DateTime.Parse("2018/11/30"),
					AvailablePlaces = 20,
					PricePerPerson = 800.0m,
					TravelAgencyID = 1,
					DestinationID = 4
				},
				new Travel()
				{
					ID = 6,
					DepartureDate = DateTime.Parse("2018/11/23"),
					ReturnDate = DateTime.Parse("2018/12/01"),
					AvailablePlaces = 100,
					PricePerPerson = 3500.0m,
					TravelAgencyID = 3,
					DestinationID = 3
				},
				new Travel()
				{
					ID = 7,
					DepartureDate = DateTime.Parse("2019/02/11"),
					ReturnDate = DateTime.Parse("2019/02/18"),
					AvailablePlaces = 350,
					PricePerPerson = 1000.0m,
					TravelAgencyID = 2,
					DestinationID = 2
				},
				new Travel()
				{
					ID = 8,
					DepartureDate = DateTime.Parse("2018/12/01"),
					ReturnDate = DateTime.Parse("2018/12/31"),
					AvailablePlaces = 10,
					PricePerPerson = 2000.0m,
					TravelAgencyID = 2,
					DestinationID = 1
				}
			);

			context.InsuranceTypes.AddOrUpdate(x => x.ID,
				new InsuranceType() { ID = 1, Type = "Annulation" }
			);

			context.Insurances.AddOrUpdate(x => x.ID,
				new Insurance() { ID = 1, Price = 50.0m, InsuranceTypeID = 1, Description = "50% remboursé" },
				new Insurance() { ID = 2, Price = 100.0m, InsuranceTypeID = 1, Description = "100% remboursé" }
			);

			context.Authentifications.AddOrUpdate(x => x.ID,
				// Password = "azerty"
				new Authentification() { ID = 1, Email = "admin@bovoyage.com", Password = "DF6B9FB15CFDBB7527BE5A8A6E39F39E572C8DDB943FBC79A943438E9D3D85EBFC2CCF9E0ECCD9346026C0B6876E0E01556FE56F135582C05FBDBB505D46755A" }
			);

			context.SalesManagers.AddOrUpdate(x => x.ID,
				new SalesManager()
				{
					ID = 1,
					// Password = "azerty"
					AuthentificationID = 1,
					Civility = "Admin",
					FirstName = "Admin",
					LastName = "Admin",
					Address = "QG BoVoyage",
					BirthDate = DateTime.Parse("1990/01/01"),
					PhoneNumber = "01.02.03.04.05"
				}
			);
		}
	}
}