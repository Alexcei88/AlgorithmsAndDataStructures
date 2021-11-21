using System;
using System.Diagnostics;
using System.Linq;
using ConsoleTester.Problems;
using NUnit.Framework;

namespace ConsoleTester.Test
{
    [TestFixture(typeof(FindSubStrMachineStateProblem))]
    [TestFixture(typeof(SlowPrefixCalcFindSubStrProblem))]
    [TestFixture(typeof(FastPrefixCalcFindSubStrProblem))]
    [TestFixture(typeof(KnuthMorrisPrattProblem))]
    public class Tests
    {
        private Stopwatch _stopWatch;
        private int _iterationCount = 100000;
        
        [OneTimeSetUp]
        public void Init()
        {
            _stopWatch = Stopwatch.StartNew();   
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            _stopWatch.Stop();
            TestContext.Out.WriteLine("Execution time for {0} - {1} ms",
                TestContext.CurrentContext.Test.Name,
                _stopWatch.ElapsedMilliseconds);
            // ... add your code here
        }
        
        private readonly IProblem _problem;
        
        public Tests(Type problemType)
        {
            _problem = (IProblem)Activator.CreateInstance(problemType);
        }
        
        [Test]
        public void Find_StartPosition_Success()
        {
            for (int i = 0; i < _iterationCount; ++i)
            {
                var positions = _problem.Solve(new[] { "ABCDABCFABRABCFABRABCFABRABCFABRABCFABRABCFABRABCFABRABCFABRABCFABRABCFABRABCFABRABCFABRABCFABRABCFABRABCFABRABCFABRABCFABRABCFABRABCFABR", "ABCD" });
                Assert.IsTrue(Enumerable.SequenceEqual(positions, new[] { 0.ToString() }));
            }
        }
        
        [Test]
        public void Find_EndPosition_Success()
        {
            for (int i = 0; i < _iterationCount; ++i)
            {
                var positions = _problem.Solve(new[] { "ABCDABCFABCDABCFABCDABCFABCDABCFABCDABCFABCDABCFABCDABCFABCDABCFABCDABCFABCDABCFABCDABCFABCDABCFABCDABCFABCDABCFABR", "ABR" });
                Assert.IsTrue(Enumerable.SequenceEqual(positions, new[] { 112.ToString() }));
            }
        }
        
        [Test]
        public void Find_StartPosition_Fail()
        {
            for (int i = 0; i < _iterationCount; ++i)
            {
                var positions = _problem.Solve(new[] { "ABCDABCFABRABCDABCFABRABCDABCFABRABCDABCFABRABCDABCFABRABCDABCFABRABCDABCFABRABCDABCFABRABCDABCFABRABCDABCFABRABCDABCFABRABCDABCFABR", "ABCDD" });
                Assert.IsTrue(Enumerable.SequenceEqual(positions, Array.Empty<string>()));
            }
        }
        
        [Test]
        public void Find_MultiplyPositions_Success()
        {
            for (int i = 0; i < _iterationCount; ++i)
            {
                var positions = _problem.Solve(new[] { "ACDACRACRBACRFAACBRABACRBACRFCRBACRFCRBACRFCRBACRFCRBACRFCRBACRFCRBACRFCRBACRFCRBACRFCRBACRFCRBACRFCRBACRFCRBACRFCRBACRFCRBACRFCRBACRFCRBACRFCRBACRFCRBACRFCRBACRFCRBACRFCRBACRFCRBACRFCRBACRFCRBACRF", "CRACRBACR" });
                Assert.IsTrue(Enumerable.SequenceEqual(positions, new[] { 4.ToString() }));

                positions = _problem.Solve(new[] { "ACDAACBCFAACCRCBCCBCCBCCBCCBCCBCCBCCBCCBCCBCCBCCBCACAC", "AC" });
                Assert.IsTrue(Enumerable.SequenceEqual(positions, new[] { 0.ToString(), 4.ToString(), 10.ToString(), 50.ToString(), 52.ToString()  }));

                positions = _problem.Solve(new[] { "ACDAACBCFAACCRFVGBGHHNNGGFDEDFSSFSFSVSVSVSGSGFCSASABVFSD", "AC" });
                Assert.IsTrue(Enumerable.SequenceEqual(positions, new[] { 0.ToString(), 4.ToString(), 10.ToString() }));
                
                positions = _problem.Solve(new[] { "ABCDAFCDEAFDFSDFSDGDGSSDSGACCDVVFEDDFDFSCDDSSDFABCDEFABCDEFG", "ABCDEF" });
                Assert.IsTrue(Enumerable.SequenceEqual(positions, new[] { 47.ToString(), 53.ToString() }));
            }
        }
        
        [Test]
        public void Find_ManySameSymbols_Success()
        {
            for (int i = 0; i < _iterationCount; ++i)
            {
                var positions = _problem.Solve(new[] { "KOLOLOKOLOKOLOKOL", "KOLOKOL" });
                Assert.IsTrue(Enumerable.SequenceEqual(positions, new[] { 6.ToString(), 10.ToString() }));
            }
        }
    }
}