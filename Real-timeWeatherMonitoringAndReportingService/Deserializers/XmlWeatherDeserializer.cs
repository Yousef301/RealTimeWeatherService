using System.Xml;
using System.Xml.Serialization;
using Real_timeWeatherMonitoringAndReportingService.Models;

namespace Real_timeWeatherMonitoringAndReportingService.Deserializers
{
    public class XmlWeatherDeserializer : IWeatherDeserializer
    {
        public WeatherData? TryDeserializeWeatherInfo(string rawData)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(WeatherData));

                using StringReader reader = new StringReader(rawData);

                WeatherData weatherData = (WeatherData)serializer.Deserialize(reader);

                return weatherData;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}