using WeatherDisplayApp.Data.Models;

namespace WeatherDisplayApp.Services.Contracts;

public interface IWeatherService
{
    public Task<CoordinatesByLocationNameModel?> CoordinatesByLocationName(string cityName);
}