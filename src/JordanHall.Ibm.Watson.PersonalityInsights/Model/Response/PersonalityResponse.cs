using Newtonsoft.Json;

namespace JordanHall.Ibm.Watson.PersonalityInsights.Model.Response
{
    public class PersonalityResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("word_count")]
        public int WordCount { get; set; }

        [JsonProperty("processed_lang")]
        public string ProcessedLang { get; set; }

        [JsonProperty("tree")]
        public Tree Tree { get; set; }
    }

}
