using System.Text.Json.Serialization;

namespace WeatherDisplayApp.Data.Models;

public class WeatherModel
{
    [JsonPropertyName("main")]
    public string Main { get; set; } = String.Empty;

    [JsonPropertyName("description")]
    public string Desctiption { get; set; } = String.Empty;

    [JsonPropertyName("icon")]
    public string Icon { get; set; } = String.Empty;
}