using Newtonsoft.Json;

namespace JordanHall.Ibm.Watson.PersonalityInsights.Model.Request
{
    public class Contentitem
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("contenttype")]
        public string Contenttype { get; set; }

        [JsonProperty("created")]
        public object Created { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("sourceid")]
        public string Sourceid { get; set; }

        [JsonProperty("userid")]
        public string Userid { get; set; }
    }
}
