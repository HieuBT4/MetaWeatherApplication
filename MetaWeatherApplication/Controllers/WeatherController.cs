using MetaWeatherApplication.Model;
using MetaWeatherApplication.Service;
using MetaWeatherApplication.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MetaWeatherApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IOpenWeatherMapWrapper _wrapper;
        private readonly ApiSettings _apiSettings;

        public WeatherController(IOpenWeatherMapWrapper wrapper, IOptions<ApiSettings> apiSettings)
        {
            _wrapper = wrapper;
            _apiSettings = apiSettings.Value;
        }

        [HttpGet("{cityName}")]
        public async Task<IActionResult> GetWeatherData(string cityName)
        {
            try
            {
                var result = await _wrapper.GetWeatherDataAsync(cityName);
                return Ok(result);
            }
            catch
            {
                return BadRequest("Error occurred while fetching weather data.");
            }
        }
    }
}