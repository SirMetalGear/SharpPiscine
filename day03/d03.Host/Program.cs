using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.CompilerServices;

namespace day03.d03.Host
{
    class Program
    {
        public static void Main(string[] args = null)
        {
            if (args.Length != 1 || !args[0].Equals("apod"))
            {
                Console.WriteLine("Wrong arguments");
                return;
            }
            var resultCount = IntegerType.FromString(Console.ReadLine());
            var filePath = Environment.CurrentDirectory + "/d03.Host/appsettings.json";
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile(filePath);
            IConfiguration config = configurationBuilder.Build();
            var apiKey = config.GetSection("ApiKey").Value.ToString();
            Console.WriteLine(apiKey);
        }
        // public static async Task Main(string[] args = null)
        // {
        //     var filePath = Environment.CurrentDirectory + "/d03.Host/appsettings.json";
        //     var configurationBuilder = new ConfigurationBuilder();
        //     configurationBuilder.AddJsonFile(filePath);
        //     IConfiguration config = configurationBuilder.Build();
        //     var apiKey = config.GetSection("ApiKey").Value.ToString();
        //     var client = new HttpClient();
        //     var response = await client.GetAsync("https://api.nasa.gov/planetary/apod?api_key=" + "");
        //     if (response.StatusCode == HttpStatusCode.OK)
        //     {
        //         string responseBody = await response.Content.ReadAsStringAsync();
        //         Console.WriteLine(responseBody);
        //     }
        //     else
        //     {
        //         Console.WriteLine("FAILED but here we go");
        //         Console.WriteLine(response);
        //     }
        //     
        // }
    }
}
