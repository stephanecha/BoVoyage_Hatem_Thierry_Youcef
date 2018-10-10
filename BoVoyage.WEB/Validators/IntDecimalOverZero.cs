using BoVoyage.COMMON.Tools;
using System;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage.WEB.Validators
{
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class IntDecimalOverZero : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			if (value != null)
			{
				if (value is int x)
					return x >= 0;
				else if (value is decimal y)
					return y > 0.0m;
				else
					throw new ArgumentException(MessageType.MustBeintOrDecimal);
			}
			return false;
		}

		public override string FormatErrorMessage(string name)
		{
			return string.Format(this.ErrorMessage, name);
		}
	}
}