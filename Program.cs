
using System;

using KoreCommon;
using KoreCommon.UnitTest;
using KoreSim.UnitTest;
using KoreSim.SystemTest;

namespace KoreSim;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("KoreSim Application Starting...");

        var app = new KoreSimApplication();
        app.Run();

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

    public void RunInteractive()
    {
        Console.WriteLine("KoreSim interactive console. Type 'exit' to quit.");

        // Create and start KoreConsole
        var koreConsole = new KoreCommon.KoreConsole();
        koreConsole.Start();

        // Wait for console thread to initialize (it sleeps for 1 second on startup)
        System.Threading.Thread.Sleep(1100);

        bool running = true;

        while (running)
        {
            // Display prompt and read user input
            Console.Write("> ");
            string? input = Console.ReadLine();

            // Handle null or empty input
            if (string.IsNullOrWhiteSpace(input))
            {
                continue;
            }

            // Check for exit commands (case-insensitive)
            string trimmedInput = input.Trim();
            if (string.Equals(trimmedInput, "exit", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(trimmedInput, "quit", StringComparison.OrdinalIgnoreCase))
            {
                running = false;
                continue;
            }

            // Send input to KoreConsole for execution
            koreConsole.AddInput(trimmedInput);

            // Give the console thread time to process and flush output
            System.Threading.Thread.Sleep(50);
            
            // Flush and print any output from KoreConsole
            while (koreConsole.HasOutput())
            {
                string output = koreConsole.GetOutput();
                Console.Write(output);
                // Check again in case more output arrived
                System.Threading.Thread.Sleep(25);
            }
        }

        // Flush remaining output
        System.Threading.Thread.Sleep(50);
        while (koreConsole.HasOutput())
        {
            string output = koreConsole.GetOutput();
            Console.Write(output);
        }

        // Stop the console thread
        koreConsole.Stop();

        Console.WriteLine("Exiting interactive console.");
    }
}




