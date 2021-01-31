using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Weather.Domain.Models;
using Weather.Domain.UseCases;

namespace Weather.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IGetCurrentWeather _currentWeatherService;

        public WeatherController([FromServices]IGetCurrentWeather currentWeatherService)
        {
            _currentWeatherService = currentWeatherService;
        }

        public async Task<JsonResult> GetCurrentWeather(string city)
        {
            WeatherData data = await _currentWeatherService.GetCurrentWeather(city);

            return Json(data);
        }
    }
}
