using BoVoyage.DAL.Entites;
using System.Collections.Generic;

namespace BoVoyage.DAL.Data.Interface
{
	public interface IDataSalesManager
	{
		IEnumerable<SalesManager> GetAllSalesManagers();

		SalesManager GetSalesManager(int id);

		void AddSalesManager(SalesManager salesManager);

		void UpdateSalesManager(SalesManager salesManager);

		void DeleteSalesManager(int id);
	}
}