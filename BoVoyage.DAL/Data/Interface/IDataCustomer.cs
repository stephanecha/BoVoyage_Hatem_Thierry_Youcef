using BoVoyage.DAL.Entites;
using System.Collections.Generic;

namespace BoVoyage.DAL.Data.Interface
{
	public interface IDataCustomer
	{
		IEnumerable<Customer> GetAllCustomers();

		Customer GetCustomer(int id);

		void AddCustomer(Customer customer);

		void UpdateCustomer(Customer customer);

		void DeleteCustomer(int id);
	}
}