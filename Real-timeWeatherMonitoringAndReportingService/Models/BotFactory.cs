namespace Real_timeWeatherMonitoringAndReportingService.Models;

public class BotFactory
{
    public IWeatherBot CreateBot(string type, bool enabled, int temperatureThreshold, int humidityThreshold,
        string message)
    {
        switch (type.ToUpper())
        {
            case "SNOWBOT":
                return new SnowWeatherBot()
                    { Enabled = enabled, Message = message, TemperatureThreshold = temperatureThreshold };
            case "SUNBOT":
                return new SunWeatherBot()
                    { Enabled = enabled, Message = message, TemperatureThreshold = temperatureThreshold };
                ;
            case "RAINBOT":
                return new RainWeatherBot()
                    { Enabled = enabled, Message = message, HumidityThreshold = humidityThreshold };
                ;
            default:
                throw new ArgumentException($"{type} isn't available yet...");
        }
    }
}