using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Weather.Domain.Ports;
using Weather.Domain.UseCases;

namespace Weather.Domain.Services
{
    public class ForecastRequestService : IRequestForecast, IRequestCurrentWeather
    {
        private readonly IApiConfigPort _apiConfig;

        public ForecastRequestService(IApiConfigPort apiConfig)
        {
            _apiConfig = apiConfig;
        }

        public async Task<dynamic> RequestCurrentWeather(string city)
        {
            using HttpClient client = new HttpClient();

            string url = CreateApiUrl(city, "weather");
            string response = await client.GetStringAsync(url);
            dynamic data = JsonConvert.DeserializeObject(response);

            return data;
        }

        public async Task<dynamic> RequestForecast(string city)
        {
            using HttpClient client = new HttpClient();
            string url = CreateApiUrl(city, "forecast");
            string response = await client.GetStringAsync(url);
            dynamic data = JsonConvert.DeserializeObject(response);

            return data;
        }

        private string CreateApiUrl(string query, string endpoint) 
        {
            return $"{_apiConfig.Url}/{endpoint}?q={query}&units=metric&appid={_apiConfig.Key}";
        }
    }
}
