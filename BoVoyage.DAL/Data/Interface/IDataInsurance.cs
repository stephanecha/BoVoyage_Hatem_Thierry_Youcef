using BoVoyage.DAL.Entites;
using System.Collections.Generic;

namespace BoVoyage.DAL.Data.Interface
{
	public interface IDataInsurance
	{
		IEnumerable<Insurance> GetAllInsurances();

		Insurance GetInsurance(int id);

		void AddInsurance(Insurance insurance);

		void UpdateInsurance(Insurance insurance);

		void DeleteInsurance(int id);
	}
}