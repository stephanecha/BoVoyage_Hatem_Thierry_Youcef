using BoVoyage.COMMON.Tools;
using BoVoyage.DAL.Entites;
using BoVoyage.DAL.Validators;
using BoVoyage.WEB.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage.WEB.Models
{
	public sealed class TravelAgencyViewModel : BaseModelViewModel
	{
		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Agence de voyage")]
		[StringLength(40, ErrorMessage = MessageType.StringLengthField)]
		[UniqueTravelAgencyName(ErrorMessage = MessageType.OneFieldUnique)]
		public string Name { get; set; }

		[Display(Name = "Voyages")]
		public ICollection<Travel> Travels { get; set; }
	}
}