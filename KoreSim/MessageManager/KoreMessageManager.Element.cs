using System;
using System.Collections.Generic;

using KoreCommon;
using KoreJSON;
using KoreSim;

#nullable enable

// Class to translate an incoming JSON Message into calls to the Event Driver

public partial class KoreMessageManager
{
    // --------------------------------------------------------------------------------------------
    // MARK: Elements / Waypoints
    // --------------------------------------------------------------------------------------------

    private void ProcessMessage_PlatWayPoints(PlatWayPoints platWayPtsMsg)
    {
        KoreCentralLog.AddEntry($"KoreMessageManager.ProcessMessage_PlatWayPoints: Name:{platWayPtsMsg.PlatName}");

        string platName          = platWayPtsMsg.PlatName;
        List<KoreLLAPoint> points = platWayPtsMsg.Points();



        KoreSimFactory.Instance.EventDriver.PlatformSetRoute(platName, points);
    }


}
