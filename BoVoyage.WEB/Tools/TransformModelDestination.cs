using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Models;
using System.Collections.Generic;
using System.Linq;

namespace BoVoyage.WEB.Tools
{
	public static class TransformModelDestination
	{
		public static List<DestinationViewModel> DestinationToModelView(IEnumerable<Destination> listDestinations)
		{
			List<DestinationViewModel> destinationToModelView = new List<DestinationViewModel>(listDestinations.Select(x =>
				new DestinationViewModel()
				{
					ID = x.ID,
					Description = x.Description,
					City = x.City,
					Area = x.Area,
					Continent = x.Continent,
					Country = x.Country,
					Travels = x.Travels
				}).ToList());
			return destinationToModelView;
		}
	}
}