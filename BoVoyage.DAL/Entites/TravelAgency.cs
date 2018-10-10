using BoVoyage.DAL.Entites.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.DAL.Entites
{
	public sealed class TravelAgency : BaseModel
	{
		[Required]
		[Index(IsUnique = true)]
		[StringLength(40)]
		public string Name { get; set; }

		public ICollection<Travel> Travels { get; set; }
	}
}