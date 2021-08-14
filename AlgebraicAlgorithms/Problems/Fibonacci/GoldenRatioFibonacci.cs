using System;
using Deveel.Math;
using BigInteger = System.Numerics.BigInteger;

namespace ConsoleTester.Problems.Fibonacci
{
    public class GoldenRationFibonacci
        : IProblem
    {
        public string Solve(string[] input)
        {
            long N = long.Parse(input[0]);
            if (N < 2)
                return N.ToString();

            double r = Math.Sqrt(5);
            BigDecimal p1 = new BigDecimal((1 + r) / 2.0);
            BigDecimal p2 = new BigDecimal((1 - r) / 2.0);

            BigDecimal res1 = Power(p1, N);
            BigDecimal res2 = Power(p2, N);

            BigDecimal bigR = Math.Sqrt(5);
            BigDecimal res = (res1 - res2) / bigR;
            return res.ToString();
        }

        private BigDecimal Power(BigDecimal p, long n)
        {
            BigDecimal res = 1;
            BigDecimal powP = p;
            while (n > 0)
            {
                long bit = n & 1;
                if (bit == 1)
                {
                    res *= powP;
                }
                powP *= powP;
                n = n >> 1;
            }

            return res;
        }
    }
}