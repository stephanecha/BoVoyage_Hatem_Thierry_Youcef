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
		//TODO: how to do UniqueNb
		public int SequentialNb { get; set; }

		[Required(ErrorMessage = "Le champ {0} est obligatoire.")]
		[Display(Name = "Date de naissance")]
		[DataType(DataType.Date)]
		[DateBeforeAfterToday(CompareDateCase.BEFORE, ErrorMessage = "Le champ {0} doit être avant aujourd'hui.")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
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
	}
}