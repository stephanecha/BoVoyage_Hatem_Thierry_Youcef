using BoVoyage.DAL.Entites.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.DAL.Entites
{
	public sealed class Authentification : BaseModel
	{
		[Required]
		[Index(IsUnique = true)]
		[StringLength(60)]
		public string Email { get; set; }

		[Required]
		[StringLength(250)]
		public string Password { get; set; }

		[NotMapped]
		public string ConfirmedPassword { get; set; }
	}
}