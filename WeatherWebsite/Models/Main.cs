using Newtonsoft.Json;

namespace WeatherWebsite.Models
{
    public class Main
    {
        [JsonProperty("temp")]
        public float? Temp { get; set; }

        [JsonProperty("feels_like")]
        public float? FeelsLike { get; set; }

        [JsonProperty("temp_min")]
        public float? TempMin { get; set; }

        [JsonProperty("temp_max")]
        public float? TempMax { get; set; }

        [JsonProperty("pressure")]
        public float? Pressure { get; set; }

        [JsonProperty("sea_level")]
        public float? SeaLevel { get; set; }

        [JsonProperty("grnd_level")]
        public float? GrndLevel { get; set; }

        [JsonProperty("humidity")]
        public float? Humidity { get; set; }

        [JsonProperty("temp_kf")]
        public float? TempKf { get; set; }
    }
}
