using BoVoyage.DAL.Data.Interface;
using BoVoyage.DAL.Entites;
using System.Collections.Generic;
using System.Linq;

namespace BoVoyage.BUSINESS.Services
{
	public class ServiceTravel
	{
		private readonly IDataTravel dataTravel;

		public ServiceTravel(IDataTravel dataTravel)
		{
			this.dataTravel = dataTravel;
		}

		public IEnumerable<Travel> GetAllTravels()
		{
			return this.dataTravel.GetAllTravels();
		}

		public Travel GetTravel(int id)
		{
			return this.dataTravel.GetTravel(id);
		}

		public void AddTravel(Travel travel)
		{
			//TODO: TESTS A FAIRE
			this.dataTravel.AddTravel(travel);
		}

		public void UpdateTravel(Travel travel)
		{
			//TODO: TESTS A FAIRE
			this.dataTravel.UpdateTravel(travel);
		}

		public void DeleteTravel(int id)
		{
			this.dataTravel.DeleteTravel(id);
		}

		public IEnumerable<Travel> GetLessExpensiveTravels(int nb)
		{
			return this.dataTravel.GetAllTravelsWithDestinationsIncluded()
									.Where(x => x.AvailablePlaces > 0)
									.OrderByDescending(x => x.PricePerPerson)
									.Take(nb);
		}

		public IEnumerable<Travel> GetSoonDepartureTravels(int nb)
		{
			return this.dataTravel.GetAllTravelsWithDestinationsIncluded()
									.Where(x => x.AvailablePlaces > 0)
									.OrderBy(x => x.DepartureDate)
									.Take(nb);
		}

		public IEnumerable<Travel> GetTopCountriesTravels(int nb)
		{
			return this.dataTravel.GetAllTravelsWithDestinationsIncluded();
		}
	}
}