using System.Collections.Generic;
namespace d02_ex00
{
	public class parsed
	{
		public results[] results { get; set; }
	}
	public class results
	{
		public string title { get; set; }
		public int critics_pick { get; set; }
		public string summary_short { get; set; }
		public Dictionary<string, string> link {get; set;}
		public string amazon_product_url { get; set; }
		public int rank { get; set; }
		public string list_name { get; set; }
		public Dictionary<string, string>[] book_details { get; set; }
	}
	interface ISearchable
	{
    	string Title { get; set; }
		string MediaType { get; set; }
	}
}
