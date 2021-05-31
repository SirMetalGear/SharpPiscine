using System;
using common;

namespace Utilities
{
	public record TaskPriority(common.Priority priority)
	{
		public override string ToString()
		{
			if (this.priority == common.Priority.High)
				return "High";
			if (this.priority == common.Priority.Low)
				return "Low";
			return "Normal";
		}
	}
}
