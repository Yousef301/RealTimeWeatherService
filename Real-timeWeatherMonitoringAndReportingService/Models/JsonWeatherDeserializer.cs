using Newtonsoft.Json;

namespace Real_timeWeatherMonitoringAndReportingService.Models;

public class JsonWeatherDeserializer : IWeatherDeserializer
{
    public WeatherStation DeserializeWeatherInfo(string rawData)
    {
        return JsonConvert.DeserializeObject<WeatherStation>(rawData);
    }
}