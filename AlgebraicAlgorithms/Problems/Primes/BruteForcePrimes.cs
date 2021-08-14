
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;

namespace ConsoleTester.Problems.Fibonacci
{
    public class BruteForcePrimes
        : IProblem
    {
        private readonly Dictionary<BigInteger, BigInteger> _fibonacciCache = new();
        private BigInteger _N;
        private BigInteger _result;
        public string Solve(string[] input)
        {
            _fibonacciCache.Clear();            
            _N = BigInteger.Parse(input[0]);
            
            var stackSize = Int32.MaxValue;
            Thread thread = new Thread(new ThreadStart(Calculate), stackSize);
            thread.Start();
            thread.Join();
            return _result.ToString();
        }

        private void Calculate()
        {
            _result = CalculateFibonacci(_N);
        }
        private BigInteger CalculateFibonacci(BigInteger n)
        {
            if (n < 2)
                return n;

            if (_fibonacciCache.ContainsKey(n))
                return _fibonacciCache[n];

            var n1 = CalculateFibonacci(n - 1);
            var n2 = CalculateFibonacci(n - 2);
            _fibonacciCache[n - 1] = n1;
            _fibonacciCache[n - 2] = n2;
            return n1 + n2;
        }
    }
}