using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WeatherWebsite.Models;
using WeatherWebsite.Services;

namespace WeatherWebsite.Controllers
{
    public class WeatherController(ILogger<WeatherController> logger, WeatherApiClient weatherApiClient) : Controller
    {
        private readonly ILogger<WeatherController> _logger = logger;
        private readonly WeatherApiClient _weatherApiClient = weatherApiClient;
        private static List<Location> GetLocations()
        {
            return
            [
                new Location { ID = "LON", Name = "London, UK", TimeZone = "Europe/London" },
                new Location { ID = "LWK", Name = "Lerwick, UK", TimeZone = "Europe/London" },
                new Location { ID = "PAR", Name = "Paris, France", TimeZone = "Europe/Paris" },
                new Location { ID = "AMS", Name = "Amsterdam, Netherlands", TimeZone = "Europe/Amsterdam" },
                new Location { ID = "BER", Name = "Berlin, Germany", TimeZone = "Europe/Berlin" },
                new Location { ID = "ATH", Name = "Athens, Greece", TimeZone = "Europe/Athens" },
                new Location { ID = "BRU", Name = "Brussels, Belgium", TimeZone = "Europe/Brussels" },
                new Location { ID = "NYC", Name = "New York, USA", TimeZone = "America/New_York" },
                new Location { ID = "LIM", Name = "Lima, Peru", TimeZone = "America/Lima" },
                new Location { ID = "TYO", Name = "Tokyo, Japan", TimeZone = "Asia/Tokyo" },
                new Location { ID = "DOH", Name = "Doha, Qatar", TimeZone = "Asia/Qatar" },
                new Location { ID = "CAI", Name = "Cairo, Egypt", TimeZone = "Africa/Cairo" },
                new Location { ID = "JNB", Name = "Johannesburg, South Africa", TimeZone = "Africa/Johannesburg" },
            ];
        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var locations = GetLocations();
            ViewData["Locations"] = new SelectList(locations, "Name", "Name");

            // Default location for the initial load
            string selectedLocation = "London, UK";
            var selectedTimeZone = locations.First(l => l.Name == selectedLocation).TimeZone;
            ViewData["SelectedLocation"] = selectedLocation;
            ViewData["SelectedTimeZone"] = selectedTimeZone;

            // Get weather data for the selected location
            var getCurrentWeather = await _weatherApiClient.GetCurrentWeather(selectedLocation);
            var getWeatherForecast = await _weatherApiClient.GetWeatherForecast(selectedLocation);

            ViewData["CurrentWeather"] = getCurrentWeather;
            ViewData["Forecast"] = getWeatherForecast;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(string selectedLocation)
        {
            var locations = GetLocations();
            ViewData["Locations"] = new SelectList(locations, "Name", "Name", selectedLocation);

            var selectedTimeZone = locations.First(l => l.Name == selectedLocation).TimeZone;
            ViewData["SelectedTimeZone"] = selectedTimeZone;

            // Get weather data for the selected location
            var getCurrentWeather = await _weatherApiClient.GetCurrentWeather(selectedLocation);
            var getWeatherForecast = await _weatherApiClient.GetWeatherForecast(selectedLocation);

            ViewData["CurrentWeather"] = getCurrentWeather;
            ViewData["Forecast"] = getWeatherForecast;
            ViewData["SelectedLocation"] = selectedLocation;

            return View();
        }
    }
}
