using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.Domain.UseCases
{
    public interface IRequestForecast
    {
        Task<dynamic> RequestForecast(string city);
    }
}
