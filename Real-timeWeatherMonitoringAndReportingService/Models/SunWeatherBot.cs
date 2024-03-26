using System.ComponentModel.DataAnnotations;
using Real_timeWeatherMonitoringAndReportingService.Logs;
using Real_timeWeatherMonitoringAndReportingService.Services;

namespace Real_timeWeatherMonitoringAndReportingService.Models;

public class SunWeatherBot : IWeatherBot
{
    [Required(ErrorMessage = "Bot status is required.")]
    public bool Enabled { get; set; }

    [Required(ErrorMessage = "Message is required.")]
    [StringLength(100, MinimumLength = 10, ErrorMessage = "Message length must be between 10 and 100 characters.")]
    public string Message { get; set; }

    [Required(ErrorMessage = "Temperature Threshold is required.")]
    [Range(-100, 100, ErrorMessage = "Temperature Threshold must be in range of -100 to 100.")]
    public int TemperatureThreshold { get; set; }

    public WeatherStation WeatherStation { get; set; }

    public void PrintActivateMessage()
    {
        Console.WriteLine(Message);
    }

    public void Update()
    {
        SunBotService sunBotService = new SunBotService();

        if (sunBotService.ActivateBot(TemperatureThreshold, WeatherStation.Temperature))
        {
            Enabled = true;
            Log.BotActivatedMessage("SunBot", Message);
        }
        else Enabled = false;
    }
}