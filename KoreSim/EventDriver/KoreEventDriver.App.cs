
using System;


namespace KoreSim;


// Design Decisions:
// - The KoreEventDriver is the top level class that manages data. Commands and Tasks interact with the business logic through this point.

public static partial class KoreEventDriver
{
    // ---------------------------------------------------------------------------------------------
    // Command Execution
    // ---------------------------------------------------------------------------------------------

    public static void ExitApplication()
    {
        KoreSimFactory.Instance.ConsoleInterface.Stop();
        KoreSimFactory.Instance.NetworkHub.endAllConnections();
        //KoreSimFactory.Instance.NetworkHub.EndAllThread();
    }

    // ---------------------------------------------------------------------------------------------
    // MARK: Sidebar view settings
    // ---------------------------------------------------------------------------------------------

    // Usage: EventDriver.SidebarSetBeamVisibility(true, true);

    // public void SidebarSetBeamVisibility(bool rxVisible, bool txVisible)
    // {
    //     // Set the UI State values
    //     GloGodotFactory.Instance.UIState.ShowRx = rxVisible;
    //     GloGodotFactory.Instance.UIState.ShowTx = txVisible;
    // }

    // ---------------------------------------------------------------------------------------------

    // Usage: EventDriver.SidebarSetRouteVisibility(true);
    //        EventDriver.SidebarSetEmitterVisibility(true);
    //        EventDriver.SidebarSetAntennaPatternVisibility(true);

    // public void SidebarSetRouteVisibility(bool routeVisible)                   => GloGodotFactory.Instance.UIState.ShowRoutes          = routeVisible;
    // public void SidebarSetEmitterVisibility(bool emitterVisible)               => GloGodotFactory.Instance.UIState.ShowEmitters        = emitterVisible;
    // public void SidebarSetAntennaPatternVisibility(bool antennaPatternVisible) => GloGodotFactory.Instance.UIState.ShowAntennaPatterns = antennaPatternVisible;

    // public void SetCameraModeWorld()    => GloGodotFactory.Instance.UIState.SetCameraModeWorld();
    // public void SetCameraModeChaseCam() => GloGodotFactory.Instance.UIState.SetCameraModeChaseCam();
    // public void SetCameraModeAlignCam() => GloGodotFactory.Instance.UIState.SetCameraModeAlignCam();


    // ---------------------------------------------------------------------------------------------

}

