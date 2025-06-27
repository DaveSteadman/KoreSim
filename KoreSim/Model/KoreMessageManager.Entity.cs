using System;



using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using KoreCommon;
using KoreJSON;
using KoreSim;

#nullable enable

// Class to translate an incoming JSON Message into calls to the Event Driver

public partial class KoreMessageManager
{
    // --------------------------------------------------------------------------------------------

    private void ProcessMessage_PlatFocus(PlatFocus msg)
    {
        KoreCentralLog.AddEntry($"KoreMessageManager.ProcessMessage_PlatFocus: {msg.PlatName}");
        KoreGodotFactory.Instance.UIMsgQueue.EnqueueMessage(msg);
    }

    // --------------------------------------------------------------------------------------------

    private void ProcessMessage_PlatAdd(PlatAdd msg)
    {
        KoreCentralLog.AddEntry($"KoreMessageManager.ProcessMessage_PlatAdd: {msg.PlatName}");

        // Check if the platform already exists
        if (!KoreSimFactory.Instance.EventDriver.DoesPlatformExist(msg.PlatName))
        {
            KoreSimFactory.Instance.EventDriver.AddPlatform(msg.PlatName, msg.PlatClass);
        }

        if (KoreSimFactory.Instance.EventDriver.DoesPlatformExist(msg.PlatName))
        {
            // Name (like tail number), Class (like F-16), Category (like aircraft)
            KoreSimFactory.Instance.EventDriver.SetPlatformType(
                msg.PlatName, msg.PlatClass , msg.PlatCategory);

            KoreSimFactory.Instance.EventDriver.SetPlatformStartDetails(
                msg.PlatName, msg.Pos, msg.Attitude, msg.Course);

            KoreSimFactory.Instance.EventDriver.SetPlatformCurrDetails(
                msg.PlatName, msg.Pos, msg.Attitude, msg.Course, KoreCourseDelta.Zero);
        }
    }

    // --------------------------------------------------------------------------------------------

    private void ProcessMessage_PlatDelete(PlatDelete msg)
    {
        KoreCentralLog.AddEntry($"KoreMessageManager.ProcessMessage_PlatDelete: {msg.PlatName}");

        // Check if the platform exists
        if (KoreSimFactory.Instance.EventDriver.DoesPlatformExist(msg.PlatName))
        {
            KoreSimFactory.Instance.EventDriver.DeletePlatform(msg.PlatName);
        }
    }

    // --------------------------------------------------------------------------------------------

    private void ProcessMessage_PlatUpdate(PlatUpdate msg)
    {
        KoreCentralLog.AddEntry($"KoreMessageManager.ProcessMessage_PlatUpdate: {msg.PlatName}");

        // Check if the platform exists
        if (KoreSimFactory.Instance.EventDriver.DoesPlatformExist(msg.PlatName))
        {
            KoreSimFactory.Instance.EventDriver.SetPlatformCurrDetails(
                msg.PlatName, msg.Pos, msg.Attitude, msg.Course, msg.CourseDelta);
        }
    }

    // --------------------------------------------------------------------------------------------

    private void ProcessMessage_PlatPosition(PlatPosition msg)
    {
        KoreCentralLog.AddEntry($"KoreMessageManager.ProcessMessage_PlatPosition: {msg.PlatName}");

        // Check if the platform exists
        if (KoreSimFactory.Instance.EventDriver.DoesPlatformExist(msg.PlatName))
        {
            KoreSimFactory.Instance.EventDriver.SetPlatformPosition(msg.PlatName, msg.Pos);
            KoreSimFactory.Instance.EventDriver.SetPlatformCourse(msg.PlatName, msg.Course);
            KoreSimFactory.Instance.EventDriver.SetPlatformAttitude(msg.PlatName, msg.Attitude);
        }
    }
}

