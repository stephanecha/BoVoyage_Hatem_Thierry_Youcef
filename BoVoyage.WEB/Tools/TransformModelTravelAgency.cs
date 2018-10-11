using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Models;
using System.Collections.Generic;
using System.Linq;

namespace BoVoyage.WEB.Tools
{
	public static class TransformModelTravelAgency
	{
		public static List<TravelAgencyViewModel> TravelAgencyToModelView(IEnumerable<TravelAgency> listAgences)
		{
			List<TravelAgencyViewModel> agencesViewModel = new List<TravelAgencyViewModel>(listAgences.Select(x =>
				new TravelAgencyViewModel()
				{
					ID = x.ID,
					Name = x.Name,
					Travels = x.Travels
				}).ToList());
			return agencesViewModel;
		}

		public static TravelAgencyViewModel TravelAgencyToModelView(TravelAgency travelAgency)
		{
			TravelAgencyViewModel travelAgencyViewModel = new TravelAgencyViewModel()
			{
				ID = travelAgency.ID,
				Name = travelAgency.Name,
				Travels = travelAgency.Travels
			};
			return travelAgencyViewModel;
		}

		public static TravelAgency TravelAgencyModelViewToModel(TravelAgencyViewModel travelAgencyViewModel)
		{
			TravelAgency travelAgency = new TravelAgency()
			{
				ID = travelAgencyViewModel.ID,
				Name = travelAgencyViewModel.Name
			};
			return travelAgency;
		}
	}
}