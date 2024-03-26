using Real_timeWeatherMonitoringAndReportingService.Configuration;
using Real_timeWeatherMonitoringAndReportingService.Models;
using Real_timeWeatherMonitoringAndReportingService.Services;

namespace Real_timeWeatherMonitoringAndReportingService.Presntation;

public class Test
{
    private static readonly Dictionary<string, IWeatherBot> _bots = BotsConfiguration.LoadConfigurations();

    public static void Run()
    {
        string userInput;

        WeatherStation weatherStation = new WeatherStation();

        WeatherStationService.InitializeObservers(weatherStation, _bots);
        do
        {
            Console.WriteLine("Enter weather data:");
            userInput = Console.ReadLine();
            Console.Clear();

            var type = Helpers.IdentifyFormat.GetDataFormat(userInput);

            var deserializerFactory = new WeatherDeserializerFactory();
            var weatherDeserializer = deserializerFactory.CreateDeserializer(type);


            if (weatherDeserializer is not null)
            {
                WeatherStation tempWeatherStation = weatherDeserializer.DeserializeWeatherInfo(userInput);

                UpdateWeatherStation(weatherStation, tempWeatherStation);

                foreach (var bot in _bots.Values)
                {
                    bot.WeatherStation = weatherStation;
                }

                weatherStation.Notify();
            }

            Console.WriteLine();
        } while (!userInput.Equals("q"));
    }

    private static void UpdateWeatherStation(WeatherStation weatherStation, WeatherStation newWeatherData)
    {
        weatherStation.Temperature = newWeatherData.Temperature;
        weatherStation.Humidity = newWeatherData.Humidity;
        weatherStation.Location = newWeatherData.Location;
    }
}