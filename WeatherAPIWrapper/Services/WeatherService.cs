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

        public async Task<dynamic> GetWeatherDataAsync(string location)
        {
            var weatherData = await _weatherHttpClient.FetchWeatherDataAsync(location);
            var weatherDataAsJson = JsonConvert.SerializeObject(weatherData);
            var weatherDataAsDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(weatherDataAsJson);
            return weatherDataAsDictionary;
        }
    }
}
