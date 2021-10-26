using System;
using ConsoleTester.Problems;

namespace ConsoleTester
{
    static class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("############ Recursive Kosaraju #####################");
            // IProblem problem = new KosarajuWithRecursiveDFS();
            // var tester = new Tester(problem,
            //     @"Kosaraju\");
            // tester.RunTests();
            //
            // Console.WriteLine("############ Demukrona #####################");
            // IProblem problem3 = new DemukronaProblem();
            // var tester3 = new Tester(problem3,
            //      @"Demukrona\");
            // tester3.RunTests();
            //
            // Console.WriteLine("############ Tarjyana #####################");
            // IProblem problem4 = new TarjyanaProblem();
            // var tester4 = new Tester(problem4,
            //     @"Tarjyana\");
            // tester4.RunTests();

            // Console.WriteLine("############ Krascala #####################");
            // IProblem problem5 = new KrascalaProblem();
            // var tester5 = new Tester(problem5,
            //     @"Krascala\");
            // tester5.RunTests();
            //
            // Console.WriteLine("############ Boruvka #####################");
            // IProblem problem6 = new BoruvkaProblem();
            // var tester6 = new Tester(problem6,
            //     @"Boruvka\");
            // tester6.RunTests();

            Console.WriteLine("############ Dijkstra #####################");
            IProblem problem7 = new DijkstraProblem();
            var tester7 = new Tester(problem7,
                @"Dijkstra\");
            tester7.RunTests();

            Console.WriteLine("\nPress key to exit");
            Console.ReadKey();
        }

    }
}