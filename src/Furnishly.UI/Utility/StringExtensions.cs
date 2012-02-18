using System;

namespace Furnishly.UI
{
	public static class StringExtensions
	{
		public static string FormatWith(this string formatString, params object[] paramerters)
		{
			return string.Format(formatString,paramerters);
		}
	}
}

