using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Models;
using System.Collections.Generic;
using System.Linq;

namespace BoVoyage.WEB.Tools
{
	public static class TransformModelDestination
	{
		public static DestinationViewModel DestinationToModelView(Destination destination)
		{
			DestinationViewModel destinationToModelView = new DestinationViewModel()
			{
				ID = destination.ID,
				Continent = destination.Continent,
				Country = destination.Country,
				Area = destination.Area,
				City = destination.City,
				Description = destination.Description,

                Pictures = destination.DestinationPicture,
                Travels = destination.Travels == null ? null : TransformModelTravel.TravelToModelView(destination.Travels)

            };

			return destinationToModelView;
		}

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
                    Pictures = x.DestinationPicture,

                    Travels = x.Travels == null ? null : TransformModelTravel.TravelToModelView(x.Travels)

                }).ToList());
			return destinationToModelView;
		}

		public static Destination DestinationModelViewToModel(DestinationViewModel destinationToModelView)
		{
			Destination destination = new Destination()
			{
				ID = destinationToModelView.ID,
				Continent = destinationToModelView.Continent,
				Country = destinationToModelView.Country,
				Area = destinationToModelView.Area,
				City = destinationToModelView.City,
				Description = destinationToModelView.Description,
                DestinationPicture = destinationToModelView.Pictures,
                Travels = destinationToModelView.Travels == null ? null : TransformModelTravel.TravelModelViewToModel(destinationToModelView.Travels)
			};

			return destination;
		}
	}
}