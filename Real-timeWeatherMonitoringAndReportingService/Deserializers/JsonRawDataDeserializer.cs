using Newtonsoft.Json;
using Real_timeWeatherMonitoringAndReportingService.Interfaces;

namespace Real_timeWeatherMonitoringAndReportingService.Deserializers
{
    public class JsonRawDataDeserializer<T> : IRawDataDeserializer<T>
    {
        public T? TryDeserializeWeatherInfo(string rawData)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(rawData);
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}