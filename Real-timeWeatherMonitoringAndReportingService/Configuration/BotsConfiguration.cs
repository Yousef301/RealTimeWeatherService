using Newtonsoft.Json;
using Real_timeWeatherMonitoringAndReportingService.Helpers;
using Real_timeWeatherMonitoringAndReportingService.Models;

namespace Real_timeWeatherMonitoringAndReportingService.Configuration;

public class BotsConfiguration
{
    public static Dictionary<string, IBot> LoadConfigurations()
    {
        Dictionary<string, IBot> bots = new Dictionary<string, IBot>();

        string botsConfigurations =
            File.ReadAllText(AppSettingsManager.GetValue("BotsConfiguration"));
        var configDict = JsonConvert.DeserializeObject<Dictionary<string, BotConfig>>(botsConfigurations);

        foreach (var kvp in configDict)
        {
            var botFactory = new BotFactory();
            IBot bot;
            switch (kvp.Key)
            {
                case "RainBot":
                    bot = botFactory.CreateBot(message: kvp.Value.Message,
                        temperatureThreshold: kvp.Value.TemperatureThreshold,
                        humidityThreshold: kvp.Value.HumidityThreshold, enabled: kvp.Value.Enabled, type: kvp.Key);
                    bots[kvp.Key] = bot;
                    break;
                case "SunBot":
                    bot = botFactory.CreateBot(message: kvp.Value.Message,
                        temperatureThreshold: kvp.Value.TemperatureThreshold,
                        humidityThreshold: kvp.Value.HumidityThreshold, enabled: kvp.Value.Enabled, type: kvp.Key);
                    bots[kvp.Key] = bot;
                    break;
                case "SnowBot":
                    bot = botFactory.CreateBot(message: kvp.Value.Message,
                        temperatureThreshold: kvp.Value.TemperatureThreshold,
                        humidityThreshold: kvp.Value.HumidityThreshold, enabled: kvp.Value.Enabled, type: kvp.Key);
                    bots[kvp.Key] = bot;
                    break;
                default:
                    throw new Exception($"Unknown bot type: {kvp.Key}");
            }
        }

        return bots;
    }
}