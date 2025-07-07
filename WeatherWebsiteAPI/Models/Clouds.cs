using Newtonsoft.Json;

namespace WeatherWebsiteAPI.Models
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int? All { get; set; }
    }
}
