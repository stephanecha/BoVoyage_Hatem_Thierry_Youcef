using BoVoyage.DAL.Entites;
using System.Collections.Generic;

namespace BoVoyage.DAL.Data.Interface
{
	public interface IDataInsuranceType
	{
		IEnumerable<InsuranceType> GetAllInsuranceTypes();

		InsuranceType GetInsuranceType(int id);

		void AddInsuranceType(InsuranceType insuranceType);

		void UpdateInsuranceType(InsuranceType insuranceType);

		void DeleteInsuranceType(int id);
	}
}