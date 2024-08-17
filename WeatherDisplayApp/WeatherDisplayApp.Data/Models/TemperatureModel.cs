using System.Text.Json.Serialization;

namespace WeatherDisplayApp.Data.Models;

public class TemperatureModel
{
    [JsonPropertyName("temp")]
    public double Temp { get; set; }

    [JsonPropertyName("feels_like")]
    public double FeelsLike { get; set; }
}