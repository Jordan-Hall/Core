using Newtonsoft.Json;

namespace JordanHall.IbmClassifierService.Models
{
    public class TrainingRequestModel
    {
        public byte[] FileBytes { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
