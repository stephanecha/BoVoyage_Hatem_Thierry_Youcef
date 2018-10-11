using BoVoyage.COMMON.Tools;
using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Models.Base;
using BoVoyage.WEB.Validators;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BoVoyage.WEB.Models
{
	public class InsuranceViewModel : BaseModelViewModel
	{
		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Prix par personne")]
		[IntDecimalOverZero]
		//TODO: Unique Price and InsuranceTypeID
		public decimal Price { get; set; }

		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Description de l'assurance")]
		[StringLength(250, ErrorMessage = MessageType.StringLengthField)]
		[DataType(DataType.MultilineText)]
		[AllowHtml]
		public string Description { get; set; }

		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Type d'assurance")]
		public int InsuranceTypeID { get; set; }

        [Display(Name = "Type d'assurance")]
        public InsuranceType InsuranceType { get; set; }

    }
}