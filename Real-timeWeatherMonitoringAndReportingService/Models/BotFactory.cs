namespace Real_timeWeatherMonitoringAndReportingService.Models;

public class BotFactory
{
    public IBot CreateBot(string type, bool enabled, int temperatureThreshold, int humidityThreshold, string message)
    {
        switch (type.ToUpper())
        {
            case "SNOWBOT":
                return new SnowBot()
                    { Enabled = enabled, Message = message, TemperatureThreshold = temperatureThreshold };
            case "SUNBOT":
                return new SunBot()
                    { Enabled = enabled, Message = message, TemperatureThreshold = temperatureThreshold };
                ;
            case "RAINBOT":
                return new RainBot()
                    { Enabled = enabled, Message = message, HumidityThreshold = temperatureThreshold };
                ;
            default:
                throw new ArgumentException($"{type} isn't available yet...");
        }
    }
}