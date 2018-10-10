using System.Text;

namespace BoVoyage.COMMON.Extensions
{
	public static class StringExtensions
	{
		public static string ReplaceAccents(this string source)
		{
			if (string.IsNullOrEmpty(source))
				return source;

			var tempBytes = Encoding.GetEncoding("ISO-8859-8").GetBytes(source);
			return Encoding.UTF8.GetString(tempBytes);
		}
	}
}