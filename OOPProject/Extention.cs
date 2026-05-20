using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject
{
	public static class Extention
	{
		public static string Compare(this string id)
		{
			return id.Trim().ToUpper()??string.Empty;
		}
		public static bool IsPhone(this string phone)
		{
			if (string.IsNullOrEmpty(phone))
				return false;
			for (int i = 0; i < phone.Length; i++)
			{
				if (char.IsDigit(phone[i]))
					return true;
			}
			return false;
		}
		public static bool IsEmail(this string email)
		{
			bool dot = false;
			bool at = false;

			for (int i = 0; i < email.Length; i++)
			{
				if (email[i] == '.') dot= true;
				if (email[i] == '@') at = true;
			}

			return at && dot;
		}
	}
}
