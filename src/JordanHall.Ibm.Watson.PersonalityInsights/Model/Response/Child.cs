using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JordanHall.Ibm.Watson.PersonalityInsights.Model.Response
{
    public class Child
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("children")]
        public IEnumerable<Child2> Children { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }
    }
}
