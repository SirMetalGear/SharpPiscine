namespace Utilities
{
	struct ExchangeSum
	{
		public double Sum;
		public string Id;
		public int error;
		public ExchangeSum(ref string[] args)
		{
			error = 0;
			Sum = 0;
			Id = null;
			if (parse(ref args) == -1)
				error = 1;
		}
		bool countSpaces(ref string firstArg)
		{
			var countSpaces = 0;
			for (int i = 0; i < firstArg.Length; i++)
				if (firstArg[i] == ' ')
					countSpaces++;
			if (countSpaces != 1)
				return false;
			return true;
		}
		int	parse(ref string[] args)
		{
			if (args.Length != 2 || countSpaces(ref args[0]) == false)
				return -1;
			else
			{
				string[] splitted = new string[2];
				splitted = args[0].Split(' ');
				if (double.TryParse(splitted[0], out Sum) == false)
					return -1;
				Id = splitted[1];
				return 0;
			}
		}
	}
}
