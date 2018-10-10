using BoVoyage.DAL.Data.Interface;
using BoVoyage.DAL.Entites;
using System.Collections.Generic;

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

		public Insurance GetInsurance(int id)
		{
			return this.dataInsurance.GetInsurance(id);
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