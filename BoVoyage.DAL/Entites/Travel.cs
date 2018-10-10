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
		[Index("IX_DatesPriceTravelAgencyDestination", 1, IsUnique = true)]
		[Column(TypeName = "datetime")]
		public DateTime DepartureDate { get; set; }

		[Required]
		[Index("IX_DatesPriceTravelAgencyDestination", 2, IsUnique = true)]
		[Column(TypeName = "datetime")]
		public DateTime ReturnDate { get; set; }

		[Required]
		public int AvailablePlaces { get; set; }

		[Required]
		[Index("IX_DatesPriceTravelAgencyDestination", 3, IsUnique = true)]
		[Column(TypeName = "Money")]
		public decimal PricePerPerson { get; set; }

		[Index("IX_DatesPriceTravelAgencyDestination", 4, IsUnique = true)]
		public int TravelAgencyID { get; set; }

		[ForeignKey("TravelAgencyID")]
		public TravelAgency TravelAgency { get; set; }

		[Index("IX_DatesPriceTravelAgencyDestination", 5, IsUnique = true)]
		public int DestinationID { get; set; }

		[ForeignKey("DestinationID")]
		public Destination Destination { get; set; }

		public ICollection<BookingFile> BookingFiles { get; set; }
	}
}