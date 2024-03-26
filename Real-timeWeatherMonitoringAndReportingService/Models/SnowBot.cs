using System.ComponentModel.DataAnnotations;

namespace Real_timeWeatherMonitoringAndReportingService.Models;

public class SnowBot : IBot
{
    [Required(ErrorMessage = "Bot status is required.")]
    public bool Enabled { get; set; }

    [Required(ErrorMessage = "Message is required.")]
    [StringLength(100, MinimumLength = 10, ErrorMessage = "Message length must be between 10 and 100 characters.")]
    public string Message { get; set; }

    [Required(ErrorMessage = "Temperature Threshold is required.")]
    [Range(-100, 100, ErrorMessage = "Temperature Threshold must be in range of -100 to 100.")]
    public int TemperatureThreshold { get; set; }

    public void PrintActivateMessage()
    {
        Console.WriteLine(Message);
    }
}