using Newtonsoft.Json;

namespace JordanHall.ClassifierService.Models
{
    public class ClassifyRequest
    {
        [JsonProperty("classifierId")]
        public string ClassifierId;

        [JsonProperty("text")]
        public string Query;
    }
}
