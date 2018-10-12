using BoVoyage.DAL.Entites;
using System.Collections.Generic;

namespace BoVoyage.DAL.Data.Interface
{
	public interface IDataTravel
	{
		IEnumerable<Travel> GetAllTravels();

		IEnumerable<Travel> GetAllTravelsWithDestinationIncluded();

		IEnumerable<Travel> GetAllTravelsWithDestinationAndAgencyIncluded();

		Travel GetTravel(int id);

		Travel GetTravelWithDestinationAndAgencyIncluded(int id);

		void AddTravel(Travel travel);

		void UpdateTravel(Travel travel);

		void DeleteTravel(int id);
	}
}