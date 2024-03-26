using System.Xml.Serialization;

namespace Real_timeWeatherMonitoringAndReportingService.Models;

public class XmlWeatherDeserializer : IWeatherDeserializer
{
    public WeatherStation DeserializeWeatherInfo(string rawData)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(WeatherStation));

        WeatherStation weatherStation;

        using StringReader reader = new StringReader(rawData);
        weatherStation = (WeatherStation)serializer.Deserialize(reader);

        return weatherStation;
    }
}