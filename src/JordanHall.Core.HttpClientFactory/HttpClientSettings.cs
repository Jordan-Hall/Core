using System;
using System.Collections.Generic;
using System.Net.Http;

namespace JordanHall.Core.HttpClientFactory
{
    public class HttpClientSettings
    {
        public Uri BaseUri { get; set; }

        public IEnumerable<DelegatingHandler> Handlers { get; set; }
    }
}
