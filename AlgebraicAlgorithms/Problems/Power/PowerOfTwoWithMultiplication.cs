using System.Globalization;

namespace ConsoleTester.Problems.Power
{
    public class PowerOfTwoWithMultiplication
        : IProblem
    {
        public double Solve(string[] input)
        {
            double A = double.Parse(input[0], CultureInfo.InvariantCulture);
            long N = long.Parse(input[1]);
            if (N == 0)
                return 1;
            
            double p = A;
            long currentN = 1;
            while (currentN * 2 <= N)
            {
                p *= p;
                currentN *= 2;
            }
            
            for (long i = currentN; i < N; ++i)
                p *= A;
            
            return p;
        }
    }
}