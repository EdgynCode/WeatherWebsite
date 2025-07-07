using Newtonsoft.Json;

namespace WeatherWebsite.Models
{
    public class WeatherData
    {
        [JsonProperty("dateTime")]
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
        [JsonProperty("dateTimeString")]
        public string? DateTimeString { get; set; }
    }
}
