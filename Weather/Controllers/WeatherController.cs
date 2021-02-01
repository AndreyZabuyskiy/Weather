using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weather.Domain.Models;
using Weather.Domain.UseCases;

namespace Weather.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IGetCurrentWeather _currentWeatherService;
        private readonly IGetForecast _getForecast;

        public WeatherController([FromServices]IGetCurrentWeather currentWeatherService, [FromServices]IGetForecast getForecast)
        {
            _currentWeatherService = currentWeatherService;
            _getForecast = getForecast;
        }

        public async Task<JsonResult> GetCurrentWeather(string city)
        {
            WeatherData data = await _currentWeatherService.GetCurrentWeather(city);

            return Json(data);
        }

        public async Task<JsonResult> GetForecast(string city)
        {
            Forecast data = await _getForecast.GetForecast(city);

            return Json(data.ForecastData);
        }
    }
}
