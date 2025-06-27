
using System;
using System.Collections.Generic;

#nullable enable

using KoreCommon;

namespace KoreSim;

// Design Decisions:
// - The KoreEventDriver is the top level class that manages data. Commands and Tasks interact with the business logic through this point.

public static partial class KoreEventDriver
{
    // ---------------------------------------------------------------------------------------------
    // MARK: Add/Del
    // ---------------------------------------------------------------------------------------------
    public static void AddPlatform(string platName)
    {
        // Create a new platform
        // if (KoreSimFactory.Instance.EntityManager == null)
        //     KoreCentralLog.AddEntry("EC0-0002: ERROR ERROR ERROR: Platform Manager not found in KoreSimFactory.Instance");

        KoreEntity? newPlat = KoreSimFactory.Instance.EntityManager.Add(platName);
        if (newPlat == null)
        {
            KoreCentralLog.AddEntry($"EC0-0026: Platform {platName} not created, already exists.");
            return;
        }
        newPlat.Type = "Unknown";
    }

    public static void AddPlatform(string platName, string platType)
    {
        // Create a new platform
        // if (KoreSimFactory.Instance.EntityManager == null)
        //     KoreCentralLog.AddEntry("EC0-0002: ERROR ERROR ERROR: Platform Manager not found in KoreSimFactory.Instance");

        KoreEntity? newPlat = KoreSimFactory.Instance.EntityManager.Add(platName);
        if (newPlat == null)
        {
            KoreCentralLog.AddEntry($"EC0-0001: Platform {platName} not created, already exists.");
            return;
        }
        newPlat.Type = platType;

        DefaultPlatformDetails(platName);
    }

    public static bool DoesPlatformExist(string platName) => KoreSimFactory.Instance.EntityManager.DoesPlatExist(platName);
    public static void DeletePlatform(string platName) => KoreSimFactory.Instance.EntityManager.Delete(platName);
    public static void DeleteAllPlatforms() => KoreSimFactory.Instance.EntityManager.DeleteAllPlatforms();
    public static int NumPlatforms() => KoreSimFactory.Instance.EntityManager.NumPlatforms();

    // ---------------------------------------------------------------------------------------------
    // MARK: Details
    // ---------------------------------------------------------------------------------------------

    public static void DefaultPlatformDetails(string platName)
    {
        KoreLLAPoint startPos = new KoreLLAPoint() { LatDegs = 0.0, LonDegs = 0.0, AltMslM = 100.0 };
        KoreLLAPoint currPos = new KoreLLAPoint() { LatDegs = 0.0, LonDegs = 0.0, AltMslM = 100.0 };
        KoreAttitude att = new KoreAttitude() { PitchUpDegs = 0.0, RollClockwiseDegs = 0.0, YawClockwiseDegs = 0.0 };
        KoreCourse course = new KoreCourse() { SpeedKph = 0.0, HeadingDegs = 0.0, ClimbRateMps = 0.0 };
        KoreCourseDelta courseDelta = new KoreCourseDelta() { SpeedChangeMpMps = 0.0, HeadingChangeClockwiseDegsSec = 0.0 };

        SetPlatformStartDetails(platName, startPos, att, course);
        SetPlatformCurrDetails(platName, currPos, att, course, courseDelta);
    }

    public static void SetPlatformStartDetails(string platName, KoreLLAPoint startPos, KoreAttitude startAtt, KoreCourse startCourse)
    {
        // Get the platform
        KoreEntity? platform = KoreSimFactory.Instance.EntityManager.PlatForName(platName);

        if (platform == null)
        {
            KoreCentralLog.AddEntry($"EC0-0002: Platform {platName} not found.");
            return;
        }

        // Set the platform's details
        platform.Kinetics.StartPosition = startPos;
        platform.Kinetics.StartAttitude = startAtt;
        platform.Kinetics.StartCourse = startCourse;
    }

    public static void SetPlatformCurrDetails(string platName, KoreLLAPoint currPos, KoreAttitude currAtt, KoreCourse course, KoreCourseDelta courseDelta)
    {
        // Get the platform
        KoreEntity? platform = KoreSimFactory.Instance.EntityManager.PlatForName(platName);

        if (platform == null)
        {
            KoreCentralLog.AddEntry($"EC0-0002: Platform {platName} not found.");
            return;
        }

        // Set the platform's details
        platform.Kinetics.CurrPosition = currPos;
        platform.Kinetics.CurrAttitude = currAtt;
        platform.Kinetics.CurrCourse = course;
        platform.Kinetics.CurrCourseDelta = courseDelta;
    }

