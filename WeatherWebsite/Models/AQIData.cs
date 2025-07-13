using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherWebsite.Models
{
    public class AQIData
    {
        [JsonProperty("coord")]
        public Coord? Coord { get; set; }

        [JsonProperty("list")]
        public List<AQIListItem>? List { get; set; }
    }

    public class Coord
    {
        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }
    }

    public class AQIListItem
    {
        [JsonProperty("main")]
        public AQIMain? Main { get; set; }

        [JsonProperty("components")]
        public AQIComponents? Components { get; set; }

        [JsonProperty("dt")]
        public long Dt { get; set; }
    }

    public class AQIMain
    {
        [JsonProperty("aqi")]
        public int AQI { get; set; }
    }

    public class AQIComponents
    {
        [JsonProperty("co")]
        public double CO { get; set; }

        [JsonProperty("no")]
        public double NO { get; set; }

        [JsonProperty("no2")]
        public double NO2 { get; set; }

        [JsonProperty("o3")]
        public double O3 { get; set; }

        [JsonProperty("so2")]
        public double SO2 { get; set; }

        [JsonProperty("pm2_5")]
        public double PM2_5 { get; set; }

        [JsonProperty("pm10")]
        public double PM10 { get; set; }

        [JsonProperty("nh3")]
        public double NH3 { get; set; }
    }
}