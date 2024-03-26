namespace Real_timeWeatherMonitoringAndReportingService.Services;

public class RainBotService : IBotService
{
    public bool ActivateBot(int threshold, double humidity) => humidity > threshold;
}