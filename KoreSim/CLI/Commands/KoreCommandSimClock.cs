using System.Collections.Generic;

// KoreCommandSimClock

public class KoreCommandSimClock : KoreCommand
{
    public KoreCommandSimClock()
    {
        Signature.Add("sim");
        Signature.Add("clock");
    }

    public override string Execute(List<string> parameters)
    {
        return $"SimClock: {KoreSimFactory.Instance.EventDriver.SimSeconds()}Secs";
    }
}
