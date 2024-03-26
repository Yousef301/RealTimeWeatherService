namespace Real_timeWeatherMonitoringAndReportingService.Models;

public interface IWeatherDeserializer
{
    WeatherStation DeserializeWeatherInfo(string rawData);
}