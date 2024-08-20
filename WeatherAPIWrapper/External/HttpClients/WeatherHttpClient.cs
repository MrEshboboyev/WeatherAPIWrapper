using WeatherAPIWrapper.Models;

namespace WeatherAPIWrapper.External.HttpClients
{
    public class WeatherHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WeatherHttpClient(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _apiKey = config["WeatheAPI:Key"];
        }

        public async Task<WeatherData> FetchWeatherDataAsync(string location)
        {
            var response = await _httpClient.GetAsync($"v1/weather?location={location}&key={_apiKey}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<WeatherData>();
        }
    }
}
