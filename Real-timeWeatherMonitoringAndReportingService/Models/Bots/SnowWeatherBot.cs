using System.ComponentModel.DataAnnotations;
using Real_timeWeatherMonitoringAndReportingService.Outputter;

namespace Real_timeWeatherMonitoringAndReportingService.Models.Bots;

public class SnowWeatherBot : WeatherBot
{
    [Required(ErrorMessage = "Temperature Threshold is required.")]
    [Range(-100, 100, ErrorMessage = "Temperature Threshold must be in range of -100 to 100.")]
    public int TemperatureThreshold { get; set; }

    public override void Update()
    {
        var thresholds = new Dictionary<string, int>()
            { { "Temperature Threshold", TemperatureThreshold } };

        var values = new Dictionary<string, double>()
            { { "Temperature Threshold", WeatherStation.Temperature } };

        if (BotService.ActivateBot(thresholds, values, this))
        {
            ConsoleOutput.DisplayBotActivationMessage("SnowBot", Message);
        }
    }
}