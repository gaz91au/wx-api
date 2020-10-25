using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebAPI.IntegrationTests.Common
{
    public static class Utilities
    {
        public static async Task<T> GetResponseContent<T>(HttpResponseMessage response)
        {
            var stringResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(stringResponse);
        }
    }
}
