using System.Reflection;
using FluentAssertions;
using Real_timeWeatherMonitoringAndReportingService.Models.Weather;

namespace Real_timeWeatherMonitoringAndReportingService.Tests;

public class InputDeserializationTests
{
    private readonly MethodInfo? _tryDeserializeInputMethod;
    private readonly object? _programInstance;
    
    public InputDeserializationTests()
    {
        var programType = typeof(Program);
        _tryDeserializeInputMethod = programType.GetMethod("TryDeserializeInput", BindingFlags.NonPublic | BindingFlags.Static);
        _programInstance = Activator.CreateInstance(programType);
    }

    [Theory]
    [InlineData("{\"Temperature\":25.5,\"Humidity\":60.0}")]
    [InlineData("<WeatherData><Temperature>25.5</Temperature><Humidity>60.0</Humidity></WeatherData>")]
    public void TryDeserializeInput_ValidInput_ShouldDeserialize(string userInput)
    {
        // Act
        var result = _tryDeserializeInputMethod?.Invoke(_programInstance, new object[] { userInput });

        // Assert
        result.Should().BeOfType<WeatherData>();
    }


    [Fact]
    public void TryDeserializeInput_InvalidInput_ShouldReturnNull()
    {
        // Act
        var result = _tryDeserializeInputMethod?.Invoke(_programInstance, new object[] { "Invalid input" });

        // Assert
        result.Should().BeNull();
    }
}