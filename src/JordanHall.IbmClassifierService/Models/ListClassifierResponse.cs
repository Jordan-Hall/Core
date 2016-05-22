using Newtonsoft.Json;

namespace JordanHall.IbmClassifierService.Models
{
    public class ClassifierList
    {
        [JsonProperty("classifiers")]
        public Classifier[] Classifiers { get; set; }
    }
}
