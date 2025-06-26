using System.Collections.Generic;

// KoreCommandSimStop

public class KoreCommandSimStart : KoreCommand
{
    public KoreCommandSimStart()
    {
        Signature.Add("sim");
        Signature.Add("start");
    }

    public override string Execute(List<string> parameters)
    {
        KoreCentralLog.AddEntry("KoreCommandSimStart.Execute");

        KoreSimFactory.Instance.ModelRun.Start();

        return "Simulation started";
    }
}