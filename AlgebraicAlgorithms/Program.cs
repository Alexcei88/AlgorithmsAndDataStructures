using System;
using ConsoleTester.Problems.Fibonacci;

namespace ConsoleTester
{
    static class Program
    {
        static void Main(string[] args)
        {
            IProblem problem = new GoldenRationFibonacci();
            var tester = new Tester(problem,
                @"4.Fibo\");
            tester.RunTests();
            
            Console.WriteLine("\nPress key to exit");
            Console.ReadKey();
        }
    }
}