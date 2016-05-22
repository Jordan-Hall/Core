using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using JordanHall.IbmClassifierService.Exception;

namespace JordanHall.IbmClassifierService.DelegatingHandlers
{
    public class HandingExceptionDelegatingHandler : System.Net.Http.DelegatingHandler
    {

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken).ContinueWith(task =>
                {
                    var response = task.Result;
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                            throw new ClassifierServiceUnauthorizedException(
                                "No API key provided, or the API key provided was not valid.");
                    }
                    return response;
                }, cancellationToken);
        }
    }
}
