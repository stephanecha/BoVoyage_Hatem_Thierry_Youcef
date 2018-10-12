using BoVoyage.COMMON.Tools;
using BoVoyage.WEB.Validators;
using BoVoyage.WEB.Validators.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage.WEB.Models
{
	public class TravelIndexSearchViewModel
	{
		[Display(Name = "Date aller après le")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime? DepartureDate { get; set; }

		[Display(Name = "Date retour avant le")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		[DateComparaison(CompareCase.OVER, "DepartureDate", ErrorMessage = "Le champ {0} doit être après {1}")]
		public DateTime? ReturnDate { get; set; }

		[Display(Name = "Places disponibles minimun")]
		[IntDecimalOverZero(ErrorMessage = "Le champ {0} doit être supérieur ou égal à 0.")]
		public int? AvailablePlaces { get; set; }

		[Display(Name = "Prix par personne minimun")]
		[DisplayFormat(DataFormatString = "{0:C02}")]
		[IntDecimalOverZero(ErrorMessage = MessageType.MustBeOverZero)]
		[DataType(DataType.Currency)]
		public decimal? PricePerPersonMin { get; set; }

		[Display(Name = "Prix par personne maximun")]
		[DisplayFormat(DataFormatString = "{0:C02}")]
		[DataType(DataType.Currency)]
		[DecimalComparaison(CompareCase.OVER, "PricePerPersonMin", ErrorMessage = "Le champ {0} doit être supérieur au champ {1}")]
		public decimal? PricePerPersonMax { get; set; }

		[Display(Name = "Agence de voyage")]
		[StringLength(40, ErrorMessage = MessageType.StringLengthField)]
		public string TravelAgencyName { get; set; }

		[Display(Name = "Continent")]
		[StringLength(40, ErrorMessage = MessageType.StringLengthField)]
		public string Continent { get; set; }

		[Display(Name = "Pays")]
		[StringLength(40, ErrorMessage = MessageType.StringLengthField)]
		public string Country { get; set; }

		[Display(Name = "Ville")]
		[StringLength(40, ErrorMessage = MessageType.StringLengthField)]
		public string City { get; set; }

		[Display(Name = "Liste des voyages")]
		public IEnumerable<TravelViewModel> TravelViewModel { get; set; }
	}
}