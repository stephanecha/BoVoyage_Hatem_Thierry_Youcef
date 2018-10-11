using BoVoyage.DAL.Data.Base;
using BoVoyage.DAL.Data.Interface;
using BoVoyage.DAL.Entites;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BoVoyage.DAL.Data
{
	public class DbDataCustomer : DbDataBase, IDataCustomer
	{
		public void AddCustomer(Customer customer)
		{
			this.context.Customers.Add(customer);
			this.context.SaveChanges();
		}

		public void DeleteCustomer(int id)
		{
			Customer customer = this.context.Customers.SingleOrDefault(x => x.ID == id);
			this.context.Customers.Remove(customer);
			this.context.SaveChanges();
		}

		public IEnumerable<Customer> GetAllCustomers()
		{
			return this.context.Customers.ToList();
		}

		public Customer GetCustomer(int id)
		{
			return this.context.Customers.SingleOrDefault(x => x.ID == id);
		}

		public void UpdateCustomer(Customer customer)
		{
			this.context.Customers.Attach(customer);
			this.context.Entry(customer).State = EntityState.Modified;
			this.context.SaveChanges();
		}
	}
}