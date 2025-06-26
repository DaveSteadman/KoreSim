using System.Collections.Generic;

// KoreCommandPlatDelete

public class KoreCommandPlatDeleteAllEmitters : KoreCommand
{
    public KoreCommandPlatDeleteAllEmitters()
    {
        Signature.Add("plat");
        Signature.Add("delallemitters");
    }

    // public override string HelpString => $"{SignatureString} <platform_name>";

    public override string Execute(List<string> parameters)
    {
        if (parameters.Count < 0)
        {
            return "KoreCommandPlatDeleteAllEmitters.Execute -> incorrect number of parameters";
        }

        KoreSimFactory.Instance.EventDriver.DeleteElementAllBeams();

        KoreCentralLog.AddEntry($"KoreCommandPlatDeleteAllEmitters.Execute");

        string retString = "Done.";
        return retString;
    }
}
