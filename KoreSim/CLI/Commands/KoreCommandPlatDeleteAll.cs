using System.Collections.Generic;

// KoreCommandPlatDelete

public class KoreCommandPlatDeleteAll : KoreCommand
{
    public KoreCommandPlatDeleteAll()
    {
        Signature.Add("plat");
        Signature.Add("delall");
    }

    public override string HelpString => $"{SignatureString} <platform_name>";

    public override string Execute(List<string> parameters)
    {
        if (parameters.Count < 0)
        {
            return "KoreCommandPlatDeleteAll.Execute -> incorrect number of parameters";
        }

        KoreSimFactory.Instance.EventDriver.DeleteAllPlatforms();

        KoreCentralLog.AddEntry($"KoreCommandPlatDeleteAll.Execute");

        string retString = "Done.";
        return retString;
    }
}
