using BoVoyage.DAL.Entites;
using System.Collections.Generic;

namespace BoVoyage.DAL.Data.Interface
{
	public interface IDataTravel
	{
		IEnumerable<Travel> GetAllTravels();

		Travel GetTravel(int id);

		void AddTravel(Travel travel);

		void UpdateTravel(Travel travel);

		void DeleteTravel(int id);
	}
}