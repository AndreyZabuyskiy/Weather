using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.Domain.Models
{
    public class Forecast
    {
        public Dictionary<string, List<WeatherData>> ForecastData { get; set; }
        public string Dates { get; set; }

        public Forecast()
        {
            ForecastData = new Dictionary<string, List<WeatherData>>();
        }
    }
}
