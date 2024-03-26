using System.Xml.Serialization;

namespace Real_timeWeatherMonitoringAndReportingService.Models;

[XmlRoot("WeatherData")]
public class WeatherStation
{
    public string Location { get; init; }
    public double Temperature { get; init; }
    public double Humidity { get; init; }

    public override string ToString()
    {
        return $"Location -> {Location}\nTemperature -> {Temperature}\nHumidity -> {Humidity}";
    }
}