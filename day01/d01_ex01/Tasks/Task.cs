using System;
using Utilities;

namespace common
{
	public enum Type { Work , Study , Personal };
	public enum Priority { High, Normal, Low };
	class Task
	{
		string				title;
		string				summary;
		Nullable<DateTime>	dueDate;
		TaskType			type;
		TaskPriority		priority;
		TaskState			state;
		public	Task(ref string title, ref string summary, ref TaskType type, ref TaskPriority priority, ref DateTime? dueDate)
		{
			this.title = title;
			this.summary = summary;
			this.dueDate = dueDate;
			this.type = type;
			this.priority = priority;
			this.state = new TaskState();
		}
		public string Title
		{
			get => title;
		}
		public string Status
		{
			get => state.ToString();
		}
		public void Done()
		{
			state = state with { state = "Done" };
		}
		public void	WontDo()
		{
			state = state with { state = "WontDo" };
		}
		public void	print()
		{
			Console.WriteLine("- " + title);
			Console.WriteLine("[" + type.ToString() + "][" + state + "]");
			if (dueDate != null)
				Console.WriteLine("Priority: " + priority + ", Due till " +  String.Format("{0:dd/MM/yyyy}", dueDate));
			else
				Console.WriteLine("Priority: " + priority);
			if (summary != null)
				Console.WriteLine(summary);
		}
	}
}
