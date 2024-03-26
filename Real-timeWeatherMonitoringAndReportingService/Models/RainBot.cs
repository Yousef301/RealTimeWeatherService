namespace Real_timeWeatherMonitoringAndReportingService.Models;

public class RainBot : IBot
{
    public bool Enabled { get; set; }
    public string Message { get; set; }
    public int HumidityThreshold { get; set; }

    public void PrintActivateMessage()
    {
        Console.WriteLine(Message);
    }
}