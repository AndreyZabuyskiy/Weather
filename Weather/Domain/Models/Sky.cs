using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.Domain.Models
{
    public class Sky
    {
        public string Description { get; set; }
        public int Clouds { get; set; }

        public Sky(string description, int clouds)
        {
            Description = description;
            Clouds = clouds;
        }
    }
}
