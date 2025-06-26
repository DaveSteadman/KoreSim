using System;
using System.Collections.Generic;

using KoreCommon;

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

    // --------------------------------------------------------------------------------------------
    // MARK: Elements / Antenna Patterns
    // --------------------------------------------------------------------------------------------

    private void ProcessMessage_AntennaPattern(AntennaPattern antPatternMsg)
    {
        string sizeStr = $"Size:{antPatternMsg.AzPointCount}x{antPatternMsg.ElPointCount} ArrayCount:{antPatternMsg.Pattern.Count}";
        //KoreCentralLog.AddEntry($"KoreMessageManager.ProcessMessage_AntennaPattern: PlatName:{antPatternMsg.PlatName} // {sizeStr}");

        string platName = antPatternMsg.PlatName;
        string portName = antPatternMsg.PortName;

        KoreSimFactory.Instance.EventDriver.PlatformSetAntennaPatternMetadata(platName, portName, antPatternMsg.AzElBox, antPatternMsg.PolarOffset);

        int azPointCount   = antPatternMsg.AzPointCount;
        int elPointCount   = antPatternMsg.ElPointCount;
        int dataPointCount = antPatternMsg.Pattern.Count;

        // check AP and assign unaffected.
        if (azPointCount * elPointCount == dataPointCount)
        {
            KoreSimFactory.Instance.EventDriver.PlatformSetAntennaPatternData(platName, portName, antPatternMsg.AzPointCount, antPatternMsg.ElPointCount, antPatternMsg.Pattern);
            KoreCentralLog.AddEntry($"KoreMessageManager.ProcessMessage_AntennaPattern: PlatName:{antPatternMsg.PlatName} // {sizeStr} // Adding a +1 array");
        }
        else if ( (azPointCount+1) * (elPointCount+1) == dataPointCount)
        {
            KoreSimFactory.Instance.EventDriver.PlatformSetAntennaPatternData(
                platName, portName,
                antPatternMsg.AzPointCount + 1,
                antPatternMsg.ElPointCount + 1,
                antPatternMsg.Pattern);
            KoreCentralLog.AddEntry($"KoreMessageManager.ProcessMessage_AntennaPattern: PlatName:{antPatternMsg.PlatName} // {sizeStr} // Adding a +1 array");

        }
        else
        {
            KoreCentralLog.AddEntry("ProcessMessage_AntennaPattern: Size Issue");
        }
    }

}
