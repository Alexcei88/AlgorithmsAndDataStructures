using System;
using System.Threading;
using ConsoleTester.Trees;

namespace ConsoleTester
{
    static class Program
    {
        private static int N = (int) Math.Pow(10, 6);

        static void Main(string[] args)
        {
            var stackSize = Int32.MaxValue;
            Thread thread = new Thread(RunExperiments, stackSize);
            thread.Start();
            thread.Join();

            Console.WriteLine("\nPress key to exit");
            Console.ReadKey();
        }

        private static void RunExperiments()
        {
            Console.WriteLine("========== Binary search tree experiments ============");
            var experiment1 = new BSTWithRandomNumbersExperiment(new BinarySearchTree(), N);
            experiment1.Insert();
            experiment1.Search();
            experiment1.Remove();
            
            var experiment2 = new BSTWithSequentialNumbersExperiment(new BinarySearchTree(), N);
            experiment2.Insert();
            experiment2.Search();
            experiment2.Remove();
            
            Console.WriteLine("=============== AVL tree experiments ==================");
            var experiment3 = new BSTWithRandomNumbersExperiment(new AVLTree(), N);
            experiment3.Insert();
            experiment3.Search();
            experiment3.Remove();
            
            var experiment4 = new BSTWithSequentialNumbersExperiment(new AVLTree(), N);
            experiment4.Insert();
            experiment4.Search();
            experiment4.Remove();
            
            Console.WriteLine("=============== Random tree experiments ==================");
            var experiment5 = new BSTWithRandomNumbersExperiment(new RandomSearchTree(), N);
            experiment5.Insert();
            experiment5.Search();
            experiment5.Remove();
            
            var experiment6 = new BSTWithSequentialNumbersExperiment(new RandomSearchTree(), N);
            experiment6.Insert();
            experiment6.Search();
            experiment6.Remove();

            Console.WriteLine("=============== B-tree experiments ==================");
            var experiment7 = new BSTWithRandomNumbersExperiment(new BTree(20), N);
            experiment7.Insert();
            experiment7.Search();
            experiment7.Remove();
            
            var experiment8 = new BSTWithSequentialNumbersExperiment(new BTree(20), N);
            experiment8.Insert();
            experiment8.Search();
            experiment8.Remove();
        }
    }
}