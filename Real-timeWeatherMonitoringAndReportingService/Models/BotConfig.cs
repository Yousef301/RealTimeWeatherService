namespace Real_timeWeatherMonitoringAndReportingService.Models;

public class BotConfig
{
    public bool Enabled { get; set; }
    public int TemperatureThreshold { get; set; }
    public int HumidityThreshold { get; set; }
    public string Message { get; set; }
}