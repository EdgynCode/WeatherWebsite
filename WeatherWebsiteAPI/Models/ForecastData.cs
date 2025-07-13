using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherWebsiteAPI.Models
{
    public class ForecastData
    {
        [JsonProperty("cod")]
        public string? Cod { get; set; }

        [JsonProperty("message")]
        public int? Message { get; set; }

        [JsonProperty("cnt")]
        public int? Cnt { get; set; }

        [JsonProperty("list")]
        public List<WeatherData>? List { get; set; }
    }
}