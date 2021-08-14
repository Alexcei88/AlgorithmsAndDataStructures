using System.Globalization;

namespace ConsoleTester.Problems.Power
{
    public class IterativePowerApproach
        : IProblem
    {
        public double Solve(string[] input)
        {
            double A = double.Parse(input[0], CultureInfo.InvariantCulture);
            long N = long.Parse(input[1]);

            double p = 1;
            for (long i = 1; i <= N; ++i)
                p *= A;

            return p;
        }
    }
}