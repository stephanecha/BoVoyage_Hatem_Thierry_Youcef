using BoVoyage.COMMON.Tools;
using BoVoyage.WEB.Validators.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BoVoyage.WEB.Validators
{
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class DateComparaison : ValidationAttribute
	{
		private CompareDateCase CompareDateCase { get; }

		private string ComparaisonProperty { get; set; }

		public DateComparaison(CompareDateCase compareDateCase, string comparisonProperty)
		{
			this.CompareDateCase = compareDateCase;
			this.ComparaisonProperty = comparisonProperty;
		}

		private bool IsValid(DateTime valueDate, DateTime propertyValueDate)
		{
			return this.CompareDateCase == CompareDateCase.AFTER
				? valueDate > propertyValueDate
				: valueDate < propertyValueDate;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value != null)
			{
				DateTime valueDate;
				if (value is DateTime valueDateTime)
					valueDate = valueDateTime;
				else
					throw new ArgumentException(MessageType.MustBeDateTime);

				PropertyInfo property = validationContext.ObjectType.GetProperty(this.ComparaisonProperty);

				if (property == null)
					throw new ArgumentException("Le nom de la propriété n'a pas été trouvé.");

				object propertyValue = property.GetValue(validationContext.ObjectInstance);
				if (propertyValue is DateTime propertyValueDate)
				{
					foreach (Attribute item in property.GetCustomAttributes())
					{
						if (item is DisplayAttribute displayAttribute)
						{
							this.ComparaisonProperty = displayAttribute.Name;
							break;
						}
					}

					return this.IsValid(valueDate, propertyValueDate)
								? ValidationResult.Success
								: new ValidationResult(ErrorMessageResourceName);
				}
				else
				{
					throw new ArgumentException(MessageType.MustBeDateTime);
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