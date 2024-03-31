using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Real_timeWeatherMonitoringAndReportingService.Models.Weather;

[XmlRoot("WeatherData")]
public class WeatherData
{
    [Required(ErrorMessage = "Temperature Threshold is required.")]
    [StringLength(40, MinimumLength = 5, ErrorMessage = "Message length must be between 5 and 40 characters.")]
    public string Location { get; set; }

    [Required(ErrorMessage = "Temperature is required.")]
    [Range(-100.0, 100.0, ErrorMessage = "Temperature must be in range of -100 to 100.")]
    public double Temperature { get; set; }

    [Required(ErrorMessage = "Humidity is required.")]
    [Range(-100.0, 100.0, ErrorMessage = "Humidity must be in range of -100 to 100.")]
    public double Humidity { get; set; }

    public override string ToString()
    {
        return $"Location -> {Location}\nTemperature -> {Temperature}\nHumidity -> {Humidity}";
    }
}