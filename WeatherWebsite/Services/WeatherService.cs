using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherWebsite.Models;

namespace WeatherWebsite.Services
{
    public class WeatherApiClient(HttpClient httpClient)
    {
        private readonly HttpClient httpClient = httpClient;
        private readonly string _apiBaseUrl = "https://localhost:7022/api";

        public async Task<WeatherData> GetCurrentWeather(string location)
        {
            var response = await httpClient.GetAsync($"{_apiBaseUrl}/weather/current?location={location}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WeatherData>(json) ?? new WeatherData();
        }

        public async Task<ForecastData> GetWeatherForecast(string location)
        {
            var response = await httpClient.GetAsync($"{_apiBaseUrl}/weather/forecast?location={location}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ForecastData>(json) ?? new ForecastData();
        }

        public async Task<AQIData> GetAQIData(double lat, double lon)
        {
            var response = await httpClient.GetAsync($"{_apiBaseUrl}/weather/air_pollution?lat={lat}&lon={lon}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AQIData>(json) ?? new AQIData();
        }
    }
}
