using Real_timeWeatherMonitoringAndReportingService.Models.Weather;
using Real_timeWeatherMonitoringAndReportingService.Services;

namespace Real_timeWeatherMonitoringAndReportingService.Interfaces;

public interface IWeatherBot
{
    public bool Activated { get; set; }
    public string Message { get; set; }
    public WeatherStation WeatherStation { get; set; }
    public IBotService BotService { get; set; }

    public void Update();
}