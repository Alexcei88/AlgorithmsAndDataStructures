using System.Globalization;

namespace ConsoleTester.Problems.Power
{
    public class PowerOfTwo
        : IProblem
    {
        public double Solve(string[] input)
        {
            double A = double.Parse(input[0], CultureInfo.InvariantCulture);
            long N = long.Parse(input[1]);
            
            double p = 1;
            double powA = A;
            while (N > 0)
            {
                long bit = N & 1;
                if (bit == 1)
                {
                    p *= powA;
                }
                powA *= powA;
                N = N >> 1;
            }
            
            return p;
        }
    }
}