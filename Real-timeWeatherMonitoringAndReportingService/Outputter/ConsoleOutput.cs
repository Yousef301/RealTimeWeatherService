namespace Real_timeWeatherMonitoringAndReportingService.Outputter;

public abstract class ConsoleOutput
{
    public static void BotActivatedMessage(string botName, string message)
    {
        Console.WriteLine($"{botName} activated!");
        Console.WriteLine($"{botName}: {message}");
    }

    public static void MessageOutput(string message)
    {
        Console.WriteLine(message);
    }
}