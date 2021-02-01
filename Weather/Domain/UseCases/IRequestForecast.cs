using System.Threading.Tasks;

namespace Weather.Domain.UseCases
{
    public interface IRequestForecast
    {
        Task<dynamic> RequestForecast(string city);
    }
}
