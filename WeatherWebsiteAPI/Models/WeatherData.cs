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

    public class Weather
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("main")]
        public string? MainName { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("icon")]
        public string? Icon { get; set; }
    }

    public class Clouds
    {
        [JsonProperty("all")]
        public int? All { get; set; }
    }

    public class Wind
    {
        [JsonProperty("speed")]
        public float? Speed { get; set; }

        [JsonProperty("deg")]
        public float? Deg { get; set; }

        [JsonProperty("gust")]
        public float? Gust { get; set; }
    }

    public class Rain
    {
        [JsonProperty("3h")]
        public float? ThreeH { get; set; }
    }

    public class Sys
    {
        [JsonProperty("pod")]
        public string? Pod { get; set; }
    }
}
