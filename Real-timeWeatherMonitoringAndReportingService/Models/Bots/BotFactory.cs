using Real_timeWeatherMonitoringAndReportingService.Interfaces;
using Real_timeWeatherMonitoringAndReportingService.Models.Configurations;

namespace Real_timeWeatherMonitoringAndReportingService.Models.Bots;

public class BotFactory
{
    public IWeatherBot CreateBot(KeyValuePair<string, BotConfig> botConfiguration)
    {
        switch (botConfiguration.Key.ToUpper())
        {
            case "SNOWBOT":
                return new SnowWeatherBot()
                {
                    Message = botConfiguration.Value.Message,
                    TemperatureThreshold = botConfiguration.Value.TemperatureThreshold
                };
            case "SUNBOT":
                return new SunWeatherBot()
                {
                    Message = botConfiguration.Value.Message,
                    TemperatureThreshold = botConfiguration.Value.TemperatureThreshold
                };
            case "RAINBOT":
                return new RainWeatherBot()
                {
                    Message = botConfiguration.Value.Message,
                    HumidityThreshold = botConfiguration.Value.HumidityThreshold
                };
            default:
                throw new ArgumentException($"{botConfiguration.Key} isn't available yet...");
        }
    }
}