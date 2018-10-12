using BoVoyage.DAL.Entites.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyage.DAL.Entites
{
	public sealed class Customer : BasePerson
	{
		[Required]
		public DateTime CreatedOn { get; set; }

		public ICollection<BookingFile> BookingFiles { get; set; }

		public int AuthentificationID { get; set; }

		[ForeignKey("AuthentificationID")]
		public Authentification Authentification { get; set; }
	}
}