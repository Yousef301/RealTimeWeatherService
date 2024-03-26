namespace Real_timeWeatherMonitoringAndReportingService.Services;

public interface IBotService
{
    public bool ActivateBot(int threshold, double value);
}