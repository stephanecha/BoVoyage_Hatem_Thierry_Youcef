using BoVoyage.DAL.Entites.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.DAL.Entites
{
	public sealed class Travel : BaseModel
	{
		[Required]
		[Column(TypeName = "datetime")]
		public DateTime DepartureDate { get; set; }

		[Required]
		[Column(TypeName = "datetime")]
		public DateTime ReturnDate { get; set; }

		[Required]
		public int AvailablePlaces { get; set; }

		[Required]
		[Column(TypeName = "Money")]
		public decimal PricePerPerson { get; set; }

		public int TravelAgencyID { get; set; }

		[ForeignKey("TravelAgencyID")]
		public TravelAgency TravelAgency { get; set; }

		public int DestinationID { get; set; }

		[ForeignKey("DestinationID")]
		public Destination Destination { get; set; }

		public ICollection<BookingFile> BookingFiles { get; set; }
	}
}