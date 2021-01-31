using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Domain.Models;
using Weather.Domain.UseCases;

namespace Weather.Domain.Services
{
    public class ForecastService : IGetCurrentWeather
    {
        private readonly IRequestCurrentWeather _requestCurrentWeather;
        private readonly IRequestForecast _requestForecast;

        public ForecastService(IRequestCurrentWeather requestCurrentWeather)
        {
            _requestCurrentWeather = requestCurrentWeather;
        }

        public async Task<WeatherData> GetCurrentWeather(string city)
        {
            dynamic data = await _requestCurrentWeather.RequestCurrentWeather(city);
            Temperature temp = new Temperature(data.main.temp, data.main.temp_min, data.main.temp_max, data.main.feels_like);
            Wind wind = new Wind(data.wind.speed, data.wind.deg);
            Sky sky = new Sky(data.weather[0].description, data.clouds.all);
            WeatherData weather = new WeatherData(temp, wind, sky);

            return weather;
        }
    }
}
