using Real_timeWeatherMonitoringAndReportingService.Interfaces;

namespace Real_timeWeatherMonitoringAndReportingService.Services;

public class SnowBotService : BotServices
{
    public override bool ActivateBot(Dictionary<string, int> thresholds, Dictionary<string, double> values,
        IWeatherBot bot)
    {
        foreach (var kvp in values)
        {
            if (!thresholds.ContainsKey(kvp.Key))
            {
                throw new ArgumentException($"No threshold defined for {kvp.Key}");
            }

            if (kvp.Value >= thresholds[kvp.Key])
            {
                bot.Activated = false;
                return false;
            }
        }

        bot.Activated = true;
        return true;
    }
}