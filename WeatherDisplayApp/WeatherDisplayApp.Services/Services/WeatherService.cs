using Microsoft.Extensions.Configuration;
using System.Text.Json;
using WeatherDisplayApp.Data;
using WeatherDisplayApp.Data.Models;
using WeatherDisplayApp.Services.Contracts;

namespace WeatherDisplayApp.Services.Services;

public class WeatherService : IWeatherService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;

    public WeatherService(
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }

    public async Task<CurrentWeatherModel?> GetCurrentWeatherData(string cityName)
    {
        CoordinatesByLocationNameModel? coordinates = await GetCoordinatesByLocationName(cityName);

        if (coordinates is null)
        {
            return null;
        }

        var response = await GetAsync($"{Constants.BaseAddress}{Constants.GetCurrentWeatherData}?lat={coordinates.Latitude}&lon={coordinates.Longitude}&appid={_configuration[Constants.OpenWeatherApiKey]}");

        CurrentWeatherModel? currentWeather = null;

        if (response?.IsSuccessStatusCode ?? false)
        {
            var content = await response.Content.ReadAsStringAsync();
            currentWeather = JsonSerializer.Deserialize<CurrentWeatherModel>(content);
        }

        return currentWeather;
    }

    private async Task<CoordinatesByLocationNameModel?> GetCoordinatesByLocationName(string cityName)
    {
        var response = await GetAsync($"{Constants.BaseAddress}{Constants.GetCoordinatesByLocationName}?q={cityName}&appid={_configuration[Constants.OpenWeatherApiKey]}");

        CoordinatesByLocationNameModel? coordinates = null;

        if (response?.IsSuccessStatusCode ?? false)
        {
            var content = await response.Content.ReadAsStringAsync();
            var coordinatesResult = JsonSerializer.Deserialize<List<CoordinatesByLocationNameModel>>(content);

            coordinates = coordinatesResult?.FirstOrDefault();
        }

        return coordinates;
    }

    private async Task<HttpResponseMessage?> GetAsync(string url)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync(url);

        return response;
    }
}