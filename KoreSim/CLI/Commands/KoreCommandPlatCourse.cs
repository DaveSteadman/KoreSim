using System.Collections.Generic;

// KoreCommandPlatDelete

public class KoreCommandPlatCourse : KoreCommand
{
    public KoreCommandPlatCourse()
    {
        Signature.Add("plat");
        Signature.Add("course");
    }

    public override string HelpString => $"{SignatureString} <platform_name> <HeadingDegs> <SpeedKph>";

    public override string Execute(List<string> parameters)
    {
        if (parameters.Count < 3)
        {
            return "KoreCommandPlatCourse.Execute -> insufficient parameters";
        }

        string platName    = parameters[0];
        double headingDegs = double.Parse(parameters[1]);
        double speedKph    = double.Parse(parameters[2]);

        string retString = "";

        if (EventDriver.DoesPlatformExist(platName))
        {
            KoreCourse newCourse = new KoreCourse() { HeadingDegs = headingDegs, SpeedKph = speedKph };

            EventDriver.SetPlatformCourse(platName, newCourse);
            retString = $"Platform {platName} Updated: Course: {newCourse}.";
        }
        else
        {
            retString = $"Platform {platName} not found.";
        }

        KoreCentralLog.AddEntry($"KoreCommandPlatCourse.Execute -> {retString}");
        return retString;
    }
}
