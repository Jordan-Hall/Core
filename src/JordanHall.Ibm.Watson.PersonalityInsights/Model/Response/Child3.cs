using System.Collections.Generic;
using Newtonsoft.Json;

namespace JordanHall.Ibm.Watson.PersonalityInsights.Model.Response
{
    public class Child3
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("percentage")]
        public double Percentage { get; set; }

        [JsonProperty("sampling_error")]
        public double SamplingError { get; set; }

        [JsonProperty("children")]
        public IEnumerable<Child4> Children { get; set; }
    }
}
