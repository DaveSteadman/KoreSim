using System;

using KoreCommon;

using KoreSim;
using KoreSim.JSON;

#nullable enable

// Class to translate an incoming JSON Message into calls to the Event Driver

public static partial class KoreMessageManager
{
    private static void ProcessMessage_ScenLoad(ScenLoad scenLoadMsg)
    {
        KoreCentralLog.AddEntry($"KoreMessageManager.ProcessMessage_ScenLoad: Name:{scenLoadMsg.ScenName} ScenPos:{scenLoadMsg.ScenPos}");
        //KoreSimFactory.Instance.UIState.ScenarioName = scenLoadMsg.ScenName;
        EventDriver.DeleteAllPlatforms();
    }

    private static void ProcessMessage_ScenStart(ScenStart scenStartMsg)
    {
        KoreCentralLog.AddEntry($"KoreMessageManager.ProcessMessage_ScenStart");
        EventDriver.SimClockReset();
        EventDriver.SimClockStart();
    }

    private static void ProcessMessage_ScenStop(ScenStop scenStopMsg)
    {
        KoreCentralLog.AddEntry($"KoreMessageManager.ProcessMessage_ScenStop");
        EventDriver.SimClockStop();
        EventDriver.DeleteElementAllBeams();
    }

    private static void ProcessMessage_ScenPause(ScenPause scenPauseMsg)
    {
        KoreCentralLog.AddEntry($"KoreMessageManager.ProcessMessage_ScenPause: ScenTime:{scenPauseMsg.ScenTimeHMS}");
        EventDriver.SimClockStop();

        EventDriver.SetSimTimeHMS(scenPauseMsg.ScenTimeHMS);
    }

    private static void ProcessMessage_ScenCont(ScenCont scenContMsg)
    {
        KoreCentralLog.AddEntry($"KoreMessageManager.ProcessMessage_ScenCont: ScenTime:{scenContMsg.ScenTimeHMS}");
        EventDriver.SetSimTimeHMS(scenContMsg.ScenTimeHMS);
        EventDriver.SimClockResume();
    }

    private static void ProcessMessage_ClockSync(ClockSync clockSyncMsg)
    {
        KoreCentralLog.AddEntry($"KoreMessageManager.ProcessMessage_ClockSync: ScenTimeHMS:{clockSyncMsg.ScenTimeHMS}");
        EventDriver.SetSimTimeHMS(clockSyncMsg.ScenTimeHMS);
    }

}
