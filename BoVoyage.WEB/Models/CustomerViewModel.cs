using BoVoyage.COMMON.Tools;
using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Models.Base;
using BoVoyage.WEB.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage.WEB.Models
{
	public sealed class CustomerViewModel : BasePersonViewModel
	{
		[Display(Name = "Date d'inscription")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		[DataType(DataType.Date)]
		public DateTime CreatedOn { get; set; }

		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Date de naissance")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		[DataType(DataType.Date)]
		[AgeOver(18, ErrorMessage = "Vous devez avoir plus de 18 ans pour créer un compte.")]
		//TODO: Unique Civility, LastName, FirstName, Address and BirthDate
		public DateTime BirthDate { get; set; }

		[Required(ErrorMessage = MessageType.RequiredField)]
		[StringLength(60, ErrorMessage = MessageType.StringLengthField)]
		[Display(Name = "Adresse mail")]
		[RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
			, ErrorMessage = "Le format n'est pas bon.")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Display(Name = "Mot de passe")]
		[DataType(DataType.Password)]
		[Required(ErrorMessage = MessageType.RequiredField)]
		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$",
			ErrorMessage = "{0} incorrect.")]
		[StringLength(60)]
		public string Password { get; set; }

		[Display(Name = "Confirmation du mot de passe")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "La confirmation n'est pas bonne.")]
		public string ConfirmedPassword { get; set; }

		[Display(Name = "Dossier(s) de Réservation")]
		public ICollection<BookingFile> BookingFiles { get; set; }
	}
}