using Newtonsoft.Json;

namespace WeatherWebsite.Models
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int? All { get; set; }
    }
}
