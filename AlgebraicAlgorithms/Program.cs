using System;
using ConsoleTester.Problems.Primes;

namespace ConsoleTester
{
    static class Program
    {
        static void Main(string[] args)
        {
            IProblem problem = new EratosphenNLogLogNMemoryOptimizedPrimes();
            var tester = new Tester(problem,
                @"5.Primes\");
            tester.RunTests();
            
            Console.WriteLine("\nPress key to exit");
            Console.ReadKey();
        }
    }
}