namespace ConsoleTester.Problems
{
    public class StringLength
        : IProblem
    {
        public string Solve(string[] input)
        {
            return input[0].Length.ToString();
        }
    }
}