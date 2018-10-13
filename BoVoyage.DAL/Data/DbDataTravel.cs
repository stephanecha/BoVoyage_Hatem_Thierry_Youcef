using BoVoyage.DAL.Data.Base;
using BoVoyage.DAL.Data.Interface;
using BoVoyage.DAL.Entites;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BoVoyage.DAL.Data
{
	public class DbDataTravel : DbDataBase, IDataTravel
	{
		public void AddTravel(Travel travel)
		{
			this.context.Travels.Add(travel);
			this.context.SaveChanges();
		}

		public void DeleteTravel(int id)
		{
			Travel Travel = this.context.Travels.SingleOrDefault(x => x.ID == id);
			this.context.Travels.Remove(Travel);
			this.context.SaveChanges();
		}

		public IEnumerable<Travel> GetAllTravels()
		{
			return this.context.Travels.ToList();
		}

		public IEnumerable<Travel> GetAllTravelsWithDestinationAndAgencyIncluded()
		{
			return this.context.Travels.Include("Destination").Include("TravelAgency").ToList();
		}

		public IEnumerable<Travel> GetAllTravelsWithDestinationIncluded()
		{
			return this.context.Travels.Include("Destination").ToList();
		}

		public Travel GetTravel(int id)
		{
			return this.context.Travels.SingleOrDefault(x => x.ID == id);
		}

		public Travel GetTravelWithDestinationAndAgencyIncluded(int id)
		{
			return this.context.Travels.Include("Destination").Include("TravelAgency").SingleOrDefault(x => x.ID == id);
		}

		public Travel GetTravelWithDestinationIncluded(int id)
		{
			return this.context.Travels.Include("Destination").SingleOrDefault(x => x.ID == id);
		}

		public void UpdateTravel(Travel travel)
		{
			this.context.Travels.Attach(travel);
			this.context.Entry(travel).State = EntityState.Modified;
			this.context.SaveChanges();
		}
	}
}