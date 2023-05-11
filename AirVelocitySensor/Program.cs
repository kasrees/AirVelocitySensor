namespace AirVelocitySensor;

internal static class Program
{
    public static async Task Main( string[] args )
    {
        MeasurementCollector measurementCollector = BuildMeasurementCollector();
        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

        await measurementCollector.Collect( cancelTokenSource.Token );
    }

    private static MeasurementCollector BuildMeasurementCollector()
    {
        IAirSensor airSensor = new AirSensor();
        IAirVelocityAnalyzer airVelocityAnalyzer = new AirVelocityAnalyzer();
        IDelayDeterminant delayDeterminant = new DelayDeterminant();

        return new MeasurementCollector( airSensor, airVelocityAnalyzer, delayDeterminant );
    }
}