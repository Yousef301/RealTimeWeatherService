using Real_timeWeatherMonitoringAndReportingService.Enums;

namespace Real_timeWeatherMonitoringAndReportingService.Models;

public class WeatherDeserializerFactory
{
    public IWeatherDeserializer CreateDeserializer(DataFormat type)
    {
        switch (type)
        {
            case DataFormat.Json:
                return new JsonWeatherDeserializer();
            case DataFormat.Xml:
                return new XmlWeatherDeserializer();
            default:
                Console.WriteLine($"Invalid type: {type}");
                return null;
        }
    }
}