﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using ConsoleTester.Problems;

namespace ConsoleTester
{
    static class Program
    {
        private static string _inputFile = "1.bin";
        static void Main(string[] args)
        {
            var tempFile = Path.GetTempFileName();

            try
            {
                var problems = new List<ISortFromFileProblem>
                {
                    new MergeFromFileWithHeapSortProblem(_inputFile, tempFile),
                    new MergeFromFileProblem(_inputFile, tempFile),
                    new BucketSortProblem(_inputFile, tempFile)
                };

                foreach (var problem in problems)
                {
                    Console.WriteLine($"================ {problem.GetType().Name} ======================");
                    Stopwatch watch = Stopwatch.StartNew();
                    problem.Sort();
                    watch.Stop();
                    Console.WriteLine($"Sort {problem.GetType().Name}: Hash {CalculateMD5(tempFile)} - {watch.ElapsedMilliseconds} ms");
                }

                Console.WriteLine("\nPress key to exit");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                // ignored
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        private static string CalculateMD5(string path)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(path))
                {
                    var hash = md5.ComputeHash(stream);
                    return Convert.ToBase64String(hash);
                }
            }
        }
    }
}