    // ---------------------------------------------------------------------------------------------
    // MARK: Start
    // ---------------------------------------------------------------------------------------------

    public static void SetPlatformStart(string platName, KoreLLAPoint newpos, KoreCourse newcourse, KoreAttitude newAtt)
    {
        // Get the platform
        KoreEntity? platform = KoreSimFactory.Instance.EntityManager.PlatForName(platName);

        if (platform == null)
        {
            KoreCentralLog.AddEntry($"EC0-0005: Platform {platName} not found.");
            return;
        }

        // Set the platform's start location
        platform.Kinetics.StartPosition = newpos;
        platform.Kinetics.StartCourse = newcourse;
        platform.Kinetics.StartAttitude = newAtt;
    }

    // ---------------------------------------------------------------------------------------------
    // MARK:  Type
    // ---------------------------------------------------------------------------------------------

    public static void SetPlatformType(string platName, string platType, string platCategory)
    {
        // Get the platform
        KoreEntity? platform = KoreSimFactory.Instance.EntityManager.PlatForName(platName);

        if (platform == null)
        {
            KoreCentralLog.AddEntry($"EC0-0031: Platform {platName} not found.");
            return;
        }

        // Set the platform's type
        platform.Type = platType;
        platform.Category = platCategory;
    }

    public static string? PlatformType(string platName) =>
        KoreSimFactory.Instance.EntityManager.PlatForName(platName)?.Type;

    public static string? PlatformCategory(string platName) =>
        KoreSimFactory.Instance.EntityManager.PlatForName(platName)?.Category;

    // ---------------------------------------------------------------------------------------------
    // MARK: Position
    // ---------------------------------------------------------------------------------------------

    public static void SetPlatformStartLLA(string platName, KoreLLAPoint newpos)
    {
        // Get the platform
        KoreEntity? platform = KoreSimFactory.Instance.EntityManager.PlatForName(platName);

        if (platform == null)
        {
            KoreCentralLog.AddEntry($"EC0-0005: Platform {platName} not found.");
            return;
        }

        // Set the platform's start location
        platform.Kinetics.StartPosition = newpos;
    }

    public static KoreLLAPoint? PlatformStartLLA(string platName)
    {
        // Get the platform
        KoreEntity? platform = KoreSimFactory.Instance.EntityManager.PlatForName(platName);

        if (platform == null)
            return null;

        return platform.Kinetics.StartPosition;
    }

    // ---------------------------------------------------------------------------------------------

    public static void SetPlatformPosition(string platName, KoreLLAPoint newpos)
    {
        // Get the platform
        KoreEntity? platform = KoreSimFactory.Instance.EntityManager.PlatForName(platName);

        if (platform == null)
        {
            KoreCentralLog.AddEntry($"EC0-0006: Platform {platName} not found.");
            return;
        }

        // Set the platform's position
        platform.Kinetics.CurrPosition = newpos;
    }

    public static KoreLLAPoint? GetPlatformPosition(string platName)
    {
        // Get the platform
        KoreEntity? platform = KoreSimFactory.Instance.EntityManager.EntityForName(platName);

        if (platform == null)
            return null;

        return platform.Kinetics.CurrPosition;
    }

    // ---------------------------------------------------------------------------------------------
    // MARK: Attitude
    // ---------------------------------------------------------------------------------------------

    public static KoreAttitude? GetPlatformAttitude(string platName)
    {
        // Get the platform
        KoreEntity? platform = KoreSimFactory.Instance.EntityManager.EntityForName(platName);

        if (platform == null)
            return null;

        return platform.Kinetics.CurrAttitude;
    }

    public static void SetPlatformAttitude(string platName, KoreAttitude newatt)
    {
        // Get the platform
        KoreEntity? platform = KoreSimFactory.Instance.EntityManager.EntityForName(platName);

        if (platform == null)
        {
            KoreCentralLog.AddEntry($"EC0-0008: Platform {platName} not found.");
            return;
        }

        // Set the platform's attitude
        platform.Kinetics.CurrAttitude = newatt;
    }

    // ---------------------------------------------------------------------------------------------
    // MARK: Course
    // ---------------------------------------------------------------------------------------------

