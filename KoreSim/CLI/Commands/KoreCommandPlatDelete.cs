using System.Collections.Generic;

// KoreCommandPlatDelete

public class KoreCommandPlatDelete : KoreCommand
{

    public KoreCommandPlatDelete()
    {
        Signature.Add("plat");
        Signature.Add("del");
    }

    public override string HelpString => $"{SignatureString} <platform_name>";

    public override string Execute(List<string> parameters)
    {
        if (parameters.Count < 1)
        {
            return "KoreCommandPlatDelete.Execute -> insufficient parameters";
        }

        string platName = parameters[0];
        string retString = "";

        // Delete the platform
        if (EventDriver.DoesPlatformExist(platName))
        {
            EventDriver.DeletePlatform(platName);
            retString = $"Platform {platName} deleted.";
        }
        else
        {
            retString = $"Platform {platName} not found.";
        }

        KoreCentralLog.AddEntry($"KoreCommandPlatDelete.Execute -> {retString}");
        return retString;
    }
}
