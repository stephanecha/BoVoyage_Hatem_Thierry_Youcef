using System.Security.Cryptography;
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

		public static string GenerateSHA256String(this string inputString)
		{
			SHA256 sha256 = SHA256.Create();
			byte[] bytes = Encoding.UTF8.GetBytes(inputString);
			byte[] hash = sha256.ComputeHash(bytes);
			return GetStringFromHash(hash);
		}

		public static string GenerateSHA512String(this string inputString)
		{
			SHA512 sha512 = SHA512.Create();
			byte[] bytes = Encoding.UTF8.GetBytes(inputString);
			byte[] hash = sha512.ComputeHash(bytes);
			return GetStringFromHash(hash);
		}

		private static string GetStringFromHash(byte[] hash)
		{
			StringBuilder result = new StringBuilder();
			for (int i = 0; i < hash.Length; i++)
			{
				result.Append(hash[i].ToString("X2"));
			}
			return result.ToString();
		}
	}
}