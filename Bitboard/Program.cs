using System;
using ConsoleTester.Problems;

namespace ConsoleTester
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============ Король ============");
            IProblem problem = new KingWalk();
            var tester = new Tester(problem,
                @"BitBoards\1.Bitboard - Король\");
            tester.RunTests();
            
            Console.WriteLine("============ Конь ============");
            problem = new KnightWalk();
            tester = new Tester(problem,
                @"BitBoards\2.Bitboard - Конь\");
            tester.RunTests();

            Console.WriteLine("============ Ладья ============");
            problem = new RookWalk();
            tester = new Tester(problem,
                @"BitBoards\3.Bitboard - Ладья\");
            tester.RunTests();

            Console.WriteLine("============ Слон ============");
            problem = new BishopWalk();
            tester = new Tester(problem,
                @"BitBoards\4.Bitboard - Слон\");
            tester.RunTests();
            
            Console.WriteLine("============ Королева ============");
            problem = new QueenWalk();
            tester = new Tester(problem,
                @"BitBoards\5.Bitboard - Ферзь\");
            tester.RunTests();

            Console.WriteLine("\nPress key to exit");
            Console.ReadKey();
        }
    }
}