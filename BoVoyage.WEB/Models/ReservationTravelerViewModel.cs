using BoVoyage.COMMON.Tools;
using BoVoyage.WEB.Validators;
using BoVoyage.WEB.Validators.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage.WEB.Models
{
	public class ReservationTravelerViewModel
	{
		[Display(Name = "Nombre de voyageurs")]
		public int NbTtravelers { get; set; }

		public int TravelerInProgress { get; set; }

		public List<TravelerViewModel> ListTravelers { get; set; }

		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Civilité")]
		[StringLength(20, ErrorMessage = MessageType.StringLengthField)]
		[RegexLetterAndDash(ErrorMessage = MessageType.RegexLetterAndDashErrorMessage)]
		public string Civility { get; set; }

		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Nom")]
		[StringLength(30, ErrorMessage = MessageType.StringLengthField)]
		[RegexLetterAndDash(ErrorMessage = MessageType.RegexLetterAndDashErrorMessage)]
		public string LastName { get; set; }

		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Prénom")]
		[StringLength(30, ErrorMessage = MessageType.StringLengthField)]
		[RegexLetterAndDash(ErrorMessage = MessageType.RegexLetterAndDashErrorMessage)]
		public string FirstName { get; set; }

		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Adresse")]
		[StringLength(60, ErrorMessage = MessageType.StringLengthField)]
		public string Address { get; set; }

		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Téléphone")]
		[StringLength(20, ErrorMessage = MessageType.StringLengthField)]
		[DataType(DataType.PhoneNumber)]
		[RegularExpression(@"(0|\+33|0033)[1-9][0-9]{8}", ErrorMessage = "Le {0} doit être au format '0xxxxxxxxx, +33xxxxxxxxx ou 0033xxxxxxxxx'.")]
		[Phone]
		public string PhoneNumber { get; set; }

		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Date de naissance")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		[DataType(DataType.Date)]
		[DateBeforeAfterToday(CompareCase.BELOW, ErrorMessage = "Le champ {0} doit être avant aujourd'hui.")]
		//TODO: Unique Civility, LastName, FirstName, Address and BirthDate
		public DateTime BirthDate { get; set; }
	}
}