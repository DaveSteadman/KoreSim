
using System;
using System.Collections.Generic;

using KoreCommon;
using KoreSim;

#nullable enable

// Design Decisions:
// - The KoreEventDriver is the top level class that manages data. Commands and Tasks interact with the business logic through this point.

public partial class KoreEventDriver
{
    // ---------------------------------------------------------------------------------------------
    // MARK: Route
    // ---------------------------------------------------------------------------------------------

    public void PlatformSetRoute(string platName, List<KoreLLAPoint> points)
    {
        string elemName = $"{platName}_Route";
        KoreEntityElementRoute? route = GetElement(platName, elemName) as KoreEntityElementRoute;

        if (route == null)
        {
            route = new KoreEntityElementRoute() { Name = elemName };
            route.AddPoints(points);

            KoreEntity? platform = EntityForName(platName);
            if (platform == null)
            {
                KoreCentralLog.AddEntry($"EC0-0017: PlatformSetRoute: Platform {platName} not found.");
                return;
            }

            platform.AddElement(route);
        }
        else
        {
            route.Clear();
            route.AddPoints(points);
        }
    }

    public List<KoreLLAPoint> PlatformGetRoutePoints(string platName)
    {
        string elemName = $"{platName}_Route";
        KoreEntityElementRoute? route = GetElement(platName, elemName) as KoreEntityElementRoute;

        if (route == null)
        {
            KoreCentralLog.AddEntry($"EC0-0018: PlatformGetRoutePoints: Route {elemName} not found.");
            return new List<KoreLLAPoint>();
        }

        // Return a new list copying the points (so the caller can't modify the route)
        return new List<KoreLLAPoint>(route.Points);
    }

    public void PlatformClearRoute(string platName)
    {
        string elemName = $"{platName}_Route";
        KoreEntityElementRoute? route = GetElement(platName, elemName) as KoreEntityElementRoute;

        if (route == null)
        {
            KoreCentralLog.AddEntry($"EC0-0019: PlatformClearRoute: Route {elemName} not found.");
            return;
        }

        // Clear the route
        route.Clear();
    }

    // ---------------------------------------------------------------------------------------------
    // MARK: Helper Routines
    // ---------------------------------------------------------------------------------------------

    private KoreEntityElementRoute? GetRouteElement(string platName, string elemName)
    {
        KoreEntityElement? element = GetElement(platName, elemName);
        if (element == null)
        {
            KoreCentralLog.AddEntry($"EC0-0020: GetRouteElement: Element {elemName} not found.");
            return null;
        }

        if (element is KoreEntityElementRoute)
        {
            return element as KoreEntityElementRoute;
        }
        else
        {
            KoreCentralLog.AddEntry($"EC0-0021: GetRouteElement: Element {elemName} is not a route.");
            return null;
        }
    }



}
