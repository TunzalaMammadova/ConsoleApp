using System;
using System.Text.RegularExpressions;

namespace Service.Helpers.Extensions
{
	public static class UserExtensions
	{
		public static bool CheckEmail(this string str)
		{
			return Regex.IsMatch(str,"@");
		}
	}
}

