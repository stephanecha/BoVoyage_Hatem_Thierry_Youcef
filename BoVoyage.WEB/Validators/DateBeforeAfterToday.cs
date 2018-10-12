using BoVoyage.COMMON.Tools;
using BoVoyage.WEB.Validators.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage.WEB.Validators
{
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class DateBeforeAfterToday : ValidationAttribute
	{
		private CompareCase CompareDateCase { get; }

		public DateBeforeAfterToday(CompareCase compareDateCase)
		{
			this.CompareDateCase = compareDateCase;
		}

		public override bool IsValid(object value)
		{
			if (value != null)
			{
				if (value is DateTime valueDateTime)
				{
					return this.CompareDateCase == CompareCase.OVER
						? valueDateTime > DateTime.Now
						: valueDateTime < DateTime.Now;
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
			return string.Format(this.ErrorMessage, name);
		}
	}
}