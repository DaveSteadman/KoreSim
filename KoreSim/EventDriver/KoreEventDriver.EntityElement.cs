
using System;
using System.Collections.Generic;

using KoreCommon;
using KoreSim;


#nullable enable

// Design Decisions:
// - The KoreEventDriver is the top level class that manages data. Commands and Tasks interact with the business logic through this point.

public static partial class KoreEventDriver
{
    // ---------------------------------------------------------------------------------------------
    // MARK: Basic Element Management
    // ---------------------------------------------------------------------------------------------

    public static void AddPlatformElement(string platName, string elemName, string platElemType)
    {
        // Create a new platform
        KoreEntityElementOperations.CreatePlatformElement(platName, elemName, platElemType);
    }

    public static void AddPlatformElement(string platName, string elemName, KoreEntityElement element)
    {
        // Get the platform
        KoreEntity? platform = KoreSimFactory.Instance.EntityManager.EntityForName(platName);

        if (platform == null)
            return;

        // Add the element to the platform
        platform.AddElement(element);
    }

    public static void DeletePlatformElement(string platName, string elemName)
    {
        KoreEntity? platform = KoreSimFactory.Instance.EntityManager.EntityForName(platName);

        if (platform == null)
            return;

        platform.DeleteElement(elemName);
    }

    public static List<string> PlatformElementNames(string platName)
    {
        KoreEntity? platform = KoreSimFactory.Instance.EntityManager.EntityForName(platName);

        if (platform == null)
            return new List<string>();

        return platform.ElementNames();
    }

    // ---------------------------------------------------------------------------------------------

    public static void PlatformAddSizerBox(string platName, string platType)
    {
        // Get the platform
        KoreEntity? platform = KoreSimFactory.Instance.EntityManager.EntityForName(platName);

        if (platform == null)
            return;

        // fixed elemName for the box
        string elemName = "SizerBox";

        // Get the element
        KoreEntityElement? element = platform.ElementForName(elemName);

        if (element == null)
            return;

        // Set the element's size
        return;
    }

    // ---------------------------------------------------------------------------------------------
    // MARK: Element Name Helpers
    // ---------------------------------------------------------------------------------------------

    public static KoreEntityElement? GetElement(string platName, string elemName)
    {
        if (string.IsNullOrEmpty(platName) || string.IsNullOrEmpty(elemName))
            return null;

        KoreEntity? platform = KoreSimFactory.Instance.EntityManager.EntityForName(platName);

        if (platform == null)
            return null;

        return platform.ElementForName(elemName);
    }



}
