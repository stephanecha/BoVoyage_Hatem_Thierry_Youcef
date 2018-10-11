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
	}
}