using BoVoyage.COMMON.Tools;
using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Models.Base;
using BoVoyage.WEB.Validators;
using BoVoyage.WEB.Validators.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage.WEB.Models
{
	public sealed class TravelViewModel : BaseModelViewModel
	{
		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Date aller")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		[DateBeforeAfterToday(CompareDateCase.AFTER, ErrorMessage = "Le champ {0} doit être après aujourd'hui.")]
		//TODO: Unique DepartureDate, ReturnDate, TravelAgencyID and DestinationID and PricePerPerson
		public DateTime DepartureDate { get; set; }

		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Date retour")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		[DateComparaison(CompareDateCase.AFTER, "DepartureDate", ErrorMessage = "Le champ {0} doit être après {1}")]
		public DateTime ReturnDate { get; set; }

		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Places disponibles")]
		[IntDecimalOverZero(ErrorMessage = "Le champ {0} doit être supérieur ou égal à 0.")]
		public int AvailablePlaces { get; set; }

		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Prix par personne")]
		[DisplayFormat(DataFormatString = "{0:C02}")]
		[IntDecimalOverZero(ErrorMessage = MessageType.MustBeOverZero)]
		[DataType(DataType.Currency)]
		public decimal PricePerPerson { get; set; }

		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Agence de voyage")]
		public int TravelAgencyID { get; set; }

		[Display(Name = "Destination")]
		public Destination Destination { get; set; }

		[Display(Name = "Dossier(s) de Réservation")]
		public ICollection<BookingFile> BookingFiles { get; set; }
	}
}