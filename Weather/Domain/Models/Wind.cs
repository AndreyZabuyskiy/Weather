using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.Domain.Models
{
    public class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }

        public Wind(double speed, int deg)
        {
            Speed = speed;
            Deg = deg;
        }
    }
}
