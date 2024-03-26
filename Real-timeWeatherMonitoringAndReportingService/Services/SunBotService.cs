namespace Real_timeWeatherMonitoringAndReportingService.Services;

public class SunBotService : IBotService
{
    public bool ActivateBot(int threshold, double temperature) => temperature > threshold;
}