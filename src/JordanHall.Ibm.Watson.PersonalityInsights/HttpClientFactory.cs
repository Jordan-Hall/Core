using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Configuration;
using JordanHall.Core.HttpClientFactory;
using JordanHall.Core.HttpClientFactory.DelegatingHandlers;
using JordanHall.Ibm.Watson.PersonalityInsights.DelegatingHandlers;

namespace JordanHall.Ibm.Watson.PersonalityInsights
{
    public class HttpClientFactory
    {
        private readonly bool learningOptOut;

        public HttpClientFactory(bool learningOptOut = false)
        {
            this.learningOptOut = learningOptOut;
        }
        public Core.HttpClientFactory.HttpClientFactory BuildClient()
        {
            var settings = new HttpClientSettings()
            {
                Handlers = new List<DelegatingHandler>()
                {
                    new BasicAuthorizationHandler(
                        ConfigurationManager.AppSettings["PersonalityInsightsUsername"],
                        ConfigurationManager.AppSettings["PersonalityInsightsPassword"]
                    ),
                    new AllowLearningDelegatingHandler(learningOptOut),
                    new HandingExceptionDelegatingHandler()
                },
                BaseUri = new Uri(ConfigurationManager.AppSettings["IbmClasifierBaseUrl"])
            };
            return new Core.HttpClientFactory.HttpClientFactory(settings);
        }
    }
}