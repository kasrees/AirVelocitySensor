using AirVelocitySensor.Models;

namespace AirVelocitySensor;

public interface IDelayDeterminant
{
    TimeSpan GetDelay( AirVelocityType airVelocityType );
}

public class DelayDeterminant : IDelayDeterminant
{
    private const int HourInSeconds = 3600;
    
    public TimeSpan GetDelay( AirVelocityType airVelocityType )
    {
        return airVelocityType switch
        {
            AirVelocityType.Low => TimeSpan.FromSeconds( HourInSeconds * 0.25 ),
            AirVelocityType.Medium => TimeSpan.FromSeconds( HourInSeconds * 0.17 ),
            AirVelocityType.High => TimeSpan.FromSeconds( HourInSeconds * 0.08 ),
            AirVelocityType.Critical => TimeSpan.FromSeconds( HourInSeconds * 0.01 ),
            _ => throw new ArgumentOutOfRangeException( nameof( airVelocityType ), airVelocityType, null )
        };
    }
}