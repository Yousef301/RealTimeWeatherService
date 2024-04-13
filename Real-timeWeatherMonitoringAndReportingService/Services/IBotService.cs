using Real_timeWeatherMonitoringAndReportingService.Interfaces;

namespace Real_timeWeatherMonitoringAndReportingService.Services;

public interface IBotService
{
    public bool ActivateBot(Dictionary<string, int> thresholds, Dictionary<string, double> values,
        IWeatherBot bot);
}