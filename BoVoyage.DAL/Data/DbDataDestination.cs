using BoVoyage.DAL.Data.Base;
using BoVoyage.DAL.Data.Interface;
using BoVoyage.DAL.Entites;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BoVoyage.DAL.Data
{
	public class DbDataDestination : DbDataBase, IDataDestination
	{
		public void AddDestination(Destination destination)
		{
			this.context.Destinations.Add(destination);
			this.context.SaveChanges();
		}

		public void DeleteDestination(int id)
		{
			Destination destination = this.context.Destinations.SingleOrDefault(x => x.ID == id);
			this.context.Destinations.Remove(destination);
			this.context.SaveChanges();
		}

		public IEnumerable<Destination> GetAllDestinations()
		{
			return this.context.Destinations.ToList();
		}

		public IEnumerable<Destination> GetAllDestinationsWithTravelsIncluded()
		{
			return this.context.Destinations.Include("Travels").ToList();
		}

		public Destination GetDestination(int id)
		{
			return this.context.Destinations.Include("DestinationPicture").SingleOrDefault(x => x.ID == id);
		}

		public Destination GetDestinationWithTravelsIncluded(int id)
		{
			return this.context.Destinations.Include("Travels").Include("DestinationPicture").SingleOrDefault(x => x.ID == id);
		}

		public void UpdateDestination(Destination destination)
		{
			this.context.Destinations.Attach(destination);
			this.context.Entry(destination).State = EntityState.Modified;
			this.context.SaveChanges();
		}
	}
}