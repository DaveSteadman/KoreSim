using System.Collections.Generic;

// KoreCommandVersion

public class KoreCommandPlatTestScenario : KoreCommand
{
    public KoreCommandPlatTestScenario()
    {
        Signature.Add("plat");
        Signature.Add("test");
    }

    public override string Execute(List<string> parameters)
    {
        KoreCentralLog.AddEntry("KoreCommandPlatTestScenario");
        EventDriver.SetupTestPlatforms();

        int num = EventDriver.NumPlatforms();
        return $"KoreCommandPlatTestScenario:\n Number of Platforms: {num}";
    }

}
