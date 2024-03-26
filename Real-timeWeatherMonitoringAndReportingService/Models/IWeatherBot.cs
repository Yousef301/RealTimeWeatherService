namespace Real_timeWeatherMonitoringAndReportingService.Models;

public interface IWeatherBot
{
    public bool Enabled { get; set; }
    public string Message { get; set; }
    public WeatherStation WeatherStation { get; set; }

    public void PrintActivateMessage();

    public void Update();
}