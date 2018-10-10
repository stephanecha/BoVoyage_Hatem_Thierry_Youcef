using BoVoyage.DAL.Entites;
using System.Collections.Generic;

namespace BoVoyage.WEB.Models
{
	public class HomeIndexThreeSetsTravelsViewModel
	{
		public IEnumerable<Travel> LessExpensiveTravels { get; set; }
		public IEnumerable<Travel> SoonDepartureTravels { get; set; }
		public IEnumerable<Travel> TopCountriesTravels { get; set; }
	}
}