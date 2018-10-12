using BoVoyage.COMMON.Tools;
using BoVoyage.DAL.Entites.Enum;
using BoVoyage.WEB.Models.Base;
using BoVoyage.WEB.Validators;
using BoVoyage.WEB.Validators.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage.WEB.Models
{
	public class TravelerViewModel : BasePersonViewModel
	{
		[Display(Name = "Numéro de participant")]
		//TODO: how to do SequentialNb
		public string SequentialNb { get; set; }

		[Required(ErrorMessage = MessageType.RequiredField)]
		[Display(Name = "Date de naissance")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		[DataType(DataType.Date)]
		[DateBeforeAfterToday(CompareCase.BELOW, ErrorMessage = "Le champ {0} doit être avant aujourd'hui.")]
		//TODO: Unique Civility, LastName, FirstName, Address and BirthDate
		public DateTime BirthDate { get; set; }

		public int Age
		{
			get { return DateTime.Today.Year - BirthDate.Year; }
		}

		[Display(Name = "Réduction")]
		public float Discount
		{
			get
			{
				if (this.Age < 12)
					return DiscountTypeEnum.UnderTwelve;
				else
					return DiscountTypeEnum.NoDiscount;
			}
		}

		[Display(Name = "Dossier de Réservation")]
		public int BookingFileID { get; set; }
	}
}