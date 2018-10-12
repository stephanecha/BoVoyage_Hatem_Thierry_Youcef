using BoVoyage.WEB.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage.WEB.Models
{
	public class SalesManagerViewModel : BasePersonViewModel
	{
		[Required]
		public DateTime BirthDate { get; set; }

		public int Age
		{
			get { return DateTime.Today.Year - BirthDate.Year; }
		}

		[Required]
		[StringLength(60)]
		public string Email { get; set; }

		[Required]
		[StringLength(250)]
		public string Password { get; set; }

		public string ConfirmedPassword { get; set; }
	}
}