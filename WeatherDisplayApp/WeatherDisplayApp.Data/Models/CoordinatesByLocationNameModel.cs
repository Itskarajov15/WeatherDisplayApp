using System.Text.Json.Serialization;

namespace WeatherDisplayApp.Data.Models;

public class CoordinatesByLocationNameModel
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("lat")]
    public double Latitude { get; set; }

    [JsonPropertyName("lon")]
    public double Longitude { get; set; }
}