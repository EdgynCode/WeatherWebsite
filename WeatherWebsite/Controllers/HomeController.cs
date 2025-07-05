using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WeatherWebsite.Models;
using WeatherWebsite.Services;

namespace WeatherWebsite.Controllers
{
    public class HomeController(ILogger<HomeController> logger) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly WeatherService _weatherService = new();

        private static List<Location> GetLocations()
        {
            return
            [
                new Location { ID = 1, Name = "London, UK", TimeZone = "Europe/London" },
                new Location { ID = 2, Name = "Paris, France", TimeZone = "Europe/Paris" },
                new Location { ID = 3, Name = "Amsterdam, Netherlands", TimeZone = "Europe/Amsterdam" },
                new Location { ID = 4, Name = "Berlin, Germany", TimeZone = "Europe/Berlin" },
                new Location { ID = 5, Name = "Athens, Greece", TimeZone = "Europe/Athens" },
                new Location { ID = 6, Name = "Brussels, Belgium", TimeZone = "Europe/Brussels" },
                new Location { ID = 7, Name = "New York, USA", TimeZone = "America/New_York" },
                new Location { ID = 8, Name = "Lima, Peru", TimeZone = "America/Lima" },
                new Location { ID = 9, Name = "Tokyo, Japan", TimeZone = "Asia/Tokyo" },
                new Location { ID = 10, Name = "Doha, Qatar", TimeZone = "Asia/Qatar" },
                new Location { ID = 11, Name = "Cairo, Egypt", TimeZone = "Africa/Cairo" },
                new Location { ID = 12, Name = "Johannesburg, South Africa", TimeZone = "Africa/Johannesburg" },
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
            var currentWeather = new WeatherService();
            var forecast = new WeatherService();
            var getCurrentWeather = await currentWeather.GetCurrentWeather(selectedLocation);
            var getWeatherForecast = await forecast.GetWeatherForecast(selectedLocation);

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
            var currentWeather = new WeatherService();
            var forecast = new WeatherService();
            var getCurrentWeather = await currentWeather.GetCurrentWeather(selectedLocation);
            var getWeatherForecast = await forecast.GetWeatherForecast(selectedLocation);

            ViewData["CurrentWeather"] = getCurrentWeather;
            ViewData["Forecast"] = getWeatherForecast;
            ViewData["SelectedLocation"] = selectedLocation;

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Weather()
        {
            var locations = GetLocations();
            ViewData["Locations"] = new SelectList(locations, "Name", "Name");

            // Default location for the initial load
            string selectedLocation = "London, UK";
            var selectedTimeZone = locations.First(l => l.Name == selectedLocation).TimeZone;
            ViewData["SelectedLocation"] = selectedLocation;
            ViewData["SelectedTimeZone"] = selectedTimeZone;

            // Get weather data for the selected location
            var currentWeather = new WeatherService();
            var forecast = new WeatherService();
            var getCurrentWeather = await currentWeather.GetCurrentWeather(selectedLocation);
            var getWeatherForecast = await forecast.GetWeatherForecast(selectedLocation);

            ViewData["CurrentWeather"] = getCurrentWeather;
            ViewData["Forecast"] = getWeatherForecast;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Weather(string selectedLocation)
        {
            var locations = GetLocations();
            ViewData["Locations"] = new SelectList(locations, "Name", "Name", selectedLocation);

            var selectedTimeZone = locations.First(l => l.Name == selectedLocation).TimeZone;
            ViewData["SelectedTimeZone"] = selectedTimeZone;

            // Get weather data for the selected location
            var currentWeather = new WeatherService();
            var forecast = new WeatherService();
            var getCurrentWeather = await currentWeather.GetCurrentWeather(selectedLocation);
            var getWeatherForecast = await forecast.GetWeatherForecast(selectedLocation);

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
