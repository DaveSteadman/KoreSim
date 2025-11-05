
using System;

using KoreCommon;
using KoreCommon.UnitTest;
using KoreSim;
using KoreSim.UnitTest;
using KoreSim.SystemTest;

namespace KoreSim;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("KoreSim Application Starting...");

        var app = new KoreSimApplication();
        // app.Run();
        app.RunInteractive();

        Console.WriteLine("Application completed.");
    }
}

public class KoreSimApplication
{
    public void Run()
    {
        Console.WriteLine("Running KoreSim tests...");

        var testLog = new KoreTestLog();

        // Run unit tests
        Console.WriteLine("Running unit tests...");
        KoreSimUnitTestCenter.RunAllTests(testLog);

        // Run system tests
        Console.WriteLine("Running system tests...");
        KoreSimSystemTestCenter.RunAllTests(testLog);

        string fullReport = testLog.FullReport();
        string failReport = testLog.FailReport();

        Console.WriteLine("Full Test Report:");
        Console.WriteLine(fullReport);

        Console.WriteLine("All tests completed.");
    }

    // Run a loop to read command lines, feeding them to the CLI and
    // printing responses
    public void RunInteractive()
    {
        KoreSimFactory.TriggerInstance();

        bool loopValid = KoreSimFactory.Instance.ConsoleInterface.IsRunning();

        Console.WriteLine("Interactive mode started. Type 'help' for commands or 'exit' to quit.");

        while (loopValid)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();
            // Process the input and provide feedback

            if (!string.IsNullOrEmpty(input))
            {
                (bool success, string response) = KoreSimFactory.Instance.ConsoleInterface.RunSingleCommand(input);
                Console.WriteLine(response);
            }
            loopValid = KoreSimFactory.Instance.ConsoleInterface.IsRunning();
        }

        Console.WriteLine("Interactive mode ended.");
    }
}




