
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
}




