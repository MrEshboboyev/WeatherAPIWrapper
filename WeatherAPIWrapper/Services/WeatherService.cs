using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using WeatherAPIWrapper.External.HttpClients;
using WeatherAPIWrapper.Models;
using WeatherAPIWrapper.Services.IServices;

namespace WeatherAPIWrapper.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly WeatherHttpClient _weatherHttpClient;
        private readonly IDistributedCache _cache;
        private readonly TimeSpan _cacheExpiry = TimeSpan.FromHours(12);

        public WeatherService(WeatherHttpClient weatherHttpClient, IDistributedCache cache)
        {
            _weatherHttpClient = weatherHttpClient;
            _cache = cache;
        }

        public async Task<WeatherData> GetWeatherDataAsync(string location)
        {
            // Check if data is in the cache
            var cacheKey = $"WeatherData_{location.ToLower()}";
            var cachedWeatherData = await _cache.GetStringAsync(cacheKey);

            if (!string.IsNullOrEmpty(cachedWeatherData))
            {
                return JsonConvert.DeserializeObject<WeatherData>(cachedWeatherData);
            }

            // If not in cache, fetch the data from the API
            var weatherData = await _weatherHttpClient.FetchWeatherDataAsync(location);

            // Serialize the data and set it in cache with expiration
            var serializedWeatherData = JsonConvert.SerializeObject(weatherData);
            await _cache.SetStringAsync(cacheKey, serializedWeatherData, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = _cacheExpiry
            });

            return weatherData;
        }
    }
}
