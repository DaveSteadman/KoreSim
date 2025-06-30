using System.Collections.Generic;

// KoreCommandSimReset

public class KoreCommandSimReset : KoreCommand
{
    public KoreCommandSimReset()
    {
        Signature.Add("sim");
        Signature.Add("reset");
    }

    public override string Execute(List<string> parameters)
    {
        KoreCentralLog.AddEntry("KoreCommandSimReset.Execute");

        KoreSimFactory.Instance.PlatformManager.Reset(); // EventDriver this
        EventDriver.SimClockReset();

        return "PlatformManager Reset (platform positions to start)";
    }
}
