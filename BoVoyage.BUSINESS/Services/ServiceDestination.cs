using BoVoyage.DAL.Data.Interface;
using BoVoyage.DAL.Entites;
using System.Collections.Generic;
using System.Linq;

namespace BoVoyage.BUSINESS.Services
{
	public class ServiceDestination
	{
		private readonly IDataDestination dataDestination;

		public ServiceDestination(IDataDestination dataDestination)
		{
			this.dataDestination = dataDestination;
		}

		public IEnumerable<Destination> GetAllDestinations()
		{
			return this.dataDestination.GetAllDestinations();
		}

		public IEnumerable<Destination> GetAllDestinationsWithTravelsNotNull()
		{
			return this.dataDestination.GetAllDestinationsWithTravelsIncluded().Where(x => x.Travels.Count > 0);
		}

		public IEnumerable<Destination> GetAllDestinationsWithTravelsIncluded()
		{
			return this.dataDestination.GetAllDestinationsWithTravelsIncluded();
		}

		public Destination GetDestination(int id)
		{
			return this.dataDestination.GetDestination(id);
		}

		public void AddDestination(Destination destination)
		{
			//TODO: TESTS A FAIRE
			this.dataDestination.AddDestination(destination);
		}

		public void UpdateDestination(Destination destination)
		{
			//TODO: TESTS A FAIRE
			this.dataDestination.UpdateDestination(destination);
		}

		public void DeleteDestination(int id)
		{
			this.dataDestination.DeleteDestination(id);
		}
	}
}