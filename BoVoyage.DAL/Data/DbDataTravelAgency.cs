using BoVoyage.DAL.Data.Base;
using BoVoyage.DAL.Data.Interface;
using BoVoyage.DAL.Entites;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BoVoyage.DAL.Data
{
	public class DbDataTravelAgency : DbDataBase, IDataTravelAgency
	{
		public void AddTravelAgency(TravelAgency travelAgency)
		{
			this.context.TravelAgencies.Add(travelAgency);
			this.context.SaveChanges();
		}

		public void DeleteTravelAgency(int id)
		{
			TravelAgency travelAgency = this.context.TravelAgencies.SingleOrDefault(x => x.ID == id);
			this.context.TravelAgencies.Remove(travelAgency);
			this.context.SaveChanges();
		}

		public IEnumerable<TravelAgency> GetAllTravelAgencies()
		{
			return this.context.TravelAgencies.ToList();
		}

		public IEnumerable<TravelAgency> GetAllTravelAgenciesIncludeTravels()
		{
			return this.context.TravelAgencies.Include("Travels").ToList();
		}

		public TravelAgency GetTravelAgency(int id)
		{
			return this.context.TravelAgencies.SingleOrDefault(x => x.ID == id);
		}

		public void UpdateTravelAgency(TravelAgency travelAgency)
		{
			this.context.TravelAgencies.Attach(travelAgency);
			this.context.Entry(travelAgency).State = EntityState.Modified;
			this.context.SaveChanges();
		}
	}
}