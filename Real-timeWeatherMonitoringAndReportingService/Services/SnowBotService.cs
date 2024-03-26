namespace Real_timeWeatherMonitoringAndReportingService.Services;

public class SnowBotService : IBotService
{
    public bool ActivateBot(int threshold, double temperature) => temperature < threshold;
}