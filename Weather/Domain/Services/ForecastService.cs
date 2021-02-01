using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Domain.Models;
using Weather.Domain.UseCases;

namespace Weather.Domain.Services
{
    public class ForecastService : IGetCurrentWeather, IGetForecast
    {
        private readonly IRequestCurrentWeather _currentWeatherRequestService;
        private readonly IRequestForecast _forecastRequestService;

        public ForecastService(IRequestCurrentWeather currentWeatherRequestService, IRequestForecast requestForecast)
        {
            _currentWeatherRequestService = currentWeatherRequestService;
            _forecastRequestService = requestForecast;
        }

        public async Task<WeatherData> GetCurrentWeather(string city)
        {
            dynamic data = await _currentWeatherRequestService.RequestCurrentWeather(city);
            WeatherData weather = WeatherData.GetWeatherData(data, true);
            return weather;
        }

        public async Task<Forecast> GetForecast(string city)
        {
            dynamic data = await _forecastRequestService.RequestForecast(city);
            Forecast forecast = new Forecast();

            foreach(var item in data.list)
            {
                string tmp_dt = item.dt_txt;
                var words = tmp_dt.Split(' ');

                WeatherData weather = WeatherData.GetWeatherData(item, false);

                if (!forecast.ForecastData.ContainsKey(words[0]))
                {
                    forecast.ForecastData.Add(words[0], new List<WeatherData>());
                }

                forecast.ForecastData[words[0]].Add(weather);
            }

            return forecast;
        }
    }
}
