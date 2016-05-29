using System.Collections.Generic;
using Newtonsoft.Json;

namespace JordanHall.Ibm.Watson.PersonalityInsights.Model.Response
{
    public class Child2
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("percentageid")]
        public double Percentage { get; set; }

        [JsonProperty("children")]
        public IEnumerable<Child3> Children { get; set; }
    }
}
