using System;

namespace BoVoyage.DAL.Entites.Enum
{
	public static class DiscountTypeEnum
	{
		public const decimal NoDiscount = 1.0m;
		public const decimal UnderTwelve = 0.6m;

		public static decimal GetDiscount(DateTime birthDate, DateTime departureDate)
		{
			int age = departureDate.Year - birthDate.Year;

			if (age < 12)
				return UnderTwelve;
			else
				return NoDiscount;
		}
	}
}