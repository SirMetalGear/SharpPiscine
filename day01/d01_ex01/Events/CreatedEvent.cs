using System;
using System.Collections.Generic;
using common;
using System.Globalization;

namespace Utilities
{
	class CreatedEvent
	{
		List<common.Task>	tasks;
		int		count;
		public CreatedEvent()
		{
			tasks = new List<Task>();
			count = 0;
		}
		public void	createTask()
		{
			if (NewTask() == 1)
			{
				Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
				return ;
			}
			count++;
		}
		public void	showTask()
		{
			if (count == 0)
			{
				Console.WriteLine("Список задач пока пуст.");
				return ;
			}
			for (int i = 0; i < count; i++)
				tasks[i].print();
		}
		public void	changeStatus(int flag, ref string ChosenTask)
		{
			for (int i = 0; i < count; i++)
			{
				if (ChosenTask == tasks[i].Title)
				{
					if (tasks[i].Status == "New" && flag == 0)
					{
						tasks[i].Done();
						Console.WriteLine("Задача [" + tasks[i].Title + "] выполнена!");
					}
					else if (tasks[i].Status == "New" && flag == 1)
					{
						tasks[i].WontDo();
						Console.WriteLine("Задача [" + tasks[i].Title + "] более не актуальна!");
					}
					else
						Console.WriteLine("Актуальный статус задачи не соответствует требованиям для изменения.");
					return ;
				}
			}
			Console.WriteLine("Ошибка ввода. Задача с таким заголовком не найдена.");
		}
		int NewTask()
		{
			Console.WriteLine("Введите заголовок");
			string title = Console.ReadLine();
			if (title == "" || title == null)
				return 1;
			Console.WriteLine("Введите описание");
			string summary = Console.ReadLine();
			Console.WriteLine("Введите срок");
			DateTime tmpDate;
			Nullable<DateTime>	dueDate = null;
			if (DateTime.TryParse(Console.ReadLine(), CultureInfo.CreateSpecificCulture("ru-ru"),
					DateTimeStyles.None,  out tmpDate) == true)
				dueDate = tmpDate;
			Console.WriteLine("Введите тип");
			string tmpType = Console.ReadLine();
			TaskType type;
			if (tmpType == "Work")
				type = new TaskType(common.Type.Work);
			else if(tmpType == "Study")
				type = new TaskType(common.Type.Study);
			else if (tmpType == "Personal")
				type = new TaskType(common.Type.Personal);
			else
				return 1;
			Console.WriteLine("Введите приоритет");
			string tmpPrior = Console.ReadLine();
			TaskPriority priority;
			if (tmpPrior == "High")
				priority = new TaskPriority(common.Priority.High);
			else if(tmpPrior == "Normal")
				priority = new TaskPriority(common.Priority.Normal);
			else if (tmpPrior == "Low")
				priority = new TaskPriority(common.Priority.Low);
			else
				priority = new TaskPriority(common.Priority.Normal);
			tasks.Add(new common.Task(ref title, ref summary, ref type, ref priority, ref dueDate));
			return 0;
		}
	}
}
