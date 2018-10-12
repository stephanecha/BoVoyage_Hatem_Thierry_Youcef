using BoVoyage.COMMON.Tools;
using BoVoyage.WEB.Validators.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BoVoyage.WEB.Validators
{
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class DecimalComparaison : ValidationAttribute
	{
		private CompareCase CompareCase { get; }

		private string ComparaisonProperty { get; set; }

		public DecimalComparaison(CompareCase compareCase, string comparisonProperty)
		{
			this.CompareCase = compareCase;
			this.ComparaisonProperty = comparisonProperty;
		}

		private bool IsValid(decimal valueDecimal, decimal propertyValueDecimal)
		{
			return this.CompareCase == CompareCase.OVER
				? valueDecimal > propertyValueDecimal
				: valueDecimal < propertyValueDecimal;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value != null)
			{
				decimal valueDecimal;
				if (value is decimal valueDecimalTest)
					valueDecimal = valueDecimalTest;
				else
					throw new ArgumentException(MessageType.MustBeDecimal);

				PropertyInfo property = validationContext.ObjectType.GetProperty(this.ComparaisonProperty);

				if (property == null)
					throw new ArgumentException("Le nom de la propriété n'a pas été trouvé.");

				object propertyValue = property.GetValue(validationContext.ObjectInstance);
				if (propertyValue is decimal propertyValueDecimal)
				{
					foreach (Attribute item in property.GetCustomAttributes())
					{
						if (item is DisplayAttribute displayAttribute)
						{
							this.ComparaisonProperty = displayAttribute.Name;
							break;
						}
					}

					return this.IsValid(valueDecimal, propertyValueDecimal)
								? ValidationResult.Success
								: new ValidationResult(ErrorMessageResourceName);
				}
				else
				{
					throw new ArgumentException(MessageType.MustBeDecimal);
				}
			}
			return new ValidationResult(ErrorMessageResourceName);
		}

		public override string FormatErrorMessage(string name)
		{
			return string.Format(this.ErrorMessage, name, this.ComparaisonProperty);
		}
	}
}