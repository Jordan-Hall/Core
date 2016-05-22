using Newtonsoft.Json;

namespace JordanHall.ClassifierService.Models
{
    public class ClassifyResponse
    {
        [JsonProperty("classifier_id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("text")]
        public string Query { get; set; }

        [JsonProperty("top_class")]
        public string TopClassName { get; set; }
        public Classify[] classes { get; set; }
    }
}
