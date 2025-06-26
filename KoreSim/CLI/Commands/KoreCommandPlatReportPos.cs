using System.Collections.Generic;

// KoreCommandVersion

public class KoreCommandPlatReportPos : KoreCommand
{
    public KoreCommandPlatReportPos()
    {
        Signature.Add("plat");
        Signature.Add("report");
        Signature.Add("pos");
    }

    public override string Execute(List<string> parameters)
    {
        int num = KoreSimFactory.Instance.EventDriver.NumPlatforms();
        string rep = KoreSimFactory.Instance.EventDriver.PlatformPositionsReport();

        KoreCentralLog.AddEntry("KoreCommandPlatReport.Execute: " + KoreGlobals.VersionString);
        return $"Platform Positions Report:\n{rep}";
    }
}
