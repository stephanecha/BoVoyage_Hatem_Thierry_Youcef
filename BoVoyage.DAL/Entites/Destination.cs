using BoVoyage.DAL.Entites.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.DAL.Entites
{
	public sealed class Destination : BaseModel
	{
		[Required]
		[Index("IX_ContinentCountryArea", 1, IsUnique = true)]
		[StringLength(40)]
		public string Continent { get; set; }

		[Required]
		[Index("IX_ContinentCountryArea", 2, IsUnique = true)]
		[StringLength(40)]
		public string Country { get; set; }

		[Required]
		[Index("IX_ContinentCountryArea", 3, IsUnique = true)]
		[StringLength(40)]
		public string Area { get; set; }

		public string Description { get; set; }

		public ICollection<Travel> Travels { get; set; }
	}
}