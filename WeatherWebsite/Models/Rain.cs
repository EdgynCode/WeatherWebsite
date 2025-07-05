using Newtonsoft.Json;

namespace WeatherWebsite.Models
{
    public class Rain
    {
        [JsonProperty("3h")]
        public float? ThreeH { get; set; }
    }
}
