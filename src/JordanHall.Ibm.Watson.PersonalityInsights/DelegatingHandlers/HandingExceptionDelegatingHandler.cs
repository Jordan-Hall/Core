using System;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using JordanHall.Ibm.Watson.PersonalityInsights.Model;
using Newtonsoft.Json;

namespace JordanHall.Ibm.Watson.PersonalityInsights.DelegatingHandlers
{
    public class HandingExceptionDelegatingHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken).ContinueWith(task =>
                {
                    var response = task.Result;
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.Unauthorized:
                            throw new UnauthorizedAccessException(
                                "No API key provided, or the API key provided was not valid.");
                        case HttpStatusCode.BadRequest:
                            throw new DataException("The request JSON is not properly formatted, fewer than 100 words are provided, or the requested language is not supported."
                                ,new DataException(JsonConvert.DeserializeObject<BadRequestErrorResponse>(request.Content.ReadAsStringAsync().Result).Error));
                        case HttpStatusCode.InternalServerError:
                            throw new Exception("The service encountered an internal server error.");
                    }
                    return response;
                }, cancellationToken);
        }
    }
}