using System.Collections.Generic;

namespace ConsoleTester.Problems.Primes
{
    public class EratosphenSuperOptimizedPrimes
        : IProblem
    {
        public string Solve(string[] input)
        {
            ulong N = ulong.Parse(input[0]);

            var lp = new ulong[N + 1];
            var pr = new List<ulong>();
            for (ulong i = 2; i <= N; ++i)
            {
                if (lp[i] == 0)
                {
                    lp[i] = i;
                    pr.Add(i);
                }

                for (int j = 0; j < pr.Count; ++j)
                {
                    ulong p = pr[j];
                    if (p > lp[i] || p * i > N)
                        break;
                    lp[p * i] = p;
                }
            }

            return pr.Count.ToString();
        }
    }
}