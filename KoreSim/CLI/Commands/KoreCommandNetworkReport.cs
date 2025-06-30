using System.Collections.Generic;

// KoreCommandNetworkReport

public class KoreCommandNetworkReport : KoreCommand
{
    public KoreCommandNetworkReport()
    {
        Signature.Add("network");
        Signature.Add("report");
    }

    public override string Execute(List<string> parameters)
    {
        KoreCentralLog.AddEntry("KoreCommandNetworkReport.Execute");

        return EventDriver.NetworkReport();
    }
}