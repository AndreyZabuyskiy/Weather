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

        /// <summary>
        /// This method returns the current weather for the specified city
        /// </summary>
        /// <param name="city"></param>
        /// <returns>Json object of current weather</returns>
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

        /// <summary>
        /// This method returns the weather forecast for the specified city
        /// </summary>
        /// <param name="city"></param>
        /// <returns>An array of json objects weather forecasts</returns>
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
