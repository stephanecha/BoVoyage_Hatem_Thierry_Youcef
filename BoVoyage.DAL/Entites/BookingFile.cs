using BoVoyage.DAL.Entites.Base;
using BoVoyage.DAL.Entites.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.DAL.Entites
{
	public sealed class BookingFile : BaseModel
	{
		[Required]
		[Index(IsUnique = true)]
		[StringLength(60)]
		public string SequentialNb { get; set; }

		[Required]
		[StringLength(40)]
		public string CreditCardNb { get; set; }

		[Required]
		[Column(TypeName = "Money")]
		public decimal PricePerPerson { get; set; }

		[Required]
		[Column(TypeName = "Money")]
		public decimal TotalPrice { get; set; }

		[Required]
		[EnumDataType(typeof(BookingFileState))]
		public BookingFileState State { get; set; }

		public int CustomerID { get; set; }

		[ForeignKey("CustomerID")]
		public Customer Customer { get; set; }

		public int TravelID { get; set; }

		[ForeignKey("TravelID")]
		public Travel Travel { get; set; }

		public ICollection<Insurance> Insurances { get; set; }

		public ICollection<Traveler> Travelers { get; set; }
	}
}