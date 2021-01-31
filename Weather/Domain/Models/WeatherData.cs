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

        public WeatherData(Temperature temp, Wind wind, Sky sky)
        {
            Temp = temp;
            Wind = wind;
            Sky = sky;
        }
    }
}
