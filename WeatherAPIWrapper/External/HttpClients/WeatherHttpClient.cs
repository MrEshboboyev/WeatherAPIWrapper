using AutoMapper;
using Newtonsoft.Json;
using WeatherAPIWrapper.Models;
using WeatherAPIWrapper.Models.DTOs;

namespace WeatherAPIWrapper.External.HttpClients
{
    public class WeatherHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly IMapper _mapper;

        public WeatherHttpClient(HttpClient httpClient, IConfiguration config, 
            IMapper mapper)
        {
            _httpClient = httpClient;
            _apiKey = config["WeatherAPI:Key"];
            _mapper = mapper;
        }

        public async Task<WeatherData> FetchWeatherDataAsync(string location)
        {
            var requestUrl = $"{location}?key={_apiKey}";
            var response = await _httpClient.GetAsync(requestUrl);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Request failed with status code {response.StatusCode}");
            }

            var body = await response.Content.ReadAsStringAsync();
            var weatherDataDto = JsonConvert.DeserializeObject<WeatherDataDto>(body);

            // use AutoMapper to map DTO to domain model
            var weatherData = _mapper.Map<WeatherData>(weatherDataDto);

            return weatherData;
        }
    }
}
