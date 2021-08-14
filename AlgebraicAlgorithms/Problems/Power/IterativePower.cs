using System.Globalization;

namespace ConsoleTester.Problems.Power
{
    public class IterativePower
        : IProblem
    {
        public string Solve(string[] input)
        {
            double A = double.Parse(input[0], CultureInfo.InvariantCulture);
            long N = long.Parse(input[1]);

            double p = 1;
            for (long i = 1; i <= N; ++i)
                p *= A;

            return p.ToString();
        }
    }
}