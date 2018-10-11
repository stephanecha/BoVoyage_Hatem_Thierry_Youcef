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
					Destination = x.Destination
				}).ToList());
			return agencesViewModel;
		}

		public static TravelIndexSearchViewModel TravelToSearchModelView(IEnumerable<Travel> listTravel)
		{
			TravelIndexSearchViewModel travelViewModel = new TravelIndexSearchViewModel()
			{
				TravelViewModel = TravelToModelView(listTravel)
			};
			return travelViewModel;
		}
	}
}