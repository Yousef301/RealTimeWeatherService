namespace Real_timeWeatherMonitoringAndReportingService.Models;

public interface IObservable
{
    void Add(IWeatherBot bot);
    void Remove(IWeatherBot bot);
    void Notify();
}