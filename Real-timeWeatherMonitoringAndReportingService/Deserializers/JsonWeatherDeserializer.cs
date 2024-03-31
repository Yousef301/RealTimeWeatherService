using Newtonsoft.Json;
using Real_timeWeatherMonitoringAndReportingService.Models;

namespace Real_timeWeatherMonitoringAndReportingService.Deserializers;

public class JsonWeatherDeserializer : IWeatherDeserializer
{
    public WeatherData? TryDeserializeWeatherInfo(string rawData)
    {
        try
        {
            return JsonConvert.DeserializeObject<WeatherData>(rawData);
        }
        catch (Exception)
        {
            return null;
        }
    }
}