using BoVoyage.DAL.Data.Base;
using BoVoyage.DAL.Data.Interface;
using BoVoyage.DAL.Entites;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BoVoyage.DAL.Data
{
	public class DbDataSalesManager : DbDataBase, IDataSalesManager
	{
		public void AddSalesManager(SalesManager salesManager)
		{
			this.context.SalesManagers.Add(salesManager);
			this.context.SaveChanges();
		}

		public void DeleteSalesManager(int id)
		{
			SalesManager salesManager = this.context.SalesManagers.SingleOrDefault(x => x.ID == id);
			this.context.SalesManagers.Remove(salesManager);
			this.context.SaveChanges();
		}

		public IEnumerable<SalesManager> GetAllSalesManagers()
		{
			return this.context.SalesManagers.ToList();
		}

		public SalesManager GetSalesManager(int id)
		{
			return this.context.SalesManagers.SingleOrDefault(x => x.ID == id);
		}

		public void UpdateSalesManager(SalesManager salesManager)
		{
			this.context.SalesManagers.Attach(salesManager);
			this.context.Entry(salesManager).State = EntityState.Modified;
			this.context.SaveChanges();
		}
	}
}