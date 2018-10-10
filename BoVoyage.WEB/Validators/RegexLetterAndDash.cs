using BoVoyage.COMMON.Extensions;
using BoVoyage.COMMON.Tools;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BoVoyage.WEB.Validators
{
	[AttributeUsage(AttributeTargets.Property)]
	public class RegexLetterAndDash : RegularExpressionAttribute
	{
		public Regex RegexPattern { get; set; }

		public RegexLetterAndDash() : base(@"^[a-zA-Z\-]+$")
		{
			this.RegexPattern = new Regex(this.Pattern);
		}

		public override bool IsValid(object value)
		{
			if (value != null)
			{
				if (value is string valueString)
				{
					return this.RegexPattern.IsMatch(valueString.ReplaceAccents()) ? true : false;
				}
				else
				{
					throw new ArgumentException(MessageType.MustBeString);
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