using System.Collections.Generic;

namespace Weather.Domain.Models
{
    public class Forecast
    {
        public Dictionary<string, List<WeatherData>> ForecastData { get; set; }

        public Forecast()
        {
            ForecastData = new Dictionary<string, List<WeatherData>>();
        }
    }
}
