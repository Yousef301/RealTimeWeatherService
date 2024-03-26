using System.ComponentModel.DataAnnotations;
using Real_timeWeatherMonitoringAndReportingService.Logs;
using Real_timeWeatherMonitoringAndReportingService.Services;

namespace Real_timeWeatherMonitoringAndReportingService.Models;

public class RainWeatherBot : IWeatherBot
{
    [Required(ErrorMessage = "Bot status is required.")]
    public bool Enabled { get; set; }

    [Required(ErrorMessage = "Message is required.")]
    [StringLength(100, MinimumLength = 10, ErrorMessage = "Message length must be between 10 and 100 characters.")]
    public string Message { get; set; }

    [Required(ErrorMessage = "Humidity Threshold is required.")]
    [Range(-100, 100, ErrorMessage = "Humidity Threshold must be in range of -100 to 100.")]
    public int HumidityThreshold { get; set; }

    public WeatherStation WeatherStation { get; set; }

    public void PrintActivateMessage()
    {
        Console.WriteLine(Message);
    }

    public void Update()
    {
        RainBotService rainBotService = new RainBotService();

        if (rainBotService.ActivateBot(HumidityThreshold, WeatherStation.Humidity))
        {
            Enabled = true;
            Log.BotActivatedMessage("RainBot", Message);
        }
        else Enabled = false;
    }
}