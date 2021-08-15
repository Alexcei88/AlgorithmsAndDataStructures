using System;

namespace ConsoleTester.Problems.Primes
{
    public class EratosphenNLogLogNPrimes
        : IProblem
    {
        public string Solve(string[] input)
        {
            ulong N = ulong.Parse(input[0]);
            ulong count = 0;
            ulong sqrt = (ulong) Math.Sqrt(N);
            var isSimpleNumbers = new bool[N + 1];
            for (ulong p = 2; p <= N; ++p)
            {
                if (!isSimpleNumbers[p])
                {
                    ++count;
                    if( p <= sqrt)
                        for (ulong j = p * p; j <= N; j += p)
                            isSimpleNumbers[j] = true;
                }
            }
            return count.ToString();
        }
        
    }
}