namespace Real_timeWeatherMonitoringAndReportingService.Models.Configurations;

public class BotConfig
{
    public bool Activated { get; set; }
    public bool Enabled { get; init; }
    public int TemperatureThreshold { get; set; }
    public int HumidityThreshold { get; set; }
    public string Message { get; set; }
}