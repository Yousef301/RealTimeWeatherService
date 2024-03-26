using Microsoft.Extensions.Configuration;

namespace Real_timeWeatherMonitoringAndReportingService.Helpers;

public class AppSettingsManager
{
    private static readonly IConfiguration _configuration = new ConfigurationBuilder()
        .AddJsonFile(
            "C:\\Users\\shama\\RiderProjects\\Real-timeWeatherMonitoringAndReportingService\\Real-timeWeatherMonitoringAndReportingService\\Configuration\\AppSettings.json",
            optional: true, reloadOnChange: true).Build();

    public static string GetValue(string key)
    {
        return _configuration[key];
    }
}