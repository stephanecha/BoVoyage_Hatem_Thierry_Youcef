using BoVoyage.DAL.Entites;
using System.Data.Entity;
using System.Diagnostics;

namespace BoVoyage.DAL.Context
{
	public class DataContext : DbContext
	{
		public DataContext() : base("BoVoyageDB")
		{
			this.Database.Log = s => Debug.Write(s);
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			Database.SetInitializer<DataContext>(null);
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<TravelAgency> TravelAgencies { get; set; }

		public DbSet<Destination> Destinations { get; set; }

		public DbSet<Travel> Travels { get; set; }

		public DbSet<InsuranceType> InsuranceTypes { get; set; }

		public DbSet<Insurance> Insurances { get; set; }

		public DbSet<BookingFile> BookingFiles { get; set; }

		public DbSet<Authentification> Authentifications { get; set; }

		public DbSet<Customer> Customers { get; set; }

		public DbSet<Traveler> Travelers { get; set; }

		public DbSet<SalesManager> SalesManagers { get; set; }
	}
}