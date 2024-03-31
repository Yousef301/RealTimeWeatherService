namespace Real_timeWeatherMonitoringAndReportingService.Outputter;

public abstract class ConsoleOutput
{
    public static void DisplayBotActivationMessage(string botName, string message)
    {
        Console.WriteLine($"{botName} activated!");
        Console.WriteLine($"{botName}: {message}");
    }

    public static void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
}