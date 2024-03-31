using Real_timeWeatherMonitoringAndReportingService.Interfaces;
using Real_timeWeatherMonitoringAndReportingService.Models.Configurations;
using Real_timeWeatherMonitoringAndReportingService.Services;

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
                    Activated = botConfiguration.Value.Activated,
                    Message = botConfiguration.Value.Message,
                    TemperatureThreshold = botConfiguration.Value.TemperatureThreshold,
                    BotService = new SnowBotService()
                };
            case "SUNBOT":
                return new SunWeatherBot()
                {
                    Activated = botConfiguration.Value.Activated,
                    Message = botConfiguration.Value.Message,
                    TemperatureThreshold = botConfiguration.Value.TemperatureThreshold,
                    BotService = new SunBotService()
                };
            case "RAINBOT":
                return new RainWeatherBot()
                {
                    Activated = botConfiguration.Value.Activated,
                    Message = botConfiguration.Value.Message,
                    HumidityThreshold = botConfiguration.Value.HumidityThreshold,
                    BotService = new RainBotService()
                };
            default:
                throw new ArgumentException($"{botConfiguration.Key} isn't available yet...");
        }
    }
}