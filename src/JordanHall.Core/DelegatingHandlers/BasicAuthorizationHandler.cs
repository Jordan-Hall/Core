using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JordanHall.Core.DelegatingHandlers
{
    public class BasicAuthorizationHandler : System.Net.Http.DelegatingHandler
    {
        private readonly string apiKey;
        public BasicAuthorizationHandler(string api)
        {
            apiKey = Convert.ToBase64String(Encoding.Default.GetBytes(api));
        }
        public BasicAuthorizationHandler(string username, string password)
        {
            apiKey = Convert.ToBase64String(Encoding.Default.GetBytes($"{username}:{password}"));
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("basic", apiKey);
            return base.SendAsync(request, cancellationToken);
        }
    }
}
