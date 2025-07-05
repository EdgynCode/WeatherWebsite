using Newtonsoft.Json;

namespace WeatherWebsite.Models
{
    public class Sys
    {
        [JsonProperty("pod")]
        public string? Pod { get; set; }
    }
}
