using System;
using Utilities;

namespace common
{
	class Event
	{
		CreatedEvent events;
		public Event()
		{
			events = new CreatedEvent();
			string UserInput;
			string ChosenTask;
			Console.Write("> ");
			UserInput = Console.ReadLine();
			while (UserInput != null && UserInput != "quit" && UserInput != "q")
			{
				if (UserInput == "add")
					events.createTask();
				else if (UserInput == "list")
					events.showTask();
				else if (UserInput == "done" || UserInput == "wontdo")
				{
					Console.WriteLine("Введите заголовок");
					ChosenTask = Console.ReadLine();
					if (UserInput == "done")
						events.changeStatus(0, ref ChosenTask);
					else
						events.changeStatus(1, ref ChosenTask);
				}
				else
					Console.WriteLine("Неверная команда.");
				Console.Write("> ");
				UserInput = Console.ReadLine();
			}
		}
	}
}
