using Newtonsoft.Json;
using Real_timeWeatherMonitoringAndReportingService.Helpers;
using Real_timeWeatherMonitoringAndReportingService.Models;

namespace Real_timeWeatherMonitoringAndReportingService.Configuration;

public class BotsConfiguration
{
    private static readonly BotFactory _botFactory = new BotFactory();

    public static Dictionary<string, IWeatherBot> LoadConfigurations()
    {
        var bots = new Dictionary<string, IWeatherBot>();

        var botsConfiguration = GetBotsConfiguration();

        foreach (var botConfig in botsConfiguration)
        {
            if (botConfig.Value.Enabled)
                bots[botConfig.Key] = _botFactory.CreateBot(botConfig);
        }

        return bots;
    }

    private static Dictionary<string, BotConfig>? GetBotsConfiguration()
    {
        var botsConfigurations =
            File.ReadAllText(AppSettingsManager.GetValue("BotsConfiguration"));
        return JsonConvert.DeserializeObject<Dictionary<string, BotConfig>>(botsConfigurations);
    }
}