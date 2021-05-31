using System;
using System.IO;
using Exchanger;
using Utilities;

if (args.Length == 2)
{
	var SumData = new ExchangeSum(ref args);
	if (SumData.error != 1)
	{
		var rates = new Exchange(ref SumData, ref args[1]);
		if (rates.error != 1)
		{
			Console.WriteLine("Сумма в исходной валюте: " + string.Format("{0:N2}", SumData.Sum) + " " + SumData.Id);
			Console.WriteLine("Сумма в " + rates.firstVal.To + ": " + string.Format("{0:N2}", rates.firstVal.Converted) + " " + rates.firstVal.To);
			Console.WriteLine("Сумма в " + rates.secondVal.To + ": " + string.Format("{0:N2}", rates.secondVal.Converted) + " " + rates.secondVal.To);
			return ;
		}
	}
}
Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");