using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.Domain.Models
{
    public class WeatherData
    {        
        public Temperature Temp { get; set; }
        public Wind Wind { get; set; }
        public Sky Sky { get; set; }
        public string Date { get; set; }

        public WeatherData(Temperature temp, Wind wind, Sky sky, string date)
        {
            Temp = temp;
            Wind = wind;
            Sky = sky;
            Date = date;
        }

        static public WeatherData GetWeatherData(dynamic data, bool isDateISO)
        {
            string date;

            if (isDateISO)
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
