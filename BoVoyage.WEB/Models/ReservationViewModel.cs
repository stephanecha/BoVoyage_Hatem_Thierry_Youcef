using BoVoyage.COMMON.Tools;
using BoVoyage.DAL.Entites;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage.WEB.Models
{
	public class ReservationViewModel
	{
		[Display(Name = "Client")]
		public CustomerViewModel CustomerViewModel { get; set; }

		[Display(Name = "Voyage")]
		public TravelViewModel TravelViewModel { get; set; }

		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Nombre de voyageurs")]
		[Range(1, 9, ErrorMessage = "Le {1} doit être compris entre {1} et {2}.")]
		public int NbTraveler { get; set; }

		[Display(Name = "Assurance(s) séléctionnée(s)")]
		public ICollection<Insurance> Insurances { get; set; }

		[Display(Name = "Prix par personne")]
		[DataType(DataType.Currency)]
		public decimal PricePerPerson { get; set; }

		[Display(Name = "Prix total")]
		[DataType(DataType.Currency)]
		public decimal TotalPrice { get; set; }

		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Participez-vous au voyage ?")]
		public bool IsTraveler { get; set; }

		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Numéro de carte bleue")]
		[StringLength(40, ErrorMessage = MessageType.StringLengthField)]
		[DataType(DataType.CreditCard)]
		[CreditCard]
		public string CreditCardNb { get; set; }
	}
}