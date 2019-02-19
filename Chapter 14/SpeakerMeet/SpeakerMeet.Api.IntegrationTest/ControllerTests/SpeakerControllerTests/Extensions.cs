using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpeakerMeet.Api.IntegrationTest.ControllerTests.SpeakerControllerTests
{
    public static class Extensions
    {
        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            var json = await content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
