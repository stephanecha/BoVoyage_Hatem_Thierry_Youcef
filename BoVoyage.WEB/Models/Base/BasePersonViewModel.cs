using BoVoyage.WEB.Validators;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage.WEB.Models.Base
{
	public class BasePersonViewModel : BaseModelViewModel
	{
		[Required(ErrorMessage = "Le champ {0} est obligatoire.")]
		[Display(Name = "Civilité")]
		[StringLength(20, ErrorMessage = "Le champ {0} doit contenir {1} caractères max.")]
		[RegexLetterAndDash(ErrorMessage = "Le champ {0} ne peut pas contenir des chiffres ou des caractères spéciaux.")]
		//[Index("IX_UniquePerson", 1, IsUnique = true)]
		public string Civility { get; set; }

		[Required(ErrorMessage = "Le champ {0} est obligatoire.")]
		[Display(Name = "Nom")]
		[StringLength(30, ErrorMessage = "Le champ {0} doit contenir {1} caractères max.")]
		[RegexLetterAndDash(ErrorMessage = "Le champ {0} ne peut pas contenir des chiffres ou des caractères spéciaux.")]
		//[Index("IX_UniquePerson", 2, IsUnique = true)]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Le champ {0} est obligatoire.")]
		[Display(Name = "Prénom")]
		[StringLength(30, ErrorMessage = "Le champ {0} doit contenir {1} caractères max.")]
		[RegexLetterAndDash(ErrorMessage = "Le champ {0} ne peut pas contenir des chiffres ou des caractères spéciaux.")]
		//[Index("IX_UniquePerson", 3, IsUnique = true)]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Le champ {0} est obligatoire.")]
		[Display(Name = "Adresse")]
		[StringLength(60, ErrorMessage = "Le champ {0} doit contenir {1} caractères max.")]
		//[Index("IX_UniquePerson", 4, IsUnique = true)]
		public string Address { get; set; }

		[Required(ErrorMessage = "Le champ {0} est obligatoire.")]
		[Display(Name = "Téléphone")]
		[StringLength(20, ErrorMessage = "Le champ {0} doit contenir {1} caractères max.")]
		[DataType(DataType.PhoneNumber)]
		[RegularExpression(@"(0|\+33|0033)[1-9][0-9]{8}", ErrorMessage = "Le champ {0} doit être au format '0xxxxxxxxx'.")]
		[Phone]
		public string PhoneNumber { get; set; }
	}
}