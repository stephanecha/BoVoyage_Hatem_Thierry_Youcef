using BoVoyage.DAL.Data.Base;
using BoVoyage.DAL.Data.Interface;
using BoVoyage.DAL.Entites;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BoVoyage.DAL.Data
{
	public class DbDataTraveler : DbDataBase, IDataTraveler
	{
		public void AddTraveler(Traveler traveler)
		{
			this.context.Travelers.Add(traveler);
			this.context.SaveChanges();
		}

		public void DeleteTraveler(int id)
		{
			Traveler traveler = this.context.Travelers.SingleOrDefault(x => x.ID == id);
			this.context.Travelers.Remove(traveler);
			this.context.SaveChanges();
		}

		public IEnumerable<Traveler> GetAllTravelers()
		{
			return this.context.Travelers.ToList();
		}

		public Traveler GetTraveler(int id)
		{
			return this.context.Travelers.SingleOrDefault(x => x.ID == id);
		}

		public void UpdateTraveler(Traveler traveler)
		{
			this.context.Travelers.Attach(traveler);
			this.context.Entry(traveler).State = EntityState.Modified;
			this.context.SaveChanges();
		}
	}
}