using System.Text.Json.Serialization;

namespace WeatherDisplayApp.Data.Models;

public class TemperatureModel
{
    [JsonPropertyName("temp")]
    public double TempInKelvin { get; set; }

    [JsonPropertyName("tempInCelsius")]
    public double TempInCelsius => TempInKelvin - 273.15;

    [JsonPropertyName("tempInFarenhait")]
    public double TempInFarenhait => (TempInKelvin - 273.15) * 9 / 5 + 32;
}