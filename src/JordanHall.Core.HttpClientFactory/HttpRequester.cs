using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JordanHall.Core.HttpClientFactory
{
    public class HttpRequester : IHttpRequester
    {
        private readonly HttpClientFactory clientFactory;
        public HttpRequester(HttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<T> Get<T>(string path) where T : class
        {
            using (var client = clientFactory.CreateClient())
            {
                var httpResponse = await client.GetAsync(path);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(content);
                }
            }
            return null;
        }

        public async Task<T> Post<T>(string path, string content) where T : class
        {
            using (var client = clientFactory.CreateClient())
            {
                var httpResponse = await client.PostAsync(path, new StringContent(content));
                if (httpResponse.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(await httpResponse.Content.ReadAsStringAsync());
                }
            }
            return null;
        }

        public async Task<bool> Delete(string path)
        {
            using (var client = clientFactory.CreateClient())
            {
                var httpResponse = await client.DeleteAsync(path);

                if (httpResponse.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<T> Post<T>(string path, HttpContent content) where T : class
        {
            using (var client = clientFactory.CreateClient())
            {
                var httpResponse = await client.PostAsync(path, content);
                if (httpResponse.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(await httpResponse.Content.ReadAsStringAsync());
                }
            }
            return null;
        }

        public async Task<TR> PostAsJson<TP, TR>(string path, TP postObject)
            where TP : class
            where TR : class
        {
            using (var client = clientFactory.CreateClient())
            {
                var httpResponse = await client.PostAsJsonAsync(path, postObject);
                if (httpResponse.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<TR>(await httpResponse.Content.ReadAsStringAsync());
                }
            }
            return null;
        }
    }
}
