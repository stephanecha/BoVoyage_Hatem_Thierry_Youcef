using BoVoyage.COMMON.Tools;
using System;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage.WEB.Validators
{
	[AttributeUsage(AttributeTargets.Property)]
	public class AgeOver : ValidationAttribute
	{
		public int MinimumAge { get; private set; }

		public AgeOver(int minimumAge)
		{
			this.MinimumAge = minimumAge;
		}

		public override bool IsValid(object value)
		{
			if (value != null)
			{
				if (value is DateTime valueDateTime)
				{
					return DateTime.Now.AddYears(-this.MinimumAge) >= valueDateTime;
				}
				else
				{
					throw new ArgumentException(MessageType.MustBeDateTime);
				}
			}
			return false;
		}

		public override string FormatErrorMessage(string name)
		{
			return string.Format(this.ErrorMessage, name, this.MinimumAge.ToString());
		}
	}
}