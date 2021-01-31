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
        //private readonly IRequestForecast _requestForecast;

        public ForecastService(IRequestCurrentWeather requestCurrentWeather)
        {
            _requestCurrentWeather = requestCurrentWeather;
        }

        public async Task<WeatherData> GetCurrentWeather(string city)
        {
            dynamic data = await _requestCurrentWeather.RequestCurrentWeather(city);

            double tempValue = data.main.temp;
            double min = data.main.temp_min;
            double max = data.main.temp_max;
            double feelsLike = data.main.feels_like;

            double windSpeed = data.wind.speed;
            int windDeg = data.wind.deg;

            string skyDescription = data.weather[0].description;
            int clouds = data.clouds.all;

            Temperature temp = new Temperature(tempValue, min, max, feelsLike);
            Wind wind = new Wind(windSpeed , windDeg);
            Sky sky = new Sky(skyDescription, clouds);
            WeatherData weather = new WeatherData(temp, wind, sky);

            return weather;
        }
    }
}
