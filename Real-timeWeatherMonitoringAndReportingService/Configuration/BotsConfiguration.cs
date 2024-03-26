using Newtonsoft.Json;
using Real_timeWeatherMonitoringAndReportingService.Helpers;
using Real_timeWeatherMonitoringAndReportingService.Models;

namespace Real_timeWeatherMonitoringAndReportingService.Configuration;

public class BotsConfiguration
{
    public static Dictionary<string, IWeatherBot> LoadConfigurations()
    {
        Dictionary<string, IWeatherBot> bots = new Dictionary<string, IWeatherBot>();

        string botsConfigurations =
            File.ReadAllText(AppSettingsManager.GetValue("BotsConfiguration"));
        var configDict = JsonConvert.DeserializeObject<Dictionary<string, BotConfig>>(botsConfigurations);

        foreach (var kvp in configDict)
        {
            var botFactory = new BotFactory();
            IWeatherBot weatherBot;
            switch (kvp.Key)
            {
                case "RainBot":
                    weatherBot = botFactory.CreateBot(message: kvp.Value.Message,
                        temperatureThreshold: kvp.Value.TemperatureThreshold,
                        humidityThreshold: kvp.Value.HumidityThreshold, enabled: kvp.Value.Enabled, type: kvp.Key);
                    bots[kvp.Key] = weatherBot;
                    break;
                case "SunBot":
                    weatherBot = botFactory.CreateBot(message: kvp.Value.Message,
                        temperatureThreshold: kvp.Value.TemperatureThreshold,
                        humidityThreshold: kvp.Value.HumidityThreshold, enabled: kvp.Value.Enabled, type: kvp.Key);
                    bots[kvp.Key] = weatherBot;
                    break;
                case "SnowBot":
                    weatherBot = botFactory.CreateBot(message: kvp.Value.Message,
                        temperatureThreshold: kvp.Value.TemperatureThreshold,
                        humidityThreshold: kvp.Value.HumidityThreshold, enabled: kvp.Value.Enabled, type: kvp.Key);
                    bots[kvp.Key] = weatherBot;
                    break;
                default:
                    throw new ArgumentException($"{kvp.Key} isn't available yet...");
            }
        }

        return bots;
    }
}