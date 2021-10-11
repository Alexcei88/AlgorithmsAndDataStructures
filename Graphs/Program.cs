using System;
using ConsoleTester.Problems;

namespace ConsoleTester
{
    static class Program
    {
        static void Main(string[] args)
        {
            IProblem problem = new RecursiveKosaraju();
            var tester = new Tester(problem,
                @"Kosaraju\");
            tester.RunTests();
            
            Console.WriteLine("\nPress key to exit");
            Console.ReadKey();
        }

    }
}