using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherWebsite.Models;
using DotNetEnv;

namespace WeatherWebsite.Services
{
    public class WeatherService
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string apiKey;
        private readonly string apiUrl = "http://api.openweathermap.org/data/2.5/";

        public WeatherService()
        {
            Env.Load();
            apiKey = Environment.GetEnvironmentVariable("API_KEY");
        }

        public async Task<WeatherData> GetCurrentWeather(string location)
        {
            string url = $"{apiUrl}weather?q={location}&units=metric&appid={apiKey}";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var weatherData = JsonConvert.DeserializeObject<WeatherData>(jsonString);
                return weatherData ?? new WeatherData();
            }
            else
            {
                throw new Exception("Error fetching current weather data.");
            }
        }

        public async Task<ForecastData> GetWeatherForecast(string location)
        {
            string url = $"{apiUrl}forecast?q={location}&units=metric&appid={apiKey}";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var forecastData = JsonConvert.DeserializeObject<ForecastData>(jsonString);
                return forecastData ?? new ForecastData();
            }
            else
            {
                throw new Exception("Error fetching weather forecast data.");
            }
        }
    }
}
