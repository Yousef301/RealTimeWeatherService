using System.Reflection;
using FluentAssertions;
using Real_timeWeatherMonitoringAndReportingService.Models.Weather;

namespace Real_timeWeatherMonitoringAndReportingService.Tests;

public class InputDeserializationTests
{
    [Theory]
    [InlineData("{\"Temperature\":25.5,\"Humidity\":60.0}")]
    [InlineData("<WeatherData><Temperature>25.5</Temperature><Humidity>60.0</Humidity></WeatherData>")]
    public void TryDeserializeInput_ValidInput_ShouldDeserialize(string userInput)
    {
        // Arrange
        var programType = typeof(Program);
        var methodInfo = programType.GetMethod("TryDeserializeInput", BindingFlags.NonPublic | BindingFlags.Static);
        var programInstance = Activator.CreateInstance(programType);

        // Act
        var result = methodInfo.Invoke(programInstance, new object[] { userInput });

        // Assert
        result.Should().BeOfType<WeatherData>();
    }


    [Fact]
    public void TryDeserializeInput_InvalidInput_ShouldReturnNull()
    {
        // Arrange
        var programType = typeof(Program);
        var methodInfo = programType.GetMethod("TryDeserializeInput", BindingFlags.NonPublic | BindingFlags.Static);
        var programInstance = Activator.CreateInstance(programType);

        // Act
        var result = methodInfo.Invoke(programInstance, new object[] { "Invalid input" });

        // Assert
        result.Should().BeNull();
    }
}