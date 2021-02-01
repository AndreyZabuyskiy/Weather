using System.Threading.Tasks;
using Weather.Domain.Models;

namespace Weather.Domain.UseCases
{
    public interface IGetForecast
    {
        Task<Forecast> GetForecast(string city);
    }
}
