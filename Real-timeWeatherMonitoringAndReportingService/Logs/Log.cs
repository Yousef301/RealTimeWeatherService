namespace Real_timeWeatherMonitoringAndReportingService.Logs;

public class Log
{
    public static void BotActivatedMessage(string botName, string message)
    {
        Console.WriteLine($"{botName} activated!");
        Console.WriteLine($"{botName}: {message}");
    }
}