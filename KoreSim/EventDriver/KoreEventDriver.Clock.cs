
using System;

// Design Decisions:
// - The KoreEventDriver is the top level class that manages data. Commands and Tasks interact with the business logic through this point.

using KoreSim;

public partial class KoreEventDriver
{

    // ---------------------------------------------------------------------------------------------
    // MARK: Simulation Clock
    // ---------------------------------------------------------------------------------------------
    // different to runtime clock and Time Functions, this is the in-sium time that can be paused etc.

    public void SimClockStart()  => KoreSimFactory.Instance.ModelRun.Start();
    public void SimClockStop()   => KoreSimFactory.Instance.ModelRun.Stop();
    public void SimClockReset()  => KoreSimFactory.Instance.ModelRun.Reset();
    public void SimClockResume() => KoreSimFactory.Instance.ModelRun.Resume();

    public void SetSimClockSeconds(double secs)
    {
    }

    public void SetSimTimeHMS(string hms)
    {
        KoreSimFactory.Instance.SimClock.SimTimeHMS = hms;
    }

    public int    SimSeconds() => (int)KoreSimFactory.Instance.SimClock.SimTime;
    public string SimTimeHMS() => KoreSimFactory.Instance.SimClock.SimTimeHMS;

    // ---------------------------------------------------------------------------------------------

    public void   ClockSetRate(double rate) => KoreSimFactory.Instance.SimClock.SetSimRate(rate);
    public double ClockRate()               => KoreSimFactory.Instance.SimClock.SimRate;
}