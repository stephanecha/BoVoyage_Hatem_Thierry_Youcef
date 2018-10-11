using BoVoyage.DAL.Entites;
using System.Collections.Generic;

namespace BoVoyage.DAL.Data.Interface
{
	public interface IDataInsurance
	{
		IEnumerable<Insurance> GetAllInsurances();

		IEnumerable<Insurance> GetAllInsurancesWithTypesIncluded();

		IEnumerable<Insurance> GetAllInsurancesWithTypesAndBookingFilesIncluded();

		Insurance GetInsurance(int id);

		Insurance GetInsuranceWithTypesIncluded(int id);

		void AddInsurance(Insurance insurance);

		void UpdateInsurance(Insurance insurance);

		void DeleteInsurance(int id);
	}
}