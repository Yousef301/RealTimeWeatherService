namespace Real_timeWeatherMonitoringAndReportingService.Models;

public interface IWeatherBot
{
    public string Message { get; set; }
    public WeatherStation WeatherStation { get; set; }

    public void Update();
}