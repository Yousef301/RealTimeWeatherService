namespace Real_timeWeatherMonitoringAndReportingService.Services;

public abstract class BotServices
{
    public virtual bool ActivateBot(Dictionary<string, int> thresholds, Dictionary<string, double> values,
        string botType)
    {
        foreach (var kvp in values)
        {
            if (!thresholds.ContainsKey(kvp.Key))
            {
                throw new ArgumentException($"No threshold defined for {kvp.Key}");
            }

            if (kvp.Value <= thresholds[kvp.Key])
            {
                return false;
            }
        }

        return true;
    }
}