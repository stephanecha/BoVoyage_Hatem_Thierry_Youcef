using BoVoyage.DAL.Entites;
using System.Collections.Generic;

namespace BoVoyage.DAL.Data.Interface
{
	public interface IDataTraveler
	{
		IEnumerable<Traveler> GetAllTravelers();

		Traveler GetTraveler(int id);

		void AddTraveler(Traveler traveler);

		void UpdateTraveler(Traveler traveler);

		void DeleteTraveler(int id);
	}
}