using System.ComponentModel.DataAnnotations;
using Real_timeWeatherMonitoringAndReportingService.Outputter;

namespace Real_timeWeatherMonitoringAndReportingService.Models.Bots;

public class RainWeatherBot : WeatherBot
{
    
    [Required(ErrorMessage = "Humidity Threshold is required.")]
    [Range(-100, 100, ErrorMessage = "Humidity Threshold must be in range of -100 to 100.")]
    public int HumidityThreshold { get; set; }

    public override void Update()
    {
        var thresholds = new Dictionary<string, int>()
            { { "Humidity Threshold", HumidityThreshold } };

        var values = new Dictionary<string, double>()
            { { "Humidity Threshold", WeatherStation.Humidity } };

        if (BotService.ActivateBot(thresholds, values, this))
        {
            ConsoleOutput.DisplayBotActivationMessage("RainBot", Message);
        }
    }
}