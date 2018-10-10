using BoVoyage.COMMON.Tools;
using BoVoyage.WEB.Validators;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage.WEB.Models.Base
{
	public class BasePersonViewModel : BaseModelViewModel
	{
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
		[RegularExpression(@"(0|\+33|0033)[1-9][0-9]{8}", ErrorMessage = "Le champ {0} doit être au format '0xxxxxxxxx, +33xxxxxxxxx ou 0033xxxxxxxxx'.")]
		[Phone]
		public string PhoneNumber { get; set; }
	}
}