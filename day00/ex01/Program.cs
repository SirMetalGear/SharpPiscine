using System;
using System.IO;

namespace ex01
{
	class Program
	{
		static void Main(string[] args)
		{
			string userName = new string("");
			if (getInputName(ref userName) == -1)
			{
				Console.WriteLine("Validation error.");
				return ;
			}
			for (int i = 0; i <= 2; i++)
				if (nameCheck(ref userName, i) == 1)
					return ;
			Console.WriteLine("Your name was not found.");
		}
		static int getInputName(ref string userName)
		{
			Console.WriteLine(">Enter name:");
			userName = Console.ReadLine();
			if (userName.Length == 0)
				return -1;
			int symbCount = 0;
			for (int i = 0; i < userName.Length; i++)
				if ((userName[i] >= 'A' && userName[i] <= 'Z') || (userName[i] >= 'a' && userName[i] <= 'z') || userName[i] == ' ' || userName[i] == '-')
					symbCount++;
			if (symbCount != userName.Length)
				return - 1;
			return 0;
		}
		static int LevenshteinDistance(string string1, string string2)
		{
			int diff;
			int[,] m = new int[string1.Length + 1, string2.Length + 1];

			for (int i = 0; i <= string1.Length; i++) {
				m[i, 0] = i;
			}
			for (int j = 0; j <= string2.Length; j++) {
				m[0, j] = j;
			}
			for (int i = 1; i <= string1.Length; i++)
			{
				for (int j = 1; j <= string2.Length; j++)
				{
					diff = (string1[i - 1] == string2[j - 1]) ? 0 : 1;
					m[i, j] = Math.Min(Math.Min(m[i - 1, j] + 1, m[i, j - 1] + 1), m[i - 1, j - 1] + diff);
				}
			}
			return m[string1.Length, string2.Length];
		}
		static int nameCheck(ref string userName, int distance)
		{
			int		LevDistance = 0;
			string	possibleName;
			string	userAnswer = new string("");
			StreamReader sr = new StreamReader("./us.txt");
			while ((possibleName = sr.ReadLine()) != null)
			{
				LevDistance = LevenshteinDistance(userName, possibleName);
				if (LevDistance == distance)
				{
					if (distance == 0)
					{
						Console.WriteLine("Hello, " + possibleName);
						return 1;
					}
					while (userAnswer != "Y" && userAnswer != "N")
					{
						Console.WriteLine(">Did you mean \"" + possibleName + "\"? Y/N");
						userAnswer = Console.ReadLine();
					}
					if (userAnswer == "Y")
					{
						Console.WriteLine("Hello, " + possibleName);
						return 1;
					}
					userAnswer = "";
				}
			}
			return 0;
		}
	}
}
