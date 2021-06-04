namespace d02_ex00
{
	class Movie : ISearchable
	{
		public string Title { get; set; }
		public string MediaType { get; set; }
		private bool IsCriticsPick;
		private string SummaryShort;
		private string Url;
		public Movie(string title, int rating, string summary, string url)
		{
			this.MediaType = "MOVIE";
			this.Title = title;
			if (rating == 0)
				this.IsCriticsPick = false;
			else
				this.IsCriticsPick = true;
			this.SummaryShort = summary;
			this.Url = url;
		}
		override public string ToString()
		{
			string result = $"- {Title} {(IsCriticsPick ? "[NYT critic’s pick]" : "")}\n{SummaryShort}\n{Url}";
			return result;
		}
	}
}
