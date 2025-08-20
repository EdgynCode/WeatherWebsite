using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WeatherWebsite.Models;
using WeatherWebsite.Services;

namespace WeatherWebsite.Controllers
{
    public class WeatherMapController : Controller
    {
        private readonly ILogger<WeatherMapController> _logger;

        public WeatherMapController(ILogger<WeatherMapController> logger, WeatherApiClient weatherApiClient)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}