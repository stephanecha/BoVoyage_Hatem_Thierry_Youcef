using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Models;
using System.Collections.Generic;
using System.Linq;

namespace BoVoyage.WEB.Tools
{
	public static class TransformModelInsurance
	{
		public static List<InsuranceViewModel> InsuranceToModelView(IEnumerable<Insurance> listAssurances)
		{
			List<InsuranceViewModel> assuranceViewModel = new List<InsuranceViewModel>(listAssurances.Select(x =>
				new InsuranceViewModel()
				{
					ID = x.ID,
					Description = x.Description,
					Price = x.Price,
					InsuranceType = x.InsuranceType,
					BookingFiles = x.BookingFiles
				}).ToList());
			return assuranceViewModel;
		}

		public static Insurance InsuranceModelViewToModel(InsuranceViewModel insuranceViewModel)
		{
			Insurance insurance = new Insurance()
			{
				ID = insuranceViewModel.ID,
				Price = insuranceViewModel.Price,
				Description = insuranceViewModel.Description,
				InsuranceTypeID = insuranceViewModel.InsuranceTypeID
			};

			return insurance;
		}

		public static InsuranceViewModel InsuranceToModelView(Insurance insurance)
		{
			InsuranceViewModel insuranceViewModel = new InsuranceViewModel()
			{
				ID = insurance.ID,
				Price = insurance.Price,
				Description = insurance.Description,
				InsuranceTypeID = insurance.InsuranceTypeID,
				InsuranceType = insurance.InsuranceType
			};

			return insuranceViewModel;
		}
	}
}