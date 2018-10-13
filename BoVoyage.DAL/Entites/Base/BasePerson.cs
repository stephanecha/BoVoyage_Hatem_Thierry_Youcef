using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.DAL.Entites.Base
{
	public abstract class BasePerson : BaseModel
	{
		[Required]
		[StringLength(20)]
		public string Civility { get; set; }

		[Required]
		[StringLength(30)]
		public string LastName { get; set; }

		[Required]
		[StringLength(30)]
		public string FirstName { get; set; }

		[Required]
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