using AirVelocitySensor.Models;

namespace AirVelocitySensor;

public interface IAirSensor
{
    AirMeasurements GetMeasurements();
}

public class AirSensor : IAirSensor
{
    public AirMeasurements GetMeasurements()
    {
        return new AirMeasurements
        {
            AirVelocity = 15
        };
    }
}