using Real_timeWeatherMonitoringAndReportingService.Models.Weather;

namespace Real_timeWeatherMonitoringAndReportingService.Interfaces;

public interface IWeatherBot
{
    public string Message { get; set; }
    public WeatherStation WeatherStation { get; set; }

    public void Update();
}