using AirVelocitySensor.Models;
using MicricontrollerAdapters;

namespace AirVelocitySensor;

public interface IAirSensor
{
    AirMeasurements GetMeasurements();
}

public class AirSensor : IAirSensor
{
    public AirMeasurements GetMeasurements()
    {
        int output = MicricontrollerAdapter.GetOutput("FDA03EC3-DA78-4870-B652-B065FFE3669C");
        
        return new AirMeasurements
        {
            AirVelocity = output
        };
    }
}