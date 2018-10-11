using BoVoyage.COMMON.Tools;
using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BoVoyage.WEB.Models
{
	public sealed class DestinationViewModel : BaseModelViewModel
	{
		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Continent")]
		[StringLength(40, ErrorMessage = MessageType.StringLengthField)]
		//TODO: Unique Continent, Country, Area and City
		public string Continent { get; set; }

		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Pays")]
		[StringLength(40, ErrorMessage = MessageType.StringLengthField)]
		public string Country { get; set; }

		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Région")]
		[StringLength(40, ErrorMessage = MessageType.StringLengthField)]
		public string Area { get; set; }

		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Ville")]
		[StringLength(40, ErrorMessage = MessageType.StringLengthField)]
		public string City { get; set; }

		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Description")]
		[StringLength(500, ErrorMessage = MessageType.StringLengthField)]
		[DataType(DataType.MultilineText)]
		[AllowHtml]
		public string Description { get; set; }

		[Display(Name = "Voyage(s)")]
		public ICollection<Travel> Travels { get; set; }

		// voir model depuis depot gitHub Archery dans les model
	}
}