using System.Collections.Generic;

// KoreCommandPlatCourseDelta

public class KoreCommandPlatCourseDelta : KoreCommand
{
    public KoreCommandPlatCourseDelta()
    {
        Signature.Add("plat");
        Signature.Add("coursedelta");
    }

    public override string HelpString => $"{SignatureString} <platform_name> <speedChangeMpMps> <headingChangeClockwiseDegsSec>";

    public override string Execute(List<string> parameters)
    {
        if (parameters.Count < 3)
        {
            return "KoreCommandPlatCourseDelta.Execute -> insufficient parameters";
        }

        string platName    = parameters[0];
        double speedChangeMpMps              = double.Parse(parameters[1]);
        double headingChangeClockwiseDegsSec = double.Parse(parameters[2]);

        string retString = "";

        if (EventDriver.DoesPlatformExist(platName))
        {
            KoreCourseDelta newCourseDelta = new KoreCourseDelta() {
                    SpeedChangeMpMps = speedChangeMpMps,
                    HeadingChangeClockwiseDegsSec = headingChangeClockwiseDegsSec };

            EventDriver.SetPlatformCourseDelta(platName, newCourseDelta);
            retString = $"Platform {platName} Updated: Course: {newCourseDelta}.";
        }
        else
        {
            retString = $"Platform {platName} not found.";
        }

        KoreCentralLog.AddEntry($"KoreCommandPlatCourseDelta.Execute -> {retString}");
        return retString;
    }
}
