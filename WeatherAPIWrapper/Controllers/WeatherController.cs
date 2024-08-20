using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherAPIWrapper.Services.IServices;

namespace WeatherAPIWrapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("{location}")]
        public async Task<IActionResult> GetWeatherData(string location)
        {
            var weatherData = await _weatherService.GetWeatherDataAsync(location);
            if (weatherData == null)
                return NotFound();

            return Ok(weatherData);
        }
    }
}
