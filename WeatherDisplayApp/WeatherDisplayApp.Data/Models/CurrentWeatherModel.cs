using System.Text.Json.Serialization;

namespace WeatherDisplayApp.Data.Models;

public class CurrentWeatherModel
{
    [JsonPropertyName("weather")]
    public List<WeatherModel> Weather { get; set; } = new();

    [JsonPropertyName("main")]
    public TemperatureModel Temperature { get; set; } = null!;
}