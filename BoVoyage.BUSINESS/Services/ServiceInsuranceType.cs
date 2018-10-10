using BoVoyage.DAL.Data.Interface;
using BoVoyage.DAL.Entites;
using System.Collections.Generic;

namespace BoVoyage.BUSINESS.Services
{
	public class ServiceInsuranceType
	{
		private readonly IDataInsuranceType dataInsuranceType;

		public ServiceInsuranceType(IDataInsuranceType dataInsuranceType)
		{
			this.dataInsuranceType = dataInsuranceType;
		}

		public IEnumerable<InsuranceType> GetAllInsuranceTypes()
		{
			return this.dataInsuranceType.GetAllInsuranceTypes();
		}

		public InsuranceType GetInsuranceType(int id)
		{
			return this.dataInsuranceType.GetInsuranceType(id);
		}

		public void AddInsuranceType(InsuranceType insuranceType)
		{
			//TODO: TESTS A FAIRE
			this.dataInsuranceType.AddInsuranceType(insuranceType);
		}

		public void UpdateInsuranceType(InsuranceType insuranceType)
		{
			//TODO: TESTS A FAIRE
			this.dataInsuranceType.UpdateInsuranceType(insuranceType);
		}

		public void DeleteInsuranceType(int id)
		{
			this.dataInsuranceType.DeleteInsuranceType(id);
		}
	}
}