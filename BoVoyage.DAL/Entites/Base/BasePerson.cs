using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.DAL.Entites.Base
{
	public abstract class BasePerson : BaseModel
	{
		[Required]
		[Index("IX_UniquePerson", 1, IsUnique = true)]
		[StringLength(20)]
		public string Civility { get; set; }

		[Required]
		[Index("IX_UniquePerson", 2, IsUnique = true)]
		[StringLength(30)]
		public string LastName { get; set; }

		[Required]
		[Index("IX_UniquePerson", 3, IsUnique = true)]
		[StringLength(30)]
		public string FirstName { get; set; }

		[Required]
		[Index("IX_UniquePerson", 4, IsUnique = true)]
		[StringLength(60)]
		public string Address { get; set; }

		[Required]
		[StringLength(20)]
		public string PhoneNumber { get; set; }

		[Required]
		[Column(TypeName = "datetime2")]
		public DateTime BirthDate { get; set; }

		[NotMapped]
		public int Age
		{
			get { return DateTime.Today.Year - BirthDate.Year; }
		}
	}
}