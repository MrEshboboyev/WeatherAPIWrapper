using Newtonsoft.Json;
using WeatherAPIWrapper.External.HttpClients;
using WeatherAPIWrapper.Models;
using WeatherAPIWrapper.Services.IServices;

namespace WeatherAPIWrapper.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly WeatherHttpClient _weatherHttpClient;

        public WeatherService(WeatherHttpClient weatherHttpClient)
        {
            _weatherHttpClient = weatherHttpClient;
        }

        public async Task<WeatherData> GetWeatherDataAsync(string location)
        {
            return await _weatherHttpClient.FetchWeatherDataAsync(location);
        }
    }
}
