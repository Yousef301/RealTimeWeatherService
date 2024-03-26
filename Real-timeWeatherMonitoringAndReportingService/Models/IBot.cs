namespace Real_timeWeatherMonitoringAndReportingService.Models;

public interface IBot
{
    public bool Enabled { get; set; }
    public string Message { get; set; }

    public void PrintActivateMessage();
}