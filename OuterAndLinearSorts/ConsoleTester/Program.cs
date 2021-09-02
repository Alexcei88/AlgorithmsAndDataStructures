using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using ConsoleTester.Problems;
using ConsoleTester.Sorts;

namespace ConsoleTester
{
    static class Program
    {
        static void Main(string[] args)
        {
            var inputArray = ReadArrayFromBinaryFile("1.bin");

            var sorts = new List<ISort>
            {
                new MergeSort(),
                new MergeWithHeapSort(),
                new BucketSort()
            };

            foreach (var sort in sorts)
            {
                Console.WriteLine($"================ {sort.GetType().Name} ======================");
                Stopwatch watch = Stopwatch.StartNew();
                sort.Sort(inputArray);
                watch.Stop();
                Console.WriteLine($"Sort {sort.GetType().Name} - {watch.ElapsedMilliseconds} ms");
            }
            
            Console.WriteLine("\nPress key to exit");
            Console.ReadKey();
        }

        private static ushort[] ReadArrayFromBinaryFile(string path)
        {
            List<ushort> array = new List<ushort>();
            using var reader = new BinaryReader(File.Open(path, FileMode.Open));
            while (reader.PeekChar() > -1)
            {
                ushort number = reader.ReadUInt16();
                array.Add(number);
            }

            return array.ToArray();
        }
    }
}