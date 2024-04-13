using FluentAssertions;
using Moq;
using Real_timeWeatherMonitoringAndReportingService.Interfaces;
using Real_timeWeatherMonitoringAndReportingService.Models.Bots;
using Real_timeWeatherMonitoringAndReportingService.Models.Configurations;

namespace Real_timeWeatherMonitoringAndReportingService.Tests;

public class RealTimeWeatherServicesBotTests
{
    private readonly BotFactory _botFactory;
    private readonly BotConfig _botConfig;

    public RealTimeWeatherServicesBotTests()
    {
        _botConfig = new BotConfig();
        _botFactory = new BotFactory();
    }

    [Theory]
    [InlineData("SNOWBOT", typeof(SnowWeatherBot))]
    [InlineData("SUNBOT", typeof(SunWeatherBot))]
    [InlineData("RAINBOT", typeof(RainWeatherBot))]
    public void CreateBot_ReturnBotIfExists(string botType, Type expectedBotType)
    {
        // Arrange
        var botConfiguration = new KeyValuePair<string, BotConfig>
            (botType, _botConfig);

        // Act
        var bot = _botFactory.CreateBot(botConfiguration);

        // Assert
        bot.Should().BeOfType(expectedBotType);
    }

    [Fact]
    public void CreateBot_WithInvalidConfig_ThrowsArgumentException()
    {
        // Arrange
        var botConfiguration = new KeyValuePair<string, BotConfig>("INVALID", _botConfig);

        // Act
        var act = () => _botFactory.CreateBot(botConfiguration);

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("INVALID isn't available yet...");
    }

    [Fact]
    public void ActivateBot_Activates_Bot()
    {
        // Arrange
        var thresholds = new Dictionary<string, int>
        {
            { "Temperature", 30 },
            { "Humidity", 60 }
        };

        var values = new Dictionary<string, double>
        {
            { "Temperature", 35.0 },
            { "Humidity", 70.0 }
        };

        var mockBot = new Mock<IWeatherBot>();
        var botServices = new TestBotServices();

        // Act
        var result = botServices.ActivateBot(thresholds, values, mockBot.Object);

        // Assert
        result.Should().BeTrue();
        mockBot.VerifySet(x => x.Activated = true);
    }

    [Fact]
    public void ActivateBot_Throws_Exception_When_No_Threshold()
    {
        // Arrange
        var thresholds = new Dictionary<string, int>
        {
            { "Temperature", 30 }
        };

        var values = new Dictionary<string, double>
        {
            { "Temperature", 35.0 },
            { "Humidity", 70.0 }
        };

        var mockBot = new Mock<IWeatherBot>();
        var botServices = new TestBotServices();

        // Act 
        var act = () => botServices.ActivateBot(thresholds, values, mockBot.Object);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("No threshold defined for Humidity");
    }
}