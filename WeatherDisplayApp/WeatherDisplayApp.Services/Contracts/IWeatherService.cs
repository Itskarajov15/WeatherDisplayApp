using WeatherDisplayApp.Data.Models;

namespace WeatherDisplayApp.Services.Contracts;

public interface IWeatherService
{
    Task<CurrentWeatherModel?> GetCurrentWeatherData(string cityName);
}