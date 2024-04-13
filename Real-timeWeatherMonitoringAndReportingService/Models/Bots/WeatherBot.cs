using System.ComponentModel.DataAnnotations;
using Real_timeWeatherMonitoringAndReportingService.Interfaces;
using Real_timeWeatherMonitoringAndReportingService.Models.Weather;
using Real_timeWeatherMonitoringAndReportingService.Services;

namespace Real_timeWeatherMonitoringAndReportingService.Models.Bots;

public abstract class WeatherBot : IWeatherBot
{
    [Required(ErrorMessage = "Activated is required.")]
    public bool Activated { get; set; }

    [Required(ErrorMessage = "Message is required.")]
    [StringLength(100, MinimumLength = 10, ErrorMessage = "Message length must be between 10 and 100 characters.")]
    public string Message { get; set; }

    public WeatherStation WeatherStation { get; set; }

    [Required(ErrorMessage = "BotService is required.")]
    public IBotService BotService { get; set; }

    public abstract void Update();
}