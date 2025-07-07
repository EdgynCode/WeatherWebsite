using Newtonsoft.Json;

namespace WeatherWebsite.Models
{
    public class Rain
    {
        [JsonProperty("threeH")]
        public float? ThreeH { get; set; }
    }
}
