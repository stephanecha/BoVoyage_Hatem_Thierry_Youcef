using BoVoyage.COMMON.Tools;
using BoVoyage.DAL.Context;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BoVoyage.DAL.Validators
{
	[AttributeUsage(AttributeTargets.Property)]
	public class UniqueTravelAgencyName : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			if (value != null)
			{
				if (value is string)
				{
					using (DataContext db = new DataContext())
					{
						return !db.TravelAgencies.Any(x => x.Name == value.ToString());
					}
				}
				else
				{
					throw new ArgumentException(MessageType.OneFieldUnique);
				}
			}
			return false;
		}

		public override string FormatErrorMessage(string name)
		{
			return string.Format(this.ErrorMessage, name);
		}
	}
}