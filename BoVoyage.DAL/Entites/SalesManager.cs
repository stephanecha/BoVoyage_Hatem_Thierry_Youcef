using BoVoyage.DAL.Entites.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.DAL.Entites
{
	public sealed class SalesManager : BasePerson
	{
		public int AuthentificationID { get; set; }

		[ForeignKey("AuthentificationID")]
		public Authentification Authentification { get; set; }
	}
}