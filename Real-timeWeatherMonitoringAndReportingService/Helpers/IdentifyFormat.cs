using System.Text.Json;
using System.Xml.Linq;
using Real_timeWeatherMonitoringAndReportingService.Enums;


namespace Real_timeWeatherMonitoringAndReportingService.Helpers;

public class IdentifyFormat
{
    public static DataFormat GetDataFormat(string rawString)
    {
        try
        {
            JsonDocument.Parse(rawString);
            return DataFormat.Json;
        }
        catch (JsonException)
        {
        }

        try
        {
            XDocument.Parse(rawString);
            return DataFormat.Xml;
        }
        catch (Exception)
        {
            // ignored
        }

        return DataFormat.Unknown;
    }
}