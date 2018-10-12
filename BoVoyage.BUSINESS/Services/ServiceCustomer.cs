using BoVoyage.BUSINESS.Services.Base;
using BoVoyage.DAL.Data.Interface;
using BoVoyage.DAL.Entites;
using System;
using System.Collections.Generic;

namespace BoVoyage.BUSINESS.Services
{
	public class ServiceCustomer : BaseServiceAuthentification
	{
		private readonly IDataCustomer dataCustomer;

		public ServiceCustomer(IDataAuthentification dataAuthentification, IDataCustomer dataCustomer) : base(dataAuthentification)
		{
			this.dataCustomer = dataCustomer;
		}

		public IEnumerable<Customer> GetAllCustomers()
		{
			return this.dataCustomer.GetAllCustomers();
		}

		public Customer GetCustomer(int id)
		{
			return this.dataCustomer.GetCustomer(id);
		}

		public void AddCustomer(Authentification authentification, Customer customer)
		{
            ////TODO: TESTS A FAIRE
            //this.dataAuthentification.AddAuthentification(authentification);
            //var testID = this.dataAuthentification.GetAuthentification(authentification.Email);
            //if (testID == null)
            //{
            //    throw new Exception("");
            //}
            //customer.AuthentificationID = testID.ID;
            //customer.Authentification = null;
            this.dataCustomer.AddCustomer(customer);
		}

		public void UpdateCustomer(Customer customer)
		{
			//TODO: TESTS A FAIRE
			this.dataCustomer.UpdateCustomer(customer);
		}

		public void DeleteCustomer(int id)
		{
			this.dataCustomer.DeleteCustomer(id);
		}
	}
}