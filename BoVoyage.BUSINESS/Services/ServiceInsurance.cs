using BoVoyage.DAL.Data.Interface;
using BoVoyage.DAL.Entites;
using System.Collections.Generic;
using System.Linq;

namespace BoVoyage.BUSINESS.Services
{
	public class ServiceInsurance
	{
		private readonly IDataInsurance dataInsurance;

		public ServiceInsurance(IDataInsurance dataInsurance)
		{
			this.dataInsurance = dataInsurance;
		}

		public IEnumerable<Insurance> GetAllInsurances()
		{
			return this.dataInsurance.GetAllInsurances();
		}

		public IEnumerable<Insurance> GetAllSelectedInsurances(int[] insurancesID)
		{
			return this.dataInsurance.GetAllInsurances().Where(x => insurancesID.Contains(x.ID)).ToList();
		}

		public IEnumerable<Insurance> GetAllInsurancesWithTypesIncluded()
		{
			return this.dataInsurance.GetAllInsurancesWithTypesIncluded();
		}

		public IEnumerable<Insurance> GetAllInsurancesWithTypesAndBookingFilesIncluded()
		{
			return this.dataInsurance.GetAllInsurancesWithTypesAndBookingFilesIncluded();
		}

		public Insurance GetInsurance(int id)
		{
			return this.dataInsurance.GetInsurance(id);
		}

		public Insurance GetInsuranceWithTypesIncluded(int id)
		{
			return this.dataInsurance.GetInsuranceWithTypesIncluded(id);
		}

		public void AddInsurance(Insurance insurance)
		{
			//TODO: TESTS A FAIRE
			this.dataInsurance.AddInsurance(insurance);
		}

		public void UpdateInsurance(Insurance insurance)
		{
			//TODO: TESTS A FAIRE
			this.dataInsurance.UpdateInsurance(insurance);
		}

		public void DeleteInsurance(int id)
		{
			this.dataInsurance.DeleteInsurance(id);
		}
	}
}