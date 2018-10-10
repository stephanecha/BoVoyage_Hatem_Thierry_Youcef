using BoVoyage.DAL.Entites.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.DAL.Entites
{
	public sealed class Traveler : BasePerson
	{
		[Required]
		[Index(IsUnique = true)]
		[StringLength(60)]
		public string SequentialNb { get; set; }

		public int BookingFileID { get; set; }

		[ForeignKey("BookingFileID")]
		public BookingFile BookingFile { get; set; }
	}
}