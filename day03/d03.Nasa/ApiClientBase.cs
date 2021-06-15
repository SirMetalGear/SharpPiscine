using System;
using System.Net.Http;
using System.Threading.Tasks;
using day03.d03.Nasa.Apod.Models;

namespace day03.d03.Nasa
{
    abstract class ApiClientBase
    {
        private string ApiKey;
        protected ApiClientBase(string apiKey)
        {
            this.ApiKey = apiKey;
        }
        
        protected async void HttpGetAsync<T>(string url)
        {
            T obj;
            var client = new HttpClient();
            var response = await client.GetAsync("http://www.contoso.com/");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
    }
}