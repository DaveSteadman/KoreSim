
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

    public static void AddEntity(string entName)
    {
        // Create a new entity
        // if (KoreSimFactory.Instance.EntityManager == null)
        //     KoreCentralLog.AddEntry("EC0-0002: ERROR ERROR ERROR: Entity Manager not found in KoreSimFactory.Instance");

        KoreEntity? newEnt = KoreSimFactory.Instance.EntityManager.Add(entName);
        if (newEnt == null)
        {
            KoreCentralLog.AddEntry($"EC0-0026: Entity {entName} not created, already exists.");
            return;
        }
    }

    public static void AddEntity(string entName, string entType)
    {
        // Create a new entity
        // if (KoreSimFactory.Instance.EntityManager == null)
        //     KoreCentralLog.AddEntry("EC0-0002: ERROR ERROR ERROR: Entity Manager not found in KoreSimFactory.Instance");

        KoreEntity? newEnt = KoreSimFactory.Instance.EntityManager.Add(entName);
        if (newEnt == null)
        {
            KoreCentralLog.AddEntry($"EC0-0026: Entity {entName} not created, already exists.");
            return;
        }


        //DefaultEntityDetails(entName);
    }

    public static bool DoesEntityExist(string entName) => KoreSimFactory.Instance.EntityManager.DoesEntityExist(entName);
    public static void DeleteEntity(string entName) => KoreSimFactory.Instance.EntityManager.Delete(entName);
    public static void DeleteAllEntities() => KoreSimFactory.Instance.EntityManager.DeleteAllEntities();
    public static int NumEntities() => KoreSimFactory.Instance.EntityManager.NumEntities();

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
        KoreEntity? platform = KoreSimFactory.Instance.EntityManager.EntityForName(platName);

        if (platform == null)
        {
            KoreCentralLog.AddEntry($"EC0-0002: Platform {platName} not found.");
            return;
        }

        // Set the platform's details
        platform.Kinetics.CurrPosition = startPos;
        platform.Kinetics.CurrAttitude = startAtt;
        platform.Kinetics.CurrCourse = startCourse;
    }

    public static void SetPlatformCurrDetails(string platName, KoreLLAPoint currPos, KoreAttitude currAtt, KoreCourse course, KoreCourseDelta courseDelta)
    {
        // Get the platform
        KoreEntity? platform = KoreSimFactory.Instance.EntityManager.EntityForName(platName);

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
        KoreEntity? platform = KoreSimFactory.Instance.EntityManager.EntityForName(platName);

        if (platform == null)
        {
            KoreCentralLog.AddEntry($"EC0-0005: Platform {platName} not found.");
            return;
        }

        // Set the platform's start location
        platform.Kinetics.CurrPosition = newpos;
        platform.Kinetics.CurrCourse   = newcourse;
        platform.Kinetics.CurrAttitude = newAtt;
    }

    // ---------------------------------------------------------------------------------------------
    // MARK:  Type
    // ---------------------------------------------------------------------------------------------

    public static void SetPlatformType(string platName, string platType, string platCategory)
    {
        // Get the platform
        KoreEntity? platform = KoreSimFactory.Instance.EntityManager.EntityForName(platName);

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
        KoreSimFactory.Instance.EntityManager.EntityForName(platName)?.Type;

    public static string? PlatformCategory(string platName) =>
        KoreSimFactory.Instance.EntityManager.EntityForName(platName)?.Category;

    // ---------------------------------------------------------------------------------------------
    // MARK: Position
    // ---------------------------------------------------------------------------------------------

    public static void SetPlatformStartLLA(string platName, KoreLLAPoint newpos)
    {
        // Get the platform
        KoreEntity? platform = KoreSimFactory.Instance.EntityManager.EntityForName(platName);

        if (platform == null)
        {
            KoreCentralLog.AddEntry($"EC0-0005: Platform {platName} not found.");
            return;
        }

        // Set the platform's start location
        platform.Kinetics.CurrPosition = newpos;
    }

    public static KoreLLAPoint? PlatformStartLLA(string platName)
    {
        // Get the platform
        KoreEntity? platform = KoreSimFactory.Instance.EntityManager.EntityForName(platName);

        if (platform == null)
            return null;

        return platform.Kinetics.CurrPosition;
    }

    // ---------------------------------------------------------------------------------------------

    public static void SetPlatformPosition(string platName, KoreLLAPoint newpos)
    {
        // Get the platform
        KoreEntity? platform = KoreSimFactory.Instance.EntityManager.EntityForName(platName);

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
    // MARK: Report
    // ---------------------------------------------------------------------------------------------

    public static string EntityPositionsReport() => KoreSimFactory.Instance.EntityManager.EntityPositionsReport();
    public static string EntityElementsReport() => KoreSimFactory.Instance.EntityManager.EntityElementsReport();

    // ---------------------------------------------------------------------------------------------
    // MARK: Names
    // ---------------------------------------------------------------------------------------------

    public static string EntityNameForIndex(int index) => KoreSimFactory.Instance.EntityManager.EntityNameForIndex(index);
    public static KoreEntity? EntityForIndex(int index) => KoreSimFactory.Instance.EntityManager.EntityForIndex(index);
    public static KoreEntity? EntityForName(string platname) => KoreSimFactory.Instance.EntityManager.EntityForName(platname);

    // Id being the 1-based user presented index

    public static string EntityIdForName(string platname) => KoreSimFactory.Instance.EntityManager.EntityIdForName(platname);
    public static string EntityNameForId(int platId) => KoreSimFactory.Instance.EntityManager.EntityNameForId(platId);

    public static int EntityIdNext(int currPlatId) => KoreSimFactory.Instance.EntityManager.EntityIdNext(currPlatId);
    public static int EntityIdPrev(int currPlatId) => KoreSimFactory.Instance.EntityManager.EntityIdPrev(currPlatId);

    public static List<string> EntityNameList() => KoreSimFactory.Instance.EntityManager.EntityNameList();


}


