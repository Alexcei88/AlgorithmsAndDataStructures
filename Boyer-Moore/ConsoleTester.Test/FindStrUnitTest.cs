using System;
using System.Linq;
using ConsoleTester.Problems;
using NUnit.Framework;

namespace ConsoleTester.Test
{
    [TestFixture(typeof(BruteForceFindSubStrProblem))]
    [TestFixture(typeof(PrefixOffsetFindSubStrProblem))]
    [TestFixture(typeof(SuffixOffsetFindSubStrProblem))]
    public class Tests
    {
        private readonly IProblem _problem;
        
        public Tests(Type problemType)
        {
            _problem = (IProblem)Activator.CreateInstance(problemType);
        }
        
        [Test]
        public void Find_StartPosition_Success()
        {
            var positions = _problem.Solve(new[] { "ABCDABCFABR", "ABCD" });
            Assert.IsTrue(Enumerable.SequenceEqual(positions, new[]{ 0.ToString() }));
        }
        
        [Test]
        public void Find_EndPosition_Success()
        {
            var positions = _problem.Solve(new[] { "ABCDABCFABR", "ABR" });
            Assert.IsTrue(Enumerable.SequenceEqual(positions, new[]{ 8.ToString() }));
        }
        
        [Test]
        public void Find_StartPosition_Fail()
        {
            var positions = _problem.Solve(new[] { "ABCDABCFABR", "ABCDD" });
            Assert.IsTrue(Enumerable.SequenceEqual(positions, Array.Empty<string>()));
        }
        
        [Test]
        public void Find_MultiplyPositions_Success()
        {
            var positions = _problem.Solve(new[] { "ACDAACBCFAACCR", "AC" });
            Assert.IsTrue(Enumerable.SequenceEqual(positions, new[]{ 0.ToString(), 4.ToString(), 10.ToString() }));
            
            positions = _problem.Solve(new[] { "ABCDAFCDEABCDEFABCDEFG", "ABCDEF" });
            Assert.IsTrue(Enumerable.SequenceEqual(positions, new[]{ 9.ToString(), 15.ToString() }));

        }
        
        [Test]
        public void Find_ManySameSymbols_Success()
        {
            var positions = _problem.Solve(new[] { ".KOLOLOKOLOKOLOKOL", "KOLOKOL" });
            Assert.IsTrue(Enumerable.SequenceEqual(positions, new[]{ 7.ToString(), 11.ToString() }));
        }

    }
}