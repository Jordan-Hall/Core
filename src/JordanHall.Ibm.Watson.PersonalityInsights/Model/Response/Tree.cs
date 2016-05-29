using System.Collections.Generic;
using Newtonsoft.Json;

namespace JordanHall.Ibm.Watson.PersonalityInsights.Model.Response
{
    public class Tree
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("children")]
        public IEnumerable<Child> Children { get; set; }
    }
}
