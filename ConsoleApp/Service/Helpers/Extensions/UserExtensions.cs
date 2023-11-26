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


		public static bool EmailFormat(this string email)
		{
			string res = (@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if (email is not null)
			{
				return Regex.IsMatch(email, res);
			}
			return false;
		}
	}
}

