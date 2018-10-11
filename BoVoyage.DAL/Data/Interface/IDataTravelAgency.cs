using BoVoyage.DAL.Entites;
using System.Collections.Generic;

namespace BoVoyage.DAL.Data.Interface
{
	public interface IDataTravelAgency
	{
		IEnumerable<TravelAgency> GetAllTravelAgencies();

		IEnumerable<TravelAgency> GetAllTravelAgenciesIncludeTravels();

		TravelAgency GetTravelAgency(int id);

		void AddTravelAgency(TravelAgency travelAgency);

		void UpdateTravelAgency(TravelAgency travelAgency);

		void DeleteTravelAgency(int id);
	}
}