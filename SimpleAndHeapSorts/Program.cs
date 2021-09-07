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
                "3.revers"
            };

            Console.WriteLine("================ InsertionSort ======================");
            IProblem insertionSort = new InsertionSort();
            foreach (var d in data)
            {
                var tester = new Tester(insertionSort, 
                    $@"sorting-tests\{d}\");
                tester.RunTests();
            }
            
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
            
            Console.WriteLine("================ ShellSort2 ======================");
            IProblem shellSort2 = new ShellSort((i, n) =>
            {
                if (i > Math.Log2(n))
                    return 0;
                return 2 * (n / (int) Math.Pow(2, i + 1)) + 1;
            });
            foreach (var d in data)
            {
                var tester = new Tester(shellSort2,
                    $@"sorting-tests\{d}\");
                tester.RunTests();
            }
             
            Console.WriteLine("================ ShellSort3 ======================");
            IProblem shellSort3 = new ShellSort((i, n) =>
            {
                int maxGap = (int)Math.Log2(n >> 3);
                if (maxGap < 1)
                    maxGap = 1;
                int k = maxGap - (i - 1);
                if (k % 2 == 0)
                {
                    return 9 * ((int) Math.Pow(2, k) - (int) Math.Pow(2, k >> 1)) + 1;
                }

                return 8 * (int) Math.Pow(2, k) - 6 * (int) Math.Pow(2, (k + 1) >> 1) + 1;
            });
            foreach (var d in data)
            {
                var tester = new Tester(shellSort3,
                    $@"sorting-tests\{d}\");
                tester.RunTests();
            }
            
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