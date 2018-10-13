using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Models;
using System;

namespace BoVoyage.WEB.Tools
{
	public static class TransformModelCustomer
	{
		public static Customer CustomerModelViewToModel(CustomerViewModel customerViewModel)
		{
			//Authentification authen = new Authentification()
			//{
			//    Password = customerViewModel.Password,
			//    ConfirmedPassword = customerViewModel.ConfirmedPassword,
			//    Email = customerViewModel.Email

			//};
			Customer customer = new Customer()
			{
				ID = customerViewModel.ID,
				Civility = customerViewModel.Civility,
				FirstName = customerViewModel.FirstName,
				LastName = customerViewModel.LastName,
				BirthDate = customerViewModel.BirthDate,
				Address = customerViewModel.Address,
				PhoneNumber = customerViewModel.PhoneNumber,
				CreatedOn = DateTime.Now

				//BookingFiles = customerViewModel.BookingFiles
			};
			customer.Authentification = new Authentification();
			customer.Authentification.Password = customerViewModel.Password;
			//customer.Authentification.ConfirmedPassword = customerViewModel.ConfirmedPassword;
			customer.Authentification.Email = customerViewModel.Email;
			//customer.Authentification.ID = customerViewModel.ID;

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