using Real_timeWeatherMonitoringAndReportingService.Interfaces;

namespace Real_timeWeatherMonitoringAndReportingService.Models.Weather;

public class WeatherStation : WeatherData, IObservable
{
    private List<IWeatherBot> _bots = new List<IWeatherBot>();

    public WeatherStation(List<IWeatherBot> bots)
    {
        foreach (var bot in bots)
        {
            Add(bot);
        }
    }

    public void Add(IWeatherBot bot)
    {
        bot.WeatherStation = this;
        _bots.Add(bot);
    }

    public void Remove(IWeatherBot bot)
    {
        _bots.Remove(bot);
        bot.WeatherStation = null;
    }

    public void Notify(WeatherData newWeatherData)
    {
        Temperature = newWeatherData.Temperature;
        Humidity = newWeatherData.Humidity;
        Location = newWeatherData.Location;

        foreach (var bot in _bots)
        {
            bot.Update();
        }
    }
}