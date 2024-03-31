using Real_timeWeatherMonitoringAndReportingService.Models.Weather;

namespace Real_timeWeatherMonitoringAndReportingService.Interfaces;

public interface IObservable
{
    void Add(IWeatherBot bot);
    void Remove(IWeatherBot bot);
    void Notify(WeatherData newWeatherData);
}