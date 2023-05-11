using AirVelocitySensor.Models;

namespace AirVelocitySensor;

public class MeasurementCollector
{
    private readonly IAirSensor _airSensor;
    private readonly IAirVelocityAnalyzer _airVelocityAnalyzer;
    private readonly IDelayDeterminant _delayDeterminant;
    
    public MeasurementCollector( IAirSensor airSensor,
        IAirVelocityAnalyzer airVelocityAnalyzer,
        IDelayDeterminant delayDeterminant )
    {
        _airSensor = airSensor;
        _airVelocityAnalyzer = airVelocityAnalyzer;
        _delayDeterminant = delayDeterminant;
    }

    public async Task Collect( CancellationToken cancellationToken )
    {
        while ( true )
        {
            if ( cancellationToken.IsCancellationRequested )
            {
                return;
            }

            AirMeasurements measurement = _airSensor.GetMeasurements();
            AirVelocityType airVelocityType = _airVelocityAnalyzer.Analyze( measurement );
            TimeSpan delay = _delayDeterminant.GetDelay( airVelocityType );

            await Task.Delay( delay, cancellationToken );
        }
    }
}