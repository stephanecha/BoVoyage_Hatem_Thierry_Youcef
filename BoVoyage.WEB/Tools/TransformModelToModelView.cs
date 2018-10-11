using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Models;
using System.Collections.Generic;
using System.Linq;

namespace BoVoyage.WEB.Tools
{
	public static class TransformModelToModelView
	{
		public static List<InsuranceViewModel> InsuranceToModelView(IEnumerable<Insurance> listAssurances)
		{
			List<InsuranceViewModel> assuranceViewModel = new List<InsuranceViewModel>(listAssurances.Select(x =>
				new InsuranceViewModel()
				{
					ID = x.ID,
					Description = x.Description,
					Price = x.Price,
					InsuranceTypeID = x.InsuranceTypeID,
					InsuranceType = x.InsuranceType
				}).ToList());
			return assuranceViewModel;
		}

		public static List<InsuranceTypeViewModel> InsuranceTypeToModelView(IEnumerable<InsuranceType> listAssurancesTypes)
		{
			List<InsuranceTypeViewModel> allAssuranceTypesViewModel = new List<InsuranceTypeViewModel>(
				listAssurancesTypes.Select(x =>
				new InsuranceTypeViewModel()
				{
					ID = x.ID,
					Type = x.Type,
					Insurances = x.Insurances
				}).ToList());

			return allAssuranceTypesViewModel;
		}

		public static InsuranceType InsuranceTypeModelViewToModel(InsuranceTypeViewModel assuranceTypeViewModel)
		{
			InsuranceType insurancetype = new InsuranceType()
			{
				ID = assuranceTypeViewModel.ID,
				Type = assuranceTypeViewModel.Type
			};

			return insurancetype;
		}

		public static InsuranceTypeViewModel InsuranceTypeToModelView(InsuranceType assurancesType)
		{
			InsuranceTypeViewModel assuranceTypeViewModel = new InsuranceTypeViewModel()
			{
				ID = assurancesType.ID,
				Type = assurancesType.Type
			};

			return assuranceTypeViewModel;
		}

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