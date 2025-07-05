using Newtonsoft.Json;

namespace WeatherWebsite.Models
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
