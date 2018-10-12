using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Models;

namespace BoVoyage.WEB.Tools
{
	public static class TransformModelSalesManager
	{
		public static SalesManagerViewModel SalesManagerToModelView(SalesManager salesManager)
		{
			SalesManagerViewModel salesManagerViewModel = new SalesManagerViewModel()
			{
				ID = salesManager.ID,
				Civility = salesManager.Civility,
				FirstName = salesManager.FirstName,
				LastName = salesManager.LastName,
				Address = salesManager.Address,
				PhoneNumber = salesManager.PhoneNumber,
				BirthDate = salesManager.BirthDate,
				Email = salesManager.Authentification.Email
			};

			return salesManagerViewModel;
		}
	}
}