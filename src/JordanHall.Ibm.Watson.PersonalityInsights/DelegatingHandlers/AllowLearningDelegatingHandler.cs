using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace JordanHall.Ibm.Watson.PersonalityInsights.DelegatingHandlers
{
    internal class AllowLearningDelegatingHandler : DelegatingHandler
    {
        private readonly bool learningOptOut;

        public AllowLearningDelegatingHandler(bool learningOptOut = false)
        {
            this.learningOptOut = learningOptOut;
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("X-Watson-Learning-Opt-Out", learningOptOut.ToString());
            return base.SendAsync(request, cancellationToken);
        }
    }
}
