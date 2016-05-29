using System.Collections.Generic;
using Newtonsoft.Json;

namespace JordanHall.Ibm.Watson.PersonalityInsights.Model.Request
{
    class RequestInsight
    {
        [JsonProperty("contentItems")]
        public IEnumerable<Contentitem> ContentItems { get; set; }

    }
}
