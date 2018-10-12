using BoVoyage.COMMON.Tools;
using BoVoyage.WEB.Models.Base;
using BoVoyage.WEB.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage.WEB.Models
{
	public class SalesManagerViewModel : BasePersonViewModel
	{
		[Display(Name = "Date de naissance")]
		[Required(ErrorMessage = MessageType.RequiredField)]
		[DataType(DataType.Date)]
		[AgeOver(18, ErrorMessage = "Vous devez avoir plus de 18 ans pour créer un compte.")]
		public DateTime BirthDate { get; set; }

		[Required(ErrorMessage = MessageType.RequiredField)]
		[StringLength(60, ErrorMessage = MessageType.StringLengthField)]
		[Display(Name = "Adresse mail")]
		[RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@bovoyage([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
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
	}
}