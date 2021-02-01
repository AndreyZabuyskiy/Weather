using System.Threading.Tasks;
using Weather.Domain.Models;

namespace Weather.Domain.UseCases
{
    public interface IGetCurrentWeather
    {
        Task<WeatherData> GetCurrentWeather(string city);
    }
}
