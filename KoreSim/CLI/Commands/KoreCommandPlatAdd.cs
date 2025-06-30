using System.Collections.Generic;

// KoreCommandPlatAdd

public class KoreCommandPlatAdd : KoreCommand
{
    public KoreCommandPlatAdd()
    {
        Signature.Add("plat");
        Signature.Add("add");
    }

    public override string HelpString => $"{SignatureString} <platform_name>";

    public override string Execute(List<string> parameters)
    {
        if (parameters.Count < 1)
        {
            return "KoreCommandPlatAdd.Execute -> insufficient parameters";
        }

        string platName = parameters[0];
        string retString = "";

        // Commands exist to perform their task, delete any pre-existing platform by the name
        if (EventDriver.DoesPlatformExist(platName))
        {
            EventDriver.DeletePlatform(platName);
            retString += $"Platform {platName} deleted. ";
        }

        EventDriver.AddPlatform(platName);
        retString += $"Platform {platName} added.";

        // Set the default platform details - adding it with no location will create rendering div0's etc.
        EventDriver.DefaultPlatformDetails(platName);

        KoreCentralLog.AddEntry($"KoreCommandPlatAdd.Execute -> {retString}");
        return retString;
    }
}
