using System;

namespace ConsoleTester.Problems.Primes
{
    public class EratosphenNLogLogNMemoryOptimizedPrimes
        : IProblem
    {
        public string Solve(string[] input)
        {
            ulong N = ulong.Parse(input[0]);
            ulong count = 0;
            ulong sqrt = (ulong) Math.Sqrt(N);
            
            var isSimpleNumbers = new byte[(N >> 3) + 1];
            for (ulong p = 2; p <= N; ++p)
            {
                var index = p >> 3;
                int bitNumber = (int) (p % 8);
                var bit = isSimpleNumbers[index] & (1 << bitNumber);
                if (bit == 0)
                {
                    ++count;
                    if( p <= sqrt)
                        for (ulong j = p * p; j <= N; j += p)
                        {
                            index = j >> 3;
                            bitNumber = (int) (j % 8);
                            isSimpleNumbers[index] |= (byte)(1 << bitNumber);
                        }
                            
                }
            }
            return count.ToString();
        }
        
    }
}