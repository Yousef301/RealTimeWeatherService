using Real_timeWeatherMonitoringAndReportingService.Models;

namespace Real_timeWeatherMonitoringAndReportingService.Services;

public class WeatherStationService
{
    public static void InitializeObservers(WeatherStation weatherStation, Dictionary<string, IWeatherBot> bots)
    {
        foreach (var bot in bots.Values)
        {
            weatherStation.Add(bot);
        }
    }
}