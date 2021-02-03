using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Weather.Domain.Models;
using Weather.Domain.UseCases;

namespace Weather.Controllers
{
    /// <summary>
    /// Weather Controller managing weather
    /// </summary>
    //[ApiController]
    //[Route("controller")]
    public class WeatherController : Controller
    {
        private readonly IGetCurrentWeather _currentWeatherService;
        private readonly IGetForecast _forecastService;

        public WeatherController([FromServices]IGetCurrentWeather currentWeatherService, 
            [FromServices]IGetForecast forecastService)
        {
            _currentWeatherService = currentWeatherService;
            _forecastService = forecastService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentWeather([Required] string city)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "City is not provided" });
                }

                WeatherData data = await _currentWeatherService.GetCurrentWeather(city);
                return Json(data);
            }
            catch
            {
                return BadRequest(new { message = "Bad Request" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetForecast([Required] string city)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "City is not provided" });
                }

                Forecast data = await _forecastService.GetForecast(city);
                return Json(data.ForecastData);
            }
            catch
            {
                return BadRequest(new { message = "Bad Request" });
            }
        }
    }
}
