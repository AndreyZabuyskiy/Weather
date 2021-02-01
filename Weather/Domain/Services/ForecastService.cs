using System;
using System.Collections.Generic;
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
            WeatherData weather = MapForecastItemToWeatherData(data, true);
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

                WeatherData weather = MapForecastItemToWeatherData(item, false);

                if (!forecast.ForecastData.ContainsKey(words[0]))
                {
                    forecast.ForecastData.Add(words[0], new List<WeatherData>());
                }

                forecast.ForecastData[words[0]].Add(weather);
            }

            return forecast;
        }

        private WeatherData MapForecastItemToWeatherData(dynamic data, bool useCurrentDate)
        {
            string date;

            if (useCurrentDate)
            {
                date = DateTime.Now.ToString("o");
            }
            else
            {
                date = data.dt_txt;
            }

            double tempValue = data.main.temp;
            double min = data.main.temp_min;
            double max = data.main.temp_max;
            double feelsLike = data.main.feels_like;

            double windSpeed = data.wind.speed;
            int windDeg = data.wind.deg;

            string skyDescription = data.weather[0].description;
            int clouds = data.clouds.all;

            Temperature temp = new Temperature(tempValue, min, max, feelsLike);
            Wind wind = new Wind(windSpeed, windDeg);
            Sky sky = new Sky(skyDescription, clouds);
            WeatherData weather = new WeatherData(temp, wind, sky, date);

            return weather;
        }
    }
}
