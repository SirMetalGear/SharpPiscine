using System;
using System.Globalization;

namespace Utilities
{
	public struct ExchangeRate
	{
		public string From;
		public string To;
		public double Coefficient;
		public double Converted;
		public ExchangeRate(string[] args, ref string rawMoney)
		{
			From = rawMoney;
			To = args[0];
			Coefficient = double.Parse(args[1], new CultureInfo("ru-ru"));
			Converted = 0;
		}
	}
}
