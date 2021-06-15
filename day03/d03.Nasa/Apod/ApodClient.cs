using System.Threading.Tasks;
using day03.d03.Nasa.Apod.Models;

namespace day03.d03.Nasa.Apod
{
    public class ApodClient : ApiClientBase,
        INasaClient<int, Task<MediaOfToday>[]>
    {
        ApodClient(int countResult, string url) : base(url)
        {
            
        }
        public Task<MediaOfToday>[] GetAsync(int input)
        {
            throw new System.NotImplementedException();
        }
        
    }
}