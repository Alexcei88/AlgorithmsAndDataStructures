using System;
using System.Diagnostics;
using ConsoleTester.Problems.Power;

namespace ConsoleTester
{
    static class Program
    {
        static void Main(string[] args)
        {
            IProblem problem = new PowerOfTwo();
            var tester = new Tester(problem,
                @"3.Power\");
            Stopwatch watch = Stopwatch.StartNew();
            tester.RunTests();
            watch.Stop();
            
            watch.Restart();
            
            watch.Stop();
            Console.WriteLine("\nPress key to exit");
            Console.ReadKey();
        }
    }
}