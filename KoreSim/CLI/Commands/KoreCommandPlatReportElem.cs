using System.Collections.Generic;

// KoreCommandVersion

public class KoreCommandPlatReportElem : KoreCommand
{
    public KoreCommandPlatReportElem()
    {
        Signature.Add("plat");
        Signature.Add("report");
        Signature.Add("elem");
    }

    public override string Execute(List<string> parameters)
    {
        int num = EventDriver.NumPlatforms();
        string rep = EventDriver.PlatformElementsReport();

        KoreCentralLog.AddEntry("PlatformElementsReport.Execute: " + KoreGlobals.VersionString);
        return $"Platform Elements Report:\n{rep}";
    }
}
