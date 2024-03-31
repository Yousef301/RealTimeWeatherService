using Real_timeWeatherMonitoringAndReportingService.Configuration;
using Real_timeWeatherMonitoringAndReportingService.Deserializers;
using Real_timeWeatherMonitoringAndReportingService.Interfaces;
using Real_timeWeatherMonitoringAndReportingService.Models.Weather;
using Real_timeWeatherMonitoringAndReportingService.Outputter;
using Real_timeWeatherMonitoringAndReportingService.Reader;

namespace Real_timeWeatherMonitoringAndReportingService;

public class Program
{
    private static readonly Dictionary<string, IWeatherBot> _bots = BotsConfiguration.LoadConfigurations();

    static void Main(string[] args)
    {
        string? userInput;

        var weatherStation = new WeatherStation(_bots.Values.ToList());

        do
        {
            ConsoleOutput.DisplayMessage("Enter weather data:");
            userInput = ConsoleInputReader.ReadInput();
            Console.Clear();

            var weatherData = TryDeserializeInput(userInput);

            if (weatherData is not null)
            {
                weatherStation.Notify(weatherData);
            }
            else
                ConsoleOutput.DisplayMessage("Invalid data format.");

            ConsoleOutput.DisplayMessage("");
        } while (!userInput.Equals("q"));
    }

    private static WeatherData? TryDeserializeInput(string userInput)
    {
        var deserializers = new List<IRawDataDeserializer<WeatherData>>()
        {
            new JsonRawDataDeserializer<WeatherData>(),
            new XmlRawDataDeserializer<WeatherData>()
        };

        return deserializers.Select(deserializer => deserializer.TryDeserializeWeatherInfo(userInput))
            .OfType<WeatherData>().FirstOrDefault();
    }
}