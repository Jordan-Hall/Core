using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JordanHall.ClassifierService.Models
{
    public class Classifier
    {
        [JsonProperty("classifier_id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("status_description")]
        public string Description { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }
    }
}
