namespace d02_ex00
{
	class Book : ISearchable
	{
		public string Title { get; set; }
		public string MediaType { get; set; }
		private string	Author;
		private string	SummaryShort;
		private int Rank;
		private string ListName;
		private string Url;
		public Book(string title, string author, string summary, int rank, string listName, string url)
		{
			this.MediaType = "BOOK";
			this.Title = title;
			this.Author = author;
			this.SummaryShort = summary;
			this.Rank = rank;
			this.ListName = listName;
			this.Url = url;
		}
		override public string ToString()
		{
			string result = $"- {Title} by {Author} [{Rank} on NYT's {ListName}]\n{SummaryShort}\n{Url}";
			return result;
		}
	}
}
