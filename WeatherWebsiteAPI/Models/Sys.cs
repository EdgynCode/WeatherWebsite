using Newtonsoft.Json;

namespace WeatherWebsiteAPI.Models
{
    public class Sys
    {
        [JsonProperty("pod")]
        public string? Pod { get; set; }
    }
}