    public static void SetPlatformCourse(string platName, KoreCourse course)
    {
        // Get the platform
        KoreEntity? platform = KoreSimFactory.Instance.EntityManager.EntityForName(platName);

        if (platform == null)
        {
            KoreCentralLog.AddEntry($"EC0-0009: Platform {platName} not found.");
            return;
        }

        // Set the platform's course
        platform.Kinetics.CurrCourse = course;
    }

    public static KoreCourse? PlatformCurrCourse(string platName) =>
        KoreSimFactory.Instance.EntityManager.EntityForName(platName)?.Kinetics.CurrCourse;

    // ---------------------------------------------------------------------------------------------
    // MARK: Course Delta
    // ---------------------------------------------------------------------------------------------

    public static void SetPlatformCourseDelta(string platName, KoreCourseDelta courseDelta)
    {
        // Get the platform
        KoreEntity? platform = KoreSimFactory.Instance.EntityManager.EntityForName(platName);

        if (platform == null)
        {
            KoreCentralLog.AddEntry($"EC0-0010: Platform {platName} not found.");
            return;
        }

        // Set the platform's course delta
        platform.Kinetics.CurrCourseDelta = courseDelta;
    }

    public static KoreCourseDelta? PlatformCurrCourseDelta(string platName)
    {
        // Get the platform
        KoreEntity? platform = KoreSimFactory.Instance.EntityManager.EntityForName(platName);

        if (platform == null)
            return null;

        return platform.Kinetics.CurrCourseDelta;
    }

    // ---------------------------------------------------------------------------------------------
    // MARK: Focus
    // ---------------------------------------------------------------------------------------------

    public static void SetPlatformFocus(string platName)
    {
        // Check the platform exists
        if (!DoesPlatformExist(platName))
        {
            KoreCentralLog.AddEntry($"Attempt to select non-existent platform {platName}");
            return;
        }

        // check the name matches an entity
        if (!KoreGodotFactory.Instance.GodotEntityManager.EntityExists(platName))
        {
            KoreCentralLog.AddEntry($"Attempt to select non-existent entity {platName}");
            return;
        }

        // Select the chase cam mode
        // move the chase cam if in the right mode
        // if (KoreGodotFactory.Instance.UIState.IsCamModeChaseCam())
        // {

        int platFindCountdown = NumPlatforms();
        while (NearPlatformName() != platName)
        {
            NearPlatformNext();
            platFindCountdown--;
            if (platFindCountdown <= 0)
            {
                KoreCentralLog.AddEntry($"Platform {platName} not found in list.");
                break;
            }
        }
        KoreCentralLog.AddEntry($"SetPlatformFocus: near platform [{platName}] selected");

        SetCameraModeChaseCam();

        //KoreGodotFactory.Instance.GodotEntityManager.EnableChaseCam(platName);
        KoreGodotFactory.Instance.UIState.UpdateDisplayedChaseCam();

        // }
    }

    // ---------------------------------------------------------------------------------------------
    // MARK: Report
    // ---------------------------------------------------------------------------------------------

    public static string PlatformPositionsReport() => KoreSimFactory.Instance.EntityManager.PlatformPositionsReport();
    public static string PlatformElementsReport() => KoreSimFactory.Instance.EntityManager.PlatformElementsReport();

    // ---------------------------------------------------------------------------------------------
    // MARK: Names
    // ---------------------------------------------------------------------------------------------

    public static string PlatformNameForIndex(int index) => KoreSimFactory.Instance.EntityManager.PlatNameForIndex(index);
    public static KoreEntity? PlatformForIndex(int index) => KoreSimFactory.Instance.EntityManager.PlatForIndex(index);
    public static KoreEntity? PlatformForName(string platname) => KoreSimFactory.Instance.EntityManager.PlatForName(platname);

    // Id being the 1-based user presented index

    public static string PlatformIdForName(string platname) => KoreSimFactory.Instance.EntityManager.PlatIdForName(platname);
    public static string PlatformNameForId(int platId) => KoreSimFactory.Instance.EntityManager.PlatNameForId(platId);

    public static int PlatformIdNext(int currPlatId) => KoreSimFactory.Instance.EntityManager.PlatIdNext(currPlatId);
    public static int PlatformIdPrev(int currPlatId) => KoreSimFactory.Instance.EntityManager.PlatIdPrev(currPlatId);

    public static List<string> PlatformNames() => KoreSimFactory.Instance.EntityManager.PlatNameList();


}


