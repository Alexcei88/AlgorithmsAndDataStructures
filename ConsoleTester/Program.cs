using System;
using ConsoleTester.Problems;

namespace ConsoleTester
{
    static class Program
    {
        static void Main(string[] args)
        {
            IProblem problem = new LuckyTickets();
            var tester = new Tester(problem,
                @"A01_Счастливые_билеты-1801-057a77\1.Tickets\");
            tester.RunTests();
            
            Console.WriteLine("\nPress key to exit");
            Console.ReadKey();
        }
    }
}