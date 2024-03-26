namespace Real_timeWeatherMonitoringAndReportingService.Models;

public class SunBot : IBot
{
    public bool Enabled { get; set; }
    public string Message { get; set; }
    public int TemperatureThreshold { get; set; }

    public void PrintActivateMessage()
    {
        Console.WriteLine(Message);
    }
}