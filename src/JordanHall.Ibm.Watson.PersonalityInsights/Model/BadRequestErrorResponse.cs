using Newtonsoft.Json;

namespace JordanHall.Ibm.Watson.PersonalityInsights.Model
{
    internal class BadRequestErrorResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

    }
}
