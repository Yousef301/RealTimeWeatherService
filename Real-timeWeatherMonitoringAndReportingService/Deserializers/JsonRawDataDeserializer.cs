using Newtonsoft.Json;
using Real_timeWeatherMonitoringAndReportingService.Models;
using System;

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