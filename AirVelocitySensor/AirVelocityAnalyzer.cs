using AirVelocitySensor.Models;

namespace AirVelocitySensor;

public interface IAirVelocityAnalyzer
{
    AirVelocityType Analyze( AirMeasurements measurements );
}

public class AirVelocityAnalyzer : IAirVelocityAnalyzer
{
    public AirVelocityType Analyze( AirMeasurements measurements )
    {
        return measurements.AirVelocity switch
        {
            < 11 => AirVelocityType.Low,
            < 38 => AirVelocityType.Medium,
            < 74 => AirVelocityType.High,
            _ => AirVelocityType.Critical
        };
    }
}