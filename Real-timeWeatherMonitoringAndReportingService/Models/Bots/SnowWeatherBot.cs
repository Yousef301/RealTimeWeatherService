using System.ComponentModel.DataAnnotations;
using Real_timeWeatherMonitoringAndReportingService.Outputter;
using Real_timeWeatherMonitoringAndReportingService.Services;

namespace Real_timeWeatherMonitoringAndReportingService.Models;

public class SnowWeatherBot : IWeatherBot
{
    [Required(ErrorMessage = "Message is required.")]
    [StringLength(100, MinimumLength = 10, ErrorMessage = "Message length must be between 10 and 100 characters.")]
    public string Message { get; set; }

    [Required(ErrorMessage = "Temperature Threshold is required.")]
    [Range(-100, 100, ErrorMessage = "Temperature Threshold must be in range of -100 to 100.")]
    public int TemperatureThreshold { get; set; }

    public WeatherStation WeatherStation { get; set; }

    public void Update()
    {
        var snowBotService = new SnowBotService();

        var thresholds = new Dictionary<string, int>()
            { { "Temperature Threshold", TemperatureThreshold } };

        var values = new Dictionary<string, double>()
            { { "Temperature Threshold", WeatherStation.Temperature } };

        if (snowBotService.ActivateBot(thresholds, values, "snow"))
        {
            ConsoleOutput.BotActivatedMessage("SnowBot", Message);
        }
    }
}