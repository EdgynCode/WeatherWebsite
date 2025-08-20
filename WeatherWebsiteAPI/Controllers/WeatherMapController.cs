using Microsoft.AspNetCore.Mvc;
using WeatherWebsiteAPI.Services;
using WeatherWebsiteAPI.Models;

namespace WeatherWebsiteAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherMapController : ControllerBase
    {
        private readonly WeatherService _weatherService;

        public WeatherMapController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("tile/{layer}/{z}/{x}/{y}")]
        public async Task<IActionResult> GetTile(string layer, int z, int x, int y)
        {
            var bytes = await _weatherService.GetWeatherTileAsync(layer, z, x, y);
            return File(bytes, "image/png");
        }
    }
}