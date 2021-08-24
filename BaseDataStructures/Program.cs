using System;
using System.Collections.Generic;
using System.Diagnostics;
using ConsoleTester.Arrays;

namespace ConsoleTester
{
    static class Program
    {
        static void Main(string[] args)
        {
            List<int> counts = new List<int>()
            {
                // 1000,
                // 100000,
                // 1000000,
                10000000,
            };

            Console.WriteLine("Add()");
            foreach (var count in counts)
            {
                foreach (var arr in new List<IArray<int>>
                {
                    // new FactorArray<int>(),
                    // new MatrixArray<int>(200),
                    // new SingleArray<int>(),
                    // new VectorArray<int>(200),
//                    new ListArray<int>()
                })
                {
                    AddManyElsToArray(arr, count);
                }
            }

            Console.WriteLine("AddRemove(index)");
            foreach (var count in counts)
            {
                foreach (var arr in new List<IArray<int>>
                {
                    // new FactorArray<int>(),
                    // new MatrixArray<int>(200),
                    // new SingleArray<int>(),
                    // new VectorArray<int>(200),
                    new ListArray<int>()
                })
                {
                    AddManyElsToStartPositionToArray(arr, count);
                    RemoveManyElsFromArray(arr, count);
                }
            }
            
            

            Console.WriteLine("\nPress key to exit");
            Console.ReadKey();
        }

        private static void AddManyElsToArray(IArray<int> arr, int count)
        {
            Stopwatch watch = Stopwatch.StartNew();
            var random = new Random();
            for (int i = 0; i < count; ++i)
                arr.Add(random.Next());

            watch.Stop();
            Console.WriteLine(
                $"Время вставки {count} элементов в массив {arr.GetType()}: {watch.ElapsedMilliseconds} ms");
        }

        private static void AddManyElsToStartPositionToArray(IArray<int> arr, int count)
        {
            Stopwatch watch = Stopwatch.StartNew();
            var random = new Random();
            for (int i = 0; i < count; ++i)
                arr.Add(random.Next(), 0);

            watch.Stop();
            Console.WriteLine(
                $"Время вставки {count} элементов в массив {arr.GetType()}: {watch.ElapsedMilliseconds} ms");
        }
        private static void RemoveManyElsFromArray(IArray<int> arr, int count)
        {
            Stopwatch watch = Stopwatch.StartNew();
            for (int i = 0; i < count; ++i)
                arr.Remove(0);

            watch.Stop();
            Console.WriteLine(
                $"Время удаления {count} элементов в массив {arr.GetType()}: {watch.ElapsedMilliseconds} ms");
        }
    }
}