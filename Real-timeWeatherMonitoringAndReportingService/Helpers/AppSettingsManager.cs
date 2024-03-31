using Microsoft.Extensions.Configuration;
using System.IO;

namespace Real_timeWeatherMonitoringAndReportingService.Helpers
{
    public class AppSettingsManager
    {
        private static readonly IConfiguration _configuration;

        static AppSettingsManager()
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            while (!Directory.Exists(Path.Combine(currentDirectory, "Configuration")))
            {
                currentDirectory = Directory.GetParent(currentDirectory)?.FullName;
                if (currentDirectory == null)
                {
                    throw new DirectoryNotFoundException("Could not find the project directory.");
                }
            }

            var builder = new ConfigurationBuilder()
                .SetBasePath(currentDirectory)
                .AddJsonFile("Configuration/AppSettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();
        }

        public static string? GetValue(string key)
        {
            return _configuration[key];
        }
    }
}