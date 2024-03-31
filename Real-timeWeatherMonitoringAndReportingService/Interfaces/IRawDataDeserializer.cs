namespace Real_timeWeatherMonitoringAndReportingService.Interfaces;

public interface IRawDataDeserializer<out T>
{
    public T? TryDeserializeWeatherInfo(string rawData);
}