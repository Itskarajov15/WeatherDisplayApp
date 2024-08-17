using Microsoft.Extensions.Configuration;
using System.Text.Json;
using WeatherDisplayApp.Data;
using WeatherDisplayApp.Data.Models;
using WeatherDisplayApp.Services.Contracts;

namespace WeatherDisplayApp.Services.Services;

public class WeatherService : IWeatherService
{
    private readonly IHttpClientFactory _httpClientFactor;
    private readonly IConfiguration _configuration;

    public WeatherService(
        IHttpClientFactory httpClientFactor,
        IConfiguration configuration)
    {
        _httpClientFactor = httpClientFactor;
        _configuration = configuration;
    }

    public async Task<CoordinatesByLocationNameModel?> CoordinatesByLocationName(string cityName)
    {
        var client = _httpClientFactor.CreateClient();
        var response = await client.GetAsync($"{Constants.BaseAddress}{Constants.GetCoordinatesByLocationName}?q={cityName}&appid={_configuration[Constants.OpenWeatherApiKey]}");

        CoordinatesByLocationNameModel? coordinates = new();

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var coordinatesResult = JsonSerializer.Deserialize<List<CoordinatesByLocationNameModel>>(content);

            coordinates = coordinatesResult?.FirstOrDefault();
        }

        return coordinates;
    }
}