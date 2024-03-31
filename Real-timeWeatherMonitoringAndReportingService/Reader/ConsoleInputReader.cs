namespace Real_timeWeatherMonitoringAndReportingService.Reader;

public abstract class ConsoleInputReader
{
    public static string? ReadInput()
    {
        return Console.ReadLine();
    }
}