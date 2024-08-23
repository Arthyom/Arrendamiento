using Humanizer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
	public static class StringExtention
	{
		public static string CorrectSeederBoolen(this string seederSource)
		{
			seederSource = seederSource.Replace("\"Libre\": \"0\"", "\"Libre\": \"false\"");
			seederSource = seederSource.Replace("\"Libre\": \"1\"", "\"Libre\": \"true\"");

			return seederSource;
		}

		public static string ToDateFormat(this DateTime currentDate, string dateFormat = "dd 'de' MMMM 'del' yyyy")
		{
			var ci = new CultureInfo("es-ES", false);
			ci.DateTimeFormat.LongDatePattern = dateFormat;
			Thread.CurrentThread.CurrentCulture = ci;

			return currentDate.ToString(dateFormat);
		}

		public static string? NumberToText(this string intAsString)
		{
			int result = 0;
			var ci = new CultureInfo("es-ES", false);
			Thread.CurrentThread.CurrentCulture = ci;

			if (Int32.TryParse(intAsString, out result))
				return result.ToWords(ci).ToUpper();


			throw new Exception("CAN NOT CONVERT NUMBER TO TEXT");
		}
	}
}
