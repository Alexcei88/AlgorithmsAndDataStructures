using System;

namespace ConsoleTester.Problems.Primes
{
    public class OptimizedBruteForcePrimes
        : IProblem
    {
        
        public string Solve(string[] input)
        {
            ulong N = ulong.Parse(input[0]);

            ulong count = 0;
            for(ulong j = 2; j <= N; ++j)
                if (IsPrime(j))
                    ++count;

            return count.ToString();
        }


        private bool IsPrime(ulong p)
        {
            ulong sqrt = (ulong)Math.Sqrt(p);
            
            for(ulong i = 2; i <= sqrt; ++i)
                if (p % i == 0)
                    return false;

            return true;
        }
    }
}