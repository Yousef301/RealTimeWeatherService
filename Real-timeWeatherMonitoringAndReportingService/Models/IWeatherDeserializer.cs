namespace Real_timeWeatherMonitoringAndReportingService.Models;

public interface IWeatherDeserializer
{
    public WeatherData? TryDeserializeWeatherInfo(string rawData);
}