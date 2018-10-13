using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Models;

namespace BoVoyage.WEB.Tools
{
	public static class TransformModelCustomer
	{
		public static Customer CustomerModelViewToModel(CustomerViewModel customerViewModel)
		{
			Customer customer = new Customer()
			{
				ID = customerViewModel.ID,
				Civility = customerViewModel.Civility,
				FirstName = customerViewModel.FirstName,
				LastName = customerViewModel.LastName,
				BirthDate = customerViewModel.BirthDate,
				Address = customerViewModel.Address,
				PhoneNumber = customerViewModel.PhoneNumber,
			};
			//customer.CreatedOn = DateTime.Now;
			customer.Authentification = new Authentification
			{
				Password = customerViewModel.Password,
				Email = customerViewModel.Email
			};

			return customer;
		}

		public static CustomerViewModel CustomerToModelView(Customer customer)
		{
			CustomerViewModel customerViewModel = new CustomerViewModel()
			{
				ID = customer.ID,
				Civility = customer.Civility,
				FirstName = customer.FirstName,
				LastName = customer.LastName,
				Address = customer.Address,
				PhoneNumber = customer.PhoneNumber,
				BirthDate = customer.BirthDate,
				Email = customer.Authentification.Email
			};

			return customerViewModel;
		}
	}
}