using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Models;
using System.Collections.Generic;
using System.Linq;

namespace BoVoyage.WEB.Tools
{
	public static class TransformModelTravel
	{
		public static List<TravelViewModel> TravelToModelView(IEnumerable<Travel> listTravel)
		{
			List<TravelViewModel> agencesViewModel = new List<TravelViewModel>(listTravel.Select(x =>
				new TravelViewModel()
				{
					ID = x.ID,
					DepartureDate = x.DepartureDate,
					ReturnDate = x.ReturnDate,
					PricePerPerson = x.PricePerPerson,
					AvailablePlaces = x.AvailablePlaces,
					DestinationID = x.DestinationID,
					Destination = x.Destination,
					TravelAgencyID = x.TravelAgencyID,
					TravelAgency = x.TravelAgency
				}).ToList());
			return agencesViewModel;
		}

		public static TravelViewModel TravelToModelView(Travel travel)
		{
			TravelViewModel travelViewModel = new TravelViewModel()
			{
				ID = travel.ID,
				DepartureDate = travel.DepartureDate,
				ReturnDate = travel.ReturnDate,
				PricePerPerson = travel.PricePerPerson,
				AvailablePlaces = travel.AvailablePlaces,
				DestinationID = travel.DestinationID,
				Destination = travel.Destination,
				TravelAgencyID = travel.TravelAgencyID,
				TravelAgency = travel.TravelAgency
			};
			return travelViewModel;
		}

		public static Travel TravelViewToModel(TravelViewModel travelViewModel)
		{
			Travel travel = new Travel()
			{
				ID = travelViewModel.ID,
				DepartureDate = travelViewModel.DepartureDate,
				ReturnDate = travelViewModel.ReturnDate,
				PricePerPerson = travelViewModel.PricePerPerson,
				AvailablePlaces = travelViewModel.AvailablePlaces,
				DestinationID = travelViewModel.DestinationID,
				TravelAgencyID = travelViewModel.TravelAgencyID
			};
			return travel;
		}

		public static List<Travel> TravelModelViewToModel(IEnumerable<TravelViewModel> travelViewModel)
		{
			List<Travel> travel = new List<Travel>(travelViewModel.Select(x =>
				new Travel()
				{
					ID = x.ID,
					DepartureDate = x.DepartureDate,
					ReturnDate = x.ReturnDate,
					PricePerPerson = x.PricePerPerson,
					AvailablePlaces = x.AvailablePlaces,
					DestinationID = x.DestinationID,
					TravelAgencyID = x.TravelAgencyID
				}).ToList());
			return travel;
		}
	}
}