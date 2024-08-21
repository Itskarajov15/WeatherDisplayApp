using Microsoft.AspNetCore.Mvc;
using WeatherDisplayApp.Data.Models;
using WeatherDisplayApp.Services.Contracts;

namespace WeatherDisplayApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet("getCurrentWeatherData/{cityName}")]
    [ProducesResponseType(typeof(CurrentWeatherModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCurrentWeatherData(string cityName)
    {
        if (string.IsNullOrEmpty(cityName))
        {
            return BadRequest("The name of city is required");
        }

        CurrentWeatherModel? result = await _weatherService.GetCurrentWeatherData(cityName);

        return result is null ? NotFound() : Ok(result);
    }
}