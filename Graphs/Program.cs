using System;
using ConsoleTester.Problems;

namespace ConsoleTester
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("############ Recursive Kosaraju #####################");
            IProblem problem = new KosarajuWithRecursiveDFS();
            var tester = new Tester(problem,
                @"Kosaraju\");
            tester.RunTests();

            // Console.WriteLine("############ Iterative Kosaraju #####################");
            // IProblem problem2 = new KosarajuWithIterativeDFS();
            // var tester2 = new Tester(problem2,
            //     @"Kosaraju\");
            // tester2.RunTests();
            
            Console.WriteLine("############ Demukrona #####################");
            IProblem problem3 = new DemukronaProblem();
            var tester3 = new Tester(problem3,
                 @"Demukrona\");
            tester3.RunTests();


            Console.WriteLine("\nPress key to exit");
            Console.ReadKey();
        }

    }
}