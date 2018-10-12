using System.Collections.Generic;

namespace BoVoyage.WEB.Models
{
	public class ReservationViewModel
	{
		public BookingFileViewModel BookingFileViewModel { get; set; }

		public CustomerViewModel CustomerViewModel { get; set; }

		public TravelViewModel TravelViewModel { get; set; }

		public IEnumerable<TravelerViewModel> TravelersList { get; set; }
	}
}