using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace WeatherDisplayApp.Tests;

public class WeatherControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private const string _apiPath = "/api/weather/getCurrentWeatherData/";

    public WeatherControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData("Sofia")]
    [InlineData("Blagoevgrad")]
    [InlineData("Plovdiv")]
    public async Task GetCurrentWeatherDataShouldReturnOkResponseWhenCityNameIsValid(string cityName)
    {
        // Arrange
        HttpClient client = _factory.CreateClient();

        // Act
        HttpResponseMessage response = await client.GetAsync($"{_apiPath}{cityName}");

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task GetCurrentWeatherDataShouldReturnNotFoundResponseWhenCityNameIsNullOrEmpty(string cityName)
    {
        // Arrange
        HttpClient client = _factory.CreateClient();

        // Act
        HttpResponseMessage response = await client.GetAsync($"{_apiPath}{cityName}");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Theory]
    [InlineData("InvalidCityName")]
    [InlineData("InvalidCityName2")]
    public async Task GetCurrentWeatherDataShouldReturnNotFoundResponseWhenCityNameIsInvalid(string cityName)
    {
        // Arrange
        HttpClient client = _factory.CreateClient();

        // Act
        HttpResponseMessage response = await client.GetAsync($"{_apiPath}{cityName}");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}