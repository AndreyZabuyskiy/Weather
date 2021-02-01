using System.Threading.Tasks;

namespace Weather.Domain.UseCases
{
    public interface IRequestCurrentWeather
    {
        Task<dynamic> RequestCurrentWeather(string city);
    }
}
