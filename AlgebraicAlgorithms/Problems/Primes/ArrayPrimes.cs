using System;

namespace ConsoleTester.Problems.Primes
{
    public class ArrayPrimes
        : IProblem
    {
        
        public string Solve(string[] input)
        {
            ulong N = ulong.Parse(input[0]);
            if (N < 2)
                return 0.ToString();

            var primes = new ulong[N];
            ulong count = 0;
            primes[count++] = 2;
            for(ulong j = 3; j <= N; j += 2)
                if (IsPrime(j, primes))
                    primes[count++] = j;

            return count.ToString();
        }
        
        private bool IsPrime(ulong p, ulong[] primes)
        {
            ulong sqrt = (ulong)Math.Sqrt(p);
            
            for(ulong i = 0; primes[i] <= sqrt; ++i)
                if (p % primes[i] == 0)
                    return false;

            return true;
        }
    }
}