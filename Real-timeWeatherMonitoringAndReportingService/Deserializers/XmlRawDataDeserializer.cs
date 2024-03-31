using System.Xml.Serialization;
using Real_timeWeatherMonitoringAndReportingService.Interfaces;

namespace Real_timeWeatherMonitoringAndReportingService.Deserializers
{
    public class XmlRawDataDeserializer<T> : IRawDataDeserializer<T>
    {
        public T? TryDeserializeWeatherInfo(string rawData)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));

                using var reader = new StringReader(rawData);

                return (T)serializer.Deserialize(reader)!;
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}