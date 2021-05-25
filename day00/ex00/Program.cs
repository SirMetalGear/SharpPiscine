using System;
// using System.Math;
// using System.DateTime;

namespace ex00
{
	struct UserInputData
	{
		public double sum;
		public double rate;
		public int	term;
		public int	selectedMonth;
		public double	payment;
	}
	class Program
	{
		static void Main(string[] args)
		{
			double	Default;
			double	LessPayment;
			double	LessTerm;
			UserInputData data = new UserInputData();

			if ((args.Length != 5) || (ParseInputData(ref args, ref data) == -1)) {
				Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
				return ;
			}
			Console.WriteLine("\nГрафик платеженй без досрочного погашения:");
			Default = calculate(ref data, 0);
			Console.WriteLine("\nГрафик платеженй с досрочным погашением с уменьшением платежа:");
			LessPayment = calculate(ref data, 1);
			Console.WriteLine("\nГрафик платеженй с досрочным погашением с уменьшением срока:");
			LessTerm = calculate(ref data, 2);
			printResult(Default, LessPayment, LessTerm);
		}
		static int ParseInputData(ref string[] args, ref UserInputData data)
		{
			if (double.TryParse(args[0], out data.sum) == false)
				return -1;
			if (data.sum < 0)
				return -1;
			if (double.TryParse(args[1], out data.rate) == false)
				return -1;
			if (data.rate < 0 || data.rate > 100)
				return -1;
			if (int.TryParse(args[2], out data.term) == false)
				return -1;
			if (data.term < 0)
				return -1;
			if (int.TryParse(args[3], out data.selectedMonth) == false)
				return -1;
			if (data.selectedMonth < 0 || data.selectedMonth > data.term)
				return -1;
			if (double.TryParse(args[4], out data.payment) == false)
				return -1;
			if (data.payment < 0 || data.payment > data.sum)
				return -1;
			Console.WriteLine("\nСумма кредита:                                    " + data.sum + "руб.");
			Console.WriteLine("Годовая процентная ставка:                        " + data.rate + "%");
			Console.WriteLine("Срок выплаты в месяцах:                           " + data.term + "мес.");
			Console.WriteLine("Номер месяца в котором вносится досрочный платеж: " + data.selectedMonth + "мес.");
			Console.WriteLine("Сумма досрочного платежа:                         " + data.payment + "руб.");
			return 0;
		}
		static double	calculate(ref UserInputData data, int flag)
		{
			double	InterestRate = data.rate / 12 / 100;
			double	FormulaPart = Math.Pow(1 + InterestRate, data.term);
			double	AnnuityPayment = (data.sum * InterestRate * FormulaPart) / (FormulaPart - 1);
			DateTime CurrentDate = DateTime.Today;
			int	DaysInCurrentMonth = DateTime.DaysInMonth(CurrentDate.Year, CurrentDate.Month);
			int	DaysInCurrentYear = 0;
			for (int i = 1; i <= 12; i++)
				DaysInCurrentYear += DateTime.DaysInMonth(CurrentDate.Year, i);
			double MonthlyInterest;
			double OD = 0;
			double debt = data.sum;
			double TotalOverpayed = AnnuityPayment * data.term - data.sum;
			double RealOverPay = 0;
			double TotalDebt = TotalOverpayed + data.sum;
			Console.WriteLine("Дата             Платеж          ОД              Проценты        Остаток долга");
			for (int cicle = 0; cicle != data.term; cicle++)
			{
				DaysInCurrentMonth = DateTime.DaysInMonth(CurrentDate.Year, CurrentDate.Month);
				MonthlyInterest = (debt * data.rate * DaysInCurrentMonth) / (100 * DaysInCurrentYear);
				OD = AnnuityPayment - MonthlyInterest;
				debt -= OD;
				if ((flag == 1) && (cicle + 1 == data.selectedMonth))
				{
					debt -= data.payment;
					FormulaPart = Math.Pow(1 + InterestRate, data.term - cicle - 1);
					AnnuityPayment = (debt * InterestRate * FormulaPart) / (FormulaPart - 1);
				}
				if ((flag == 2) && (cicle + 1 == data.selectedMonth))
				{
					debt -= data.payment;
					data.term = (int)Math.Log((AnnuityPayment / (AnnuityPayment - InterestRate * debt)), 1 + InterestRate);
					cicle = -1;
				}
				CurrentDate = CurrentDate.AddMonths(1);
				RealOverPay += MonthlyInterest;
				if (CurrentDate.Month == 1)
				{
					DaysInCurrentYear = 0;
					for (int j = 1; j <= 12; j++)
						DaysInCurrentYear += DateTime.DaysInMonth(CurrentDate.Year, j);
				}
				Console.Write("01." + String.Format("{0,0:00}", CurrentDate.Month) + "." + CurrentDate.Year + "       ");
				Console.Write(String.Format("{0,-16:0.00}", AnnuityPayment));
				Console.Write(String.Format("{0,-16:0.00}", OD));
				Console.Write(String.Format("{0,-16:0.00}", MonthlyInterest));
				Console.Write(String.Format("{0,-16:0.00}", debt));
				Console.WriteLine();
			}
			Console.WriteLine("Итоговая переплата: " + String.Format("{0,-16:0.00}", RealOverPay));
			return RealOverPay;
		}
		static void	printResult(double Default, double LessPayment, double LessTerm)
		{
			if (LessPayment > LessTerm)
			{
				Console.WriteLine("\nПереплата при уменьшении платежа: " + String.Format("{0,0:0.00}", LessPayment));
				Console.WriteLine("Переплата при уменьшении срока: " + String.Format("{0,0:0.00}", LessTerm));
				Console.WriteLine("Уменьшение срока выгоднее уменьшения платежа на " + String.Format("{0,0:0.00}", (LessPayment - LessTerm)));
			}
			if (LessPayment < LessTerm)
			{
				Console.WriteLine("\nПереплата при уменьшении платежа: " + String.Format("{0,0:0.00}", LessPayment));
				Console.WriteLine("Переплата при уменьшении срока: " + String.Format("{0,0:0.00}", LessTerm));
				Console.WriteLine("Уменьшение срока выгоднее уменьшения платежа на " + String.Format("{0,0:0.00}", (LessTerm - LessPayment)));
			}
			if (LessPayment == LessTerm)
			{
				Console.WriteLine("\nПереплата при уменьшении платежа: " + String.Format("{0,0:0.00}", LessPayment));
				Console.WriteLine("Переплата при уменьшении срока: " + String.Format("{0,0:0.00}", LessTerm));
				Console.WriteLine("Переплата одинакова в обоих вариантах.");
			}
			Console.WriteLine();
		}
	}
}
