﻿using BoVoyage.DAL.Data.Base;
using BoVoyage.DAL.Data.Interface;
using BoVoyage.DAL.Entites;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BoVoyage.DAL.Data
{
	public class DbDataInsurance : DbDataBase, IDataInsurance
	{
		public void AddInsurance(Insurance insurance)
		{
			this.context.Insurances.Add(insurance);
			this.context.SaveChanges();
		}

		public void DeleteInsurance(int id)
		{
			Insurance insurance = this.context.Insurances.SingleOrDefault(x => x.ID == id);
			this.context.Insurances.Remove(insurance);
			this.context.SaveChanges();
		}

		public IEnumerable<Insurance> GetAllInsurances()
		{
			return this.context.Insurances.ToList();
		}

		public IEnumerable<Insurance> GetAllInsurancesWithTypesAndBookingFilesIncluded()
		{
			return this.context.Insurances.Include("InsuranceType").Include("BookingFiles").ToList();
		}

		public IEnumerable<Insurance> GetAllInsurancesWithTypesIncluded()
		{
			return this.context.Insurances.Include("InsuranceType").ToList();
		}

		public Insurance GetInsurance(int id)
		{
			return this.context.Insurances.SingleOrDefault(x => x.ID == id);
		}

		public Insurance GetInsuranceWithTypesIncluded(int id)
		{
			return this.context.Insurances.Include("InsuranceType").SingleOrDefault(x => x.ID == id);
		}

		public void UpdateInsurance(Insurance insurance)
		{
			this.context.Insurances.Attach(insurance);
			this.context.Entry(insurance).State = EntityState.Modified;
			this.context.SaveChanges();
		}
	}
}