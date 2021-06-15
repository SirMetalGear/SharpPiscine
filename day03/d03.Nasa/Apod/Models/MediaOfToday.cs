using System;

namespace day03.d03.Nasa.Apod.Models
{
    public class MediaOfToday
    {
        public string Date { get; set; }
        public string Title { get; set; }
        public string Copyright { get; set; }
        public string Explanation { get; set; }
        public string Url { get; set; }

        public MediaOfToday(string date, string title, string copyright, string explanation, string url)
        {
            this.Date = date;
            this.Title = title;
            this.Copyright = copyright;
            this.Explanation = explanation;
            this.Url = url;
        }
    }
}