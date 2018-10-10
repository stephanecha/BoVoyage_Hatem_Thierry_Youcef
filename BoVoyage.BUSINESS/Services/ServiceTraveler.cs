using BoVoyage.DAL.Data.Interface;
using BoVoyage.DAL.Entites;
using System.Collections.Generic;

namespace BoVoyage.BUSINESS.Services
{
	public class ServiceTraveler
	{
		private readonly IDataTraveler dataTraveler;

		public ServiceTraveler(IDataTraveler dataTraveler)
		{
			this.dataTraveler = dataTraveler;
		}

		public IEnumerable<Traveler> GetAllTravelers()
		{
			return this.dataTraveler.GetAllTravelers();
		}

		public Traveler GetTraveler(int id)
		{
			return this.dataTraveler.GetTraveler(id);
		}

		public void AddTraveler(Traveler traveler)
		{
			//TODO: TESTS A FAIRE
			this.dataTraveler.AddTraveler(traveler);
		}

		public void UpdateTraveler(Traveler traveler)
		{
			//TODO: TESTS A FAIRE
			this.dataTraveler.UpdateTraveler(traveler);
		}

		public void DeleteTraveler(int id)
		{
			this.dataTraveler.DeleteTraveler(id);
		}
	}
}