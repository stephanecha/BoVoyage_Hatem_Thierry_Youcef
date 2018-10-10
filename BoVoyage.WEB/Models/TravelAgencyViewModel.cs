using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage.WEB.Models
{
	public sealed class TravelAgencyViewModel : BaseModelViewModel
	{
		[Required(ErrorMessage = "Le champ {0} est obligatoire.")]
		[Display(Name = "Agence de voyage")]
		[StringLength(40, ErrorMessage = "Le champ {0} doit contenir {1} caractères max.")]
		//TODO: Validator Unique name in databse
		public string Name { get; set; }

		[Display(Name = "Voyages")]
		public ICollection<Travel> Travels { get; set; }
	}
}