using System.Linq;
using System.Net;
using System.Net.Http;

namespace JordanHall.Core.HttpClientFactory
{
    public class HttpClientFactory
    {
        private readonly HttpClientSettings settings;
        public HttpClientFactory(HttpClientSettings settings)
        {
            this.settings = settings;
        }
        public System.Net.Http.HttpClient CreateClient()
        {
            var httpClientHandler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            var httpClient = System.Net.Http.HttpClientFactory.Create(httpClientHandler , settings.Handlers.ToArray());

            httpClient.BaseAddress = settings.BaseUri;

            return httpClient;
        }
    }
}
