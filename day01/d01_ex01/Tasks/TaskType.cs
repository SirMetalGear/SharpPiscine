using System;
using common;
namespace Utilities
{
	// public enum Type { Work, Personal, Study }
	public record TaskType(common.Type a)
	{
		public override string ToString()
		{
			if (this.a == common.Type.Work)
				return "Work";
			if (this.a == common.Type.Study)
				return "Study";
			return "Personal";
		}
	}
}
