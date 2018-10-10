using BoVoyage.DAL.Entites.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.DAL.Entites
{
	public sealed class Insurance : BaseModel
	{
		[Required]
		[Index("IX_PriceType", 1, IsUnique = true)]
		[Column(TypeName = "Money")]
		public decimal Price { get; set; }

        //Description champ requis ??
		public string Description { get; set; }

		[Index("IX_PriceType", 2, IsUnique = true)]
		public int InsuranceTypeID { get; set; }

		[ForeignKey("InsuranceTypeID")]
		public InsuranceType InsuranceType { get; set; }

		public ICollection<BookingFile> BookingFiles { get; set; }
	}
}