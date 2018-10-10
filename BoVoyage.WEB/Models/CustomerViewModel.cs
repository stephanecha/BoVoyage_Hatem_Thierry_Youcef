using BoVoyage.COMMON.Tools;
using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage.WEB.Models
{
	public sealed class CustomerViewModel
	{
		[Display(Name = "Date d'inscription")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		[DataType(DataType.Date)]
		public DateTime CreatedOn { get; set; }

		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Date de naissance")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		[DataType(DataType.Date)]
		[AgeOver(18, ErrorMessage = "Vous devez avoir plus de 18 ans pour créer un compte.")]
		//TODO: Unique Civility, LastName, FirstName, Address and BirthDate
		public DateTime BirthDate { get; set; }

		[Display(Name = "Dossier(s) de Réservation")]
		public ICollection<BookingFile> BookingFiles { get; set; }
	}
}