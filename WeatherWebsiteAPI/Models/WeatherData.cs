using Newtonsoft.Json;

namespace WeatherWebsiteAPI.Models
{
    public class WeatherData
    {
        [JsonProperty("dt")]
        public long DateTime { get; set; }
        [JsonProperty("main")]
        public Main? Main { get; set; }
        [JsonProperty("weather")]
        public Weather[]? Weather { get; set; }
        [JsonProperty("clouds")]
        public Clouds? Clouds { get; set; }
        [JsonProperty("wind")]
        public Wind? Wind { get; set; }
        [JsonProperty("visibility")]
        public float? Visibility { get; set; }
        [JsonProperty("pop")]
        public float? Pop { get; set; }
        [JsonProperty("rain")]
        public Rain? Rain { get; set; }
        [JsonProperty("sys")]
        public Sys? Sys { get; set; }
        [JsonProperty("dt_txt")]
        public string? DateTimeString { get; set; }
    }
}
