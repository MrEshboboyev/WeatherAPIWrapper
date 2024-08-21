using WeatherAPIWrapper.Models;

namespace WeatherAPIWrapper.Services.IServices
{
    public interface IWeatherService
    {
        Task<WeatherData> GetWeatherDataAsync(string location);
    }
}
