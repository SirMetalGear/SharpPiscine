using System;
using System.IO;
using Utilities;

namespace Exchanger
{
	class Exchange
	{
		string[] filesNames;
		public ExchangeRate firstVal;
		public ExchangeRate secondVal;
		public int			error;
		public Exchange(ref ExchangeSum SumData, ref string path)
		{
			error = 0;
			if (parse(ref SumData, ref path) == -1)
				error = 1;
		}
		int	parse(ref ExchangeSum SumData, ref string path)
		{
			if (Directory.Exists(path))
			{
				int	j = 0;
				filesNames = Directory.GetFiles(path);
				for (int i = 0; i < 3; i++)
				{
					if (filesNames[i].Contains(SumData.Id))
						j = i;
				}
				if (j == 0)
					return -1;
				StreamReader sr = new StreamReader(filesNames[j]);
				firstVal = new ExchangeRate(sr.ReadLine().Split(':'), ref SumData.Id);
				secondVal = new ExchangeRate(sr.ReadLine().Split(':'), ref SumData.Id);
				firstVal.Converted = SumData.Sum * firstVal.Coefficient;
				secondVal.Converted = SumData.Sum * secondVal.Coefficient;
				return 0;
			}
			return -1;
		}
	}
}
