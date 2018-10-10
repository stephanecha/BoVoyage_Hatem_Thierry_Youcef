using BoVoyage.BUSINESS.Services.Base;
using BoVoyage.DAL.Data.Interface;
using BoVoyage.DAL.Entites;
using System.Collections.Generic;

namespace BoVoyage.BUSINESS.Services
{
	public class ServiceSalesManager : BaseServiceAuthentification
	{
		private readonly IDataSalesManager dataSalesManager;

		public ServiceSalesManager(IDataAuthentification dataAuthentification, IDataSalesManager dataSalesManager) : base(dataAuthentification)
		{
			this.dataSalesManager = dataSalesManager;
		}

		public IEnumerable<SalesManager> GetAllSalesManagers()
		{
			return this.dataSalesManager.GetAllSalesManagers();
		}

		public SalesManager GetSalesManager(int id)
		{
			return this.dataSalesManager.GetSalesManager(id);
		}

		public void AddSalesManager(SalesManager salesManager)
		{
			//TODO: TESTS A FAIRE
			this.dataSalesManager.AddSalesManager(salesManager);
		}

		public void UpdateSalesManager(SalesManager salesManager)
		{
			//TODO: TESTS A FAIRE
			this.dataSalesManager.UpdateSalesManager(salesManager);
		}

		public void DeleteSalesManager(int id)
		{
			this.dataSalesManager.DeleteSalesManager(id);
		}
	}
}