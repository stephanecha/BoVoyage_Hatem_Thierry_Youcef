using BoVoyage.BUSINESS.Exceptions;
using BoVoyage.DAL.Data.Interface;
using BoVoyage.DAL.Entites;
using System;
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

		public IEnumerable<Travel> GetAllTravelsWithDestination()
		{
			return this.dataTravel.GetAllTravelsWithDestinationIncluded();
		}

		public IEnumerable<Travel> GetAllTravelsWithDestinationAndAgencyIncluded()
		{
			return this.dataTravel.GetAllTravelsWithDestinationAndAgencyIncluded();
		}

		public Travel GetTravel(int id)
		{
			return this.dataTravel.GetTravel(id);
		}

		public Travel GetTravelWithDestinationIncluded(int id)
		{
			return this.dataTravel.GetTravelWithDestinationIncluded(id);
		}

		public Travel GetTravelWithDestinationAndAgencyIncluded(int id)
		{
			return this.dataTravel.GetTravelWithDestinationAndAgencyIncluded(id);
		}

		public void AddTravel(Travel travel)
		{
			if (travel.ReturnDate < travel.DepartureDate)
			{
				throw new BusinessException("Le retour doit avoir lieu après le départ");
			}
			this.dataTravel.AddTravel(travel);
		}

		public void UpdateTravel(Travel travel)
		{
			if (travel.ReturnDate < travel.DepartureDate)
			{
				throw new BusinessException("Le retour doit avoir lieu après le départ");
			}
			this.dataTravel.UpdateTravel(travel);
		}

		public void DeleteTravel(int id)
		{
			this.dataTravel.DeleteTravel(id);
		}

		public IEnumerable<Travel> GetLessExpensiveTravels(int nb)
		{
			return this.dataTravel.GetAllTravelsWithDestinationAndAgencyIncluded()
									.Where(x => x.AvailablePlaces > 0)
									.OrderByDescending(x => x.PricePerPerson)
									.Take(nb);
		}

		public IEnumerable<Travel> GetSoonDepartureTravels(int nb)
		{
			return this.dataTravel.GetAllTravelsWithDestinationAndAgencyIncluded()
									.Where(x => x.AvailablePlaces > 0)
									.OrderBy(x => x.DepartureDate)
									.Take(nb);
		}

		public IEnumerable<Travel> GetTopCountriesTravels(int nb)
		{
			return this.dataTravel.GetAllTravelsWithDestinationAndAgencyIncluded();
		}

		public IEnumerable<Travel> GetTravelsInLessThan15Days()
		{
			var today = DateTime.Now;
			return this.dataTravel.GetAllTravelsWithDestinationAndAgencyIncluded()
									//.Where(x => x.DepartureDate < today.AddDays(15))
									.OrderBy(x => x.DepartureDate);
		}
	}
}