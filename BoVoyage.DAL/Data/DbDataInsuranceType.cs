using BoVoyage.DAL.Data.Base;
using BoVoyage.DAL.Data.Interface;
using BoVoyage.DAL.Entites;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BoVoyage.DAL.Data
{
	public class DbDataInsuranceType : DbDataBase, IDataInsuranceType
	{
		public void AddInsuranceType(InsuranceType insuranceType)
		{
			this.context.InsuranceTypes.Add(insuranceType);
			this.context.SaveChanges();
		}

		public void DeleteInsuranceType(int id)
		{
			InsuranceType insuranceType = this.context.InsuranceTypes.Single(x => x.ID == id);
			this.context.InsuranceTypes.Remove(insuranceType);
			this.context.SaveChanges();
		}

		public IEnumerable<InsuranceType> GetAllInsuranceTypes()
		{
			return this.context.InsuranceTypes.ToList();
		}

		public IEnumerable<InsuranceType> GetAllInsuranceTypesWithInsurancesIncluded()
		{
			return this.context.InsuranceTypes.Include("Insurances").ToList();
		}

		public InsuranceType GetInsuranceType(int id)
		{
			return this.context.InsuranceTypes.Single(x => x.ID == id);
		}

		public void UpdateInsuranceType(InsuranceType insuranceType)
		{
			this.context.InsuranceTypes.Attach(insuranceType);
			this.context.Entry(insuranceType).State = EntityState.Modified;
			this.context.SaveChanges();
		}
	}
}