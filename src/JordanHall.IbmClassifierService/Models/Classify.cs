﻿using Newtonsoft.Json;

namespace JordanHall.IbmClassifierService.Models
{
    public class Classify
    {
        [JsonProperty("class_name")]
        public string ClassName { get; set; }

        [JsonProperty("confidence")]
        public float Confidence { get; set; }
    }
}
