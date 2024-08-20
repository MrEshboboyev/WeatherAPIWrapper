using Newtonsoft.Json;
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
            _apiKey = config["WeatherAPI:Key"];
        }

        public async Task<dynamic> FetchWeatherDataAsync(string location)
        {
            var requestUrl = $"{location}?key={_apiKey}";
            var response = await _httpClient.GetAsync(requestUrl);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Request failed with status code {response.StatusCode}");
            }

            var body = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(body);
        }
    }
}
