using System.Collections.Generic;

// KoreCommandPlatDelete

public class KoreCommandPlatPosition : KoreCommand
{
    public KoreCommandPlatPosition()
    {
        Signature.Add("plat");
        Signature.Add("pos");
    }

    public override string HelpString => $"{SignatureString} <platform_name> <LatDegs> <LonDegs> <AltMslM>";

    public override string Execute(List<string> parameters)
    {
        if (parameters.Count < 4)
        {
            return "KoreCommandPlatPosition.Execute -> insufficient parameters";
        }

        string platName = parameters[0];
        double latDegs = double.Parse(parameters[1]);
        double lonDegs = double.Parse(parameters[2]);
        double altMslM = double.Parse(parameters[3]);

        string retString = "";

        if (KoreSimFactory.Instance.EventDriver.DoesPlatformExist(platName))
        {
            KoreLLAPoint newLLA = new KoreLLAPoint() { LatDegs = latDegs, LonDegs = lonDegs, AltMslM = altMslM };

            KoreSimFactory.Instance.EventDriver.SetPlatformStartLLA(platName, newLLA);
            retString = $"Platform {platName} Updated: Position: {newLLA}.";
        }
        else
        {
            retString = $"Platform {platName} not found.";
        }

        KoreCentralLog.AddEntry($"KoreCommandPlatPosition.Execute -> {retString}");
        return retString;
    }
}
