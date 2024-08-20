using WeatherAPIWrapper.Models;

namespace WeatherAPIWrapper.Services.IServices
{
    public interface IWeatherService
    {
        Task<dynamic> GetWeatherDataAsync(string location);
    }
}
