using Newtonsoft.Json;

namespace WeatherWebsiteAPI.Models
{
    public class Rain
    {
        [JsonProperty("3h")]
        public float? ThreeH { get; set; }
    }
}
