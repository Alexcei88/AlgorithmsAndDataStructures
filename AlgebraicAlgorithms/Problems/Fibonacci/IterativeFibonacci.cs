
using System.Numerics;

namespace ConsoleTester.Problems.Fibonacci
{
    public class IterativeFibonacci
        : IProblem
    {
        public string Solve(string[] input)
        {
            BigInteger N = BigInteger.Parse(input[0]);
            if (N == 0)
                return 0.ToString();
            
            BigInteger f0 = 0;
            BigInteger f1 = 1;

            for (BigInteger i = 1; i < N; ++i)
            {
                BigInteger f2 = f0 + f1;
                f0 = f1;
                f1 = f2;
            }
            return f1.ToString();
        }
    }
}