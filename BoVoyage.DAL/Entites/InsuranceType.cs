using BoVoyage.DAL.Entites.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.DAL.Entites
{
	public sealed class InsuranceType : BaseModel
	{
		[Required]
		[Index(IsUnique = true)]
		[StringLength(40)]
		public string Type { get; set; }

		public ICollection<Insurance> Insurances { get; set; }
	}
}