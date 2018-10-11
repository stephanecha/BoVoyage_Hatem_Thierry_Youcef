using BoVoyage.DAL.Data.Interface;
using BoVoyage.DAL.Entites;
using System.Collections.Generic;

namespace BoVoyage.BUSINESS.Services
{
	public class ServiceTravelAgency
	{
		private readonly IDataTravelAgency dataTravelAgency;

		public ServiceTravelAgency(IDataTravelAgency dataTravelAgency)
		{
			this.dataTravelAgency = dataTravelAgency;
		}

		public IEnumerable<TravelAgency> GetAllTravelAgencies()
		{
			return this.dataTravelAgency.GetAllTravelAgencies();
		}

		public IEnumerable<TravelAgency> GetAllTravelAgenciesIncludeTravels()
		{
			return this.dataTravelAgency.GetAllTravelAgenciesIncludeTravels();
		}

		public TravelAgency GetTravelAgency(int id)
		{
			return this.dataTravelAgency.GetTravelAgency(id);
		}

		public void AddTravelAgency(TravelAgency travelAgency)
		{
			//TODO: TESTS A FAIRE
			this.dataTravelAgency.AddTravelAgency(travelAgency);
		}

		public void UpdateTravelAgency(TravelAgency travelAgency)
		{
			//TODO: TESTS A FAIRE
			this.dataTravelAgency.UpdateTravelAgency(travelAgency);
		}

		public void DeleteTravelAgency(int id)
		{
			this.dataTravelAgency.DeleteTravelAgency(id);
		}
	}
}