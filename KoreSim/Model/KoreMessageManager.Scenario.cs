using System;

using KoreCommon;

#nullable enable

// Class to translate an incoming JSON Message into calls to the Event Driver

public partial class KoreMessageManager
{
    private void ProcessMessage_ScenLoad(ScenLoad scenLoadMsg)
    {
        KoreCentralLog.AddEntry($"KoreMessageManager.ProcessMessage_ScenLoad: Name:{scenLoadMsg.ScenName} ScenPos:{scenLoadMsg.ScenPos}");
        KoreGodotFactory.Instance.UIState.ScenarioName = scenLoadMsg.ScenName;
        KoreSimFactory.Instance.EventDriver.DeleteAllPlatforms();
    }

    private void ProcessMessage_ScenStart(ScenStart scenStartMsg)
    {
        KoreCentralLog.AddEntry($"KoreMessageManager.ProcessMessage_ScenStart");
        KoreSimFactory.Instance.EventDriver.SimClockReset();
        KoreSimFactory.Instance.EventDriver.SimClockStart();
    }

    private void ProcessMessage_ScenStop(ScenStop scenStopMsg)
    {
        KoreCentralLog.AddEntry($"KoreMessageManager.ProcessMessage_ScenStop");
        KoreSimFactory.Instance.EventDriver.SimClockStop();
        KoreSimFactory.Instance.EventDriver.DeleteElementAllBeams();
    }

    private void ProcessMessage_ScenPause(ScenPause scenPauseMsg)
    {
        KoreCentralLog.AddEntry($"KoreMessageManager.ProcessMessage_ScenPause: ScenTime:{scenPauseMsg.ScenTimeHMS}");
        KoreSimFactory.Instance.EventDriver.SimClockStop();
        KoreSimFactory.Instance.EventDriver.SetSimTimeHMS(scenPauseMsg.ScenTimeHMS);
    }

    private void ProcessMessage_ScenCont(ScenCont scenContMsg)
    {
        KoreCentralLog.AddEntry($"KoreMessageManager.ProcessMessage_ScenCont: ScenTime:{scenContMsg.ScenTimeHMS}");
        KoreSimFactory.Instance.EventDriver.SetSimTimeHMS(scenContMsg.ScenTimeHMS);
        KoreSimFactory.Instance.EventDriver.SimClockResume();
    }

    private void ProcessMessage_ClockSync(ClockSync clockSyncMsg)
    {
        KoreCentralLog.AddEntry($"KoreMessageManager.ProcessMessage_ClockSync: ScenTimeHMS:{clockSyncMsg.ScenTimeHMS}");
        KoreSimFactory.Instance.EventDriver.SetSimTimeHMS(clockSyncMsg.ScenTimeHMS);
    }

}
