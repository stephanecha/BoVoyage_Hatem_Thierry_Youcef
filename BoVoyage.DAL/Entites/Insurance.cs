using BoVoyage.DAL.Entites.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.DAL.Entites
{
	public sealed class Insurance : BaseModel
	{
		[Required]
		[Column(TypeName = "Money")]
		public decimal Price { get; set; }

		[Required]
		[StringLength(250)]
		public string Description { get; set; }

		public int InsuranceTypeID { get; set; }

		[ForeignKey("InsuranceTypeID")]
		public InsuranceType InsuranceType { get; set; }

		public ICollection<BookingFile> BookingFiles { get; set; }

		[NotMapped]
		public string FullName
		{
			get
			{
				return string.Format("{0} - {1}€", InsuranceType.Type, Price);
			}
		}
	}
}