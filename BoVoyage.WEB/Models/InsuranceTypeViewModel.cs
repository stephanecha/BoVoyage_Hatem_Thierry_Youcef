using BoVoyage.COMMON.Tools;
using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage.WEB.Models
{
	public sealed class InsuranceTypeViewModel : BaseModelViewModel
	{
		[Required(ErrorMessage = MessageType.RequiredField)]
		[StringLength(40, ErrorMessage = MessageType.StringLengthField)]
		[Display(Name = "Type d'assurance")]
		//TODO: Unique Type
		public string Type { get; set; }

		[Display(Name = "Assurances de ce type")]
		public ICollection<Insurance> Insurances { get; set; }
	}
}