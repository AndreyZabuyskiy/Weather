using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.Domain.Models
{
    public class Temperature
    {
        public double Value { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double FeelsLike { get; set; }

        public Temperature(double value, double min, double max, double feelsLike)
        {
            Value = value;
            Min = min;
            Max = max;
            FeelsLike = feelsLike;
        }
    }
}
