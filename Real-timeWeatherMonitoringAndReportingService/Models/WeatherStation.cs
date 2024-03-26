using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Real_timeWeatherMonitoringAndReportingService.Models;

[XmlRoot("WeatherData")]
public class WeatherStation : IObservable
{
    private List<IWeatherBot> Bots = new List<IWeatherBot>();

    [Required(ErrorMessage = "Temperature Threshold is required.")]
    [StringLength(40, MinimumLength = 5, ErrorMessage = "Message length must be between 5 and 40 characters.")]
    public string Location { get; set; }

    [Required(ErrorMessage = "Temperature is required.")]
    [Range(-100.0, 100.0, ErrorMessage = "Temperature must be in range of -100 to 100.")]
    public double Temperature { get; set; }

    [Required(ErrorMessage = "Humidity is required.")]
    [Range(-100.0, 100.0, ErrorMessage = "Humidity must be in range of -100 to 100.")]
    public double Humidity { get; set; }

    public override string ToString()
    {
        return $"Location -> {Location}\nTemperature -> {Temperature}\nHumidity -> {Humidity}";
    }

    public void Add(IWeatherBot bot)
    {
        Bots.Add(bot);
    }

    public void Remove(IWeatherBot bot)
    {
        Bots.Remove(bot);
    }

    public void Notify()
    {
        foreach (var bot in Bots)
        {
            bot.Update();
        }
    }

    public void UpdateWeatherStation(WeatherStation newWeatherData)
    {
        Temperature = newWeatherData.Temperature;
        Humidity = newWeatherData.Humidity;
        Location = newWeatherData.Location;
    }
}