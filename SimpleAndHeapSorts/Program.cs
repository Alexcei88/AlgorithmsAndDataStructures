using System;
using ConsoleTester.Problems;

namespace ConsoleTester
{
    static class Program
    {
        static void Main(string[] args)
        {
            var data = new[]
            {
                "0.random", 
                "1.digits", 
                "2.sorted", 
                // "3.revers"
            };

            // Console.WriteLine("================ InsertionSort ======================");
            // IProblem insertionSort = new InsertionSort();
            // foreach (var d in data)
            // {
            //     var tester = new Tester(insertionSort, 
            //         $@"sorting-tests\{d}\");
            //     tester.RunTests();
            // }
            
            Console.WriteLine("================ SelectionSort ======================");
            IProblem selectionSort = new SelectionSort();
            foreach (var d in data)
            {
                var tester = new Tester(selectionSort, 
                    $@"sorting-tests\{d}\");
                tester.RunTests();
            }

            Console.WriteLine("================ ShellSort1 ======================");
            IProblem shellSort1 = new ShellSort((i, n) => n / (int)Math.Pow(2, i));
            foreach (var d in data)
            {
                var tester = new Tester(shellSort1, 
                    $@"sorting-tests\{d}\");
                tester.RunTests();
            }

            // Console.WriteLine("================ ShellSort2 ======================");
            // IProblem shellSort2 = new ShellSort((i, n) => i % 2 == 0
            //     // ReSharper disable once PossibleLossOfFraction
            //     ? 9 * (int) Math.Pow(2, i) - 9 * (int) Math.Pow(2, i / 2) + 1
            //     // ReSharper disable once PossibleLossOfFraction
            //     : 8 * (int) Math.Pow(2, i) - 6 * (int) Math.Pow(2, (i + 1) / 2) + 1);
            // foreach (var d in data)
            // {
            //     var tester = new Tester(shellSort2,
            //         $@"sorting-tests\{d}\");
            //     tester.RunTests();
            // }
            
            Console.WriteLine("================ HeapSort ======================");
            IProblem heapSort = new HeapSort();
            foreach (var d in data)
            {
                var tester = new Tester(heapSort, 
                    $@"sorting-tests\{d}\");
                tester.RunTests();
            }

            Console.WriteLine("\nPress key to exit");
            Console.ReadKey();
        }
    }
}