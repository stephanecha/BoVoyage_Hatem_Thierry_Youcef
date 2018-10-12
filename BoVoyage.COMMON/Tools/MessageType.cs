namespace BoVoyage.COMMON.Tools
{
	public static class MessageType
	{
		public const string RequiredField = "Le champ {0} est obligatoire.";
		public const string StringLengthField = "Le champ {0} doit contenir {1} caractères max.";
		public const string OneFieldUnique = "Il existe déjà un champ {0} avec la même valeur.";

		public const string MustBeString = "Le type doit être une string.";
		public const string MustBeDateTime = "Le type doit être un DateTime.";
		public const string MustBeIntOrDecimal = "Le type doit être un int ou decimal.";
		public const string MustBeDecimal = "Le type doit être un decimal.";

		public const string MustBeOverZero = "Le champ {0} doit être supérieur à 0.";

		public const string RegexLetterAndDashErrorMessage = "Le champ {0} doit être supérieur à 0.";
	}
}