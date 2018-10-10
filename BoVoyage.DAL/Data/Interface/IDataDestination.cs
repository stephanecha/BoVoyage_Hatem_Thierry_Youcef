using BoVoyage.DAL.Entites;
using System.Collections.Generic;

namespace BoVoyage.DAL.Data.Interface
{
	public interface IDataDestination
	{
		IEnumerable<Destination> GetAllDestinations();

		Destination GetDestination(int id);

		void AddDestination(Destination destination);

		void UpdateDestination(Destination destination);

		void DeleteDestination(int id);
	}
}