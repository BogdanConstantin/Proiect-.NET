using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Questions.Abstractions;

namespace BusinessLogic.Questions.Implementations
{
    public class ServiceClient : IServiceClient
    {
        private readonly HttpClient _serviceClient = new HttpClient();

        public async Task<string> Get(string url)
        {
            var task = _serviceClient.GetAsync(url);
            var result = await task.Result.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<string> Post(string url, object obj)
        {
            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            var task = _serviceClient.PostAsync(url, content);
            var result = await task.Result.Content.ReadAsStringAsync();
            return result;
        }

    }
}
