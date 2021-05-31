namespace Utilities
{
	public record TaskState(string state = "New")
	{
		public override string ToString()
		{
			return this.state;
		}
	}
}
