using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ConsoleTester
{
    public class Tester
    {
        private IProblem _problem;
        private string _path;

        public Tester(IProblem problem, string path)
        {
            _path = path;
            _problem = problem;
        }

        public void RunTests()
        {
            int nr = 0;
            do
            {
                string inFile = Path.Join(_path, $"test.{nr}.in");
                string outFile = Path.Join(_path, $"test.{nr}.out");
                if(!File.Exists(inFile) || !File.Exists(outFile))
                    break;

                Stopwatch watch = Stopwatch.StartNew();
                bool result = RunTest(inFile, outFile);
                watch.Stop();
                
                Console.WriteLine($"Test #{nr} {result} {watch.ElapsedMilliseconds} ms");                
            } while (++nr > 0);

        }

        private bool RunTest(string inFile, string outFile)
        {
            try
            {
                var expect = File.ReadAllLines(outFile).Select(g => g.Trim());
                var actual = _problem.Solve(File.ReadAllLines(inFile)).Select(g => g.Trim());
                return Enumerable.SequenceEqual(expect, actual);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}