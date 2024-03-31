namespace Real_timeWeatherMonitoringAndReportingService.Models;

public interface IRawDataDeserializer<T>
{
    public T? TryDeserializeWeatherInfo(string rawData);
}