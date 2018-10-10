using BoVoyage.COMMON.Tools;
using BoVoyage.DAL.Entites;
using BoVoyage.DAL.Entites.Enum;
using BoVoyage.WEB.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage.WEB.Models
{
	public class BookingFileViewModel : BaseModelViewModel
	{
		[Required]
		[Display(Name = "Numéro de dossier de réservation")]
		public string SequentialNb { get; set; }

		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Numéro de carte bleue")]
		[StringLength(40, ErrorMessage = MessageType.StringLengthField)]
		[DataType(DataType.CreditCard)]
		public string CreditCardNb { get; set; }

		[Display(Name = "Prix par personne")]
		[DataType(DataType.Currency)]
		public decimal PricePerPerson { get; set; }

		[Display(Name = "Prix total")]
		[DataType(DataType.Currency)]
		public decimal TotalPrice { get; set; }

		[Display(Name = "Etat du dossier de réservation")]
		[EnumDataType(typeof(BookingFileState))]
		public BookingFileState State { get; set; }

		public int CustomerID { get; set; }

		public int TravelID { get; set; }

		[Display(Name = "Assurances")]
		public ICollection<Insurance> Insurances { get; set; }

		[Display(Name = "Participants")]
		public ICollection<Traveler> Travelers { get; set; }
	}
}