using System.ComponentModel.DataAnnotations;

namespace BoVoyage.WEB.Models
{
	public class AuthenticationLoginViewModel
	{
		[Display(Name = "Login")]
		[Required(ErrorMessage = "Le champ {0} est obligatoire.")]
		public string Mail { get; set; }

		[Display(Name = "Mot de passe")]
		[Required(ErrorMessage = "Le champ {0} est obligatoire.")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}