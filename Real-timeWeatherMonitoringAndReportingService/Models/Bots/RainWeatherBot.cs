using System.ComponentModel.DataAnnotations;
using Real_timeWeatherMonitoringAndReportingService.Interfaces;
using Real_timeWeatherMonitoringAndReportingService.Models.Weather;
using Real_timeWeatherMonitoringAndReportingService.Outputter;
using Real_timeWeatherMonitoringAndReportingService.Services;

namespace Real_timeWeatherMonitoringAndReportingService.Models.Bots;

public class RainWeatherBot : IWeatherBot
{
    [Required(ErrorMessage = "Message is required.")]
    [StringLength(100, MinimumLength = 10, ErrorMessage = "Message length must be between 10 and 100 characters.")]
    public string Message { get; set; }

    [Required(ErrorMessage = "Humidity Threshold is required.")]
    [Range(-100, 100, ErrorMessage = "Humidity Threshold must be in range of -100 to 100.")]
    public int HumidityThreshold { get; set; }

    public WeatherStation WeatherStation { get; set; }

    public void Update()
    {
        var rainBotService = new RainBotService();

        var thresholds = new Dictionary<string, int>()
            { { "Humidity Threshold", HumidityThreshold } };

        var values = new Dictionary<string, double>()
            { { "Humidity Threshold", WeatherStation.Humidity } };

        if (rainBotService.ActivateBot(thresholds, values, "rain"))
        {
            ConsoleOutput.DisplayBotActivationMessage("RainBot", Message);
        }
    }
}