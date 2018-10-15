using BoVoyage.DAL.Entites.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.DAL.Entites
{
	public sealed class Destination : BaseModel
	{
		[Required]
		[Index("IX_ContinentCountryAreaCity", 1, IsUnique = true)]
		[StringLength(40)]
		public string Continent { get; set; }

		[Required]
		[Index("IX_ContinentCountryAreaCity", 2, IsUnique = true)]
		[StringLength(40)]
		public string Country { get; set; }

		[Required]
		[Index("IX_ContinentCountryAreaCity", 3, IsUnique = true)]
		[StringLength(40)]
		public string Area { get; set; }

		[Required]
		[Index("IX_ContinentCountryAreaCity", 4, IsUnique = true)]
		[StringLength(40)]
		public string City { get; set; }

		[Required]
		[StringLength(500)]
		public string Description { get; set; }

		public ICollection<Travel> Travels { get; set; }

        [Display(Name = "Images")]
        public ICollection<DestinationPicture> DestinationPicture { get; set; }


        [NotMapped]
		public string FullName
		{
			get
			{
				return string.Format("{0} - {1}", Country, City);
			}
		}
	}
}