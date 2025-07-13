using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WeatherWebsite.Models;
using WeatherWebsite.Services;

namespace WeatherWebsite.Controllers
{
    public class HomeController(ILogger<HomeController> logger, WeatherApiClient weatherApiClient) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly WeatherApiClient _weatherApiClient = weatherApiClient;

        private static List<Location> GetLocations()
        {
            return
            [
                new Location { ID = "LON", Name = "London, UK", TimeZone = "Europe/London", Lat = 51.5074, Lng = -0.1278 },
                new Location { ID = "LWK", Name = "Lerwick, UK", TimeZone = "Europe/London", Lat = 60.1553, Lng = -1.1456 },
                new Location { ID = "PAR", Name = "Paris, France", TimeZone = "Europe/Paris", Lat = 48.8566, Lng = 2.3522 },
                new Location { ID = "AMS", Name = "Amsterdam, Netherlands", TimeZone = "Europe/Amsterdam", Lat = 52.3676, Lng = 4.9041 },
                new Location { ID = "BER", Name = "Berlin, Germany", TimeZone = "Europe/Berlin", Lat = 52.5200, Lng = 13.4050 },
                new Location { ID = "ATH", Name = "Athens, Greece", TimeZone = "Europe/Athens", Lat = 37.9838, Lng = 23.7275 },
                new Location { ID = "BRU", Name = "Brussels, Belgium", TimeZone = "Europe/Brussels", Lat = 50.8503, Lng = 4.3517 },
                new Location { ID = "NYC", Name = "New York, USA", TimeZone = "America/New_York", Lat = 40.7128, Lng = -74.0060 },
                new Location { ID = "LIM", Name = "Lima, Peru", TimeZone = "America/Lima", Lat = -12.0464, Lng = -77.0428 },
                new Location { ID = "TYO", Name = "Tokyo, Japan", TimeZone = "Asia/Tokyo", Lat = 35.6762, Lng = 139.6503 },
                new Location { ID = "DOH", Name = "Doha, Qatar", TimeZone = "Asia/Qatar", Lat = 25.276987, Lng = 51.520008 },
                new Location { ID = "CAI", Name = "Cairo, Egypt", TimeZone = "Africa/Cairo", Lat = 30.0444, Lng = 31.2357 },
                new Location { ID = "JNB", Name = "Johannesburg, South Africa", TimeZone = "Africa/Johannesburg", Lat = -26.2041, Lng = 28.0473 },
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
            double lat = locations.First(l => l.Name == selectedLocation).Lat;
            double lng = locations.First(l => l.Name == selectedLocation).Lng;

            var getCurrentWeather = await _weatherApiClient.GetCurrentWeather(selectedLocation);
            var getWeatherForecast = await _weatherApiClient.GetWeatherForecast(selectedLocation);
            var getAirPollutionData = await _weatherApiClient.GetAQIData(lat, lng);

            ViewData["CurrentWeather"] = getCurrentWeather;
            ViewData["Forecast"] = getWeatherForecast;
            ViewData["AQIData"] = getAirPollutionData;

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

        public IActionResult WorldTime()
        {
            return View();
        }

        public IActionResult TimeConvert()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
