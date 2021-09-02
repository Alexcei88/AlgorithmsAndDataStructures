using System;
using System.Linq;

namespace ConsoleTester.Problems
{
    public class InsertionSort
        : IProblem
    {
        public string Solve(string[] input)
        {
            int n = Int32.Parse(input[0]);
            long[] array = input[1].Split(' ').Select(long.Parse).ToArray();

            for (int i = 1; i < n; ++i)
            {
                long current = array[i];
                int j = i;
                while (j > 0 && current < array[j - 1])
                {
                    array[j] = array[j - 1];
                    --j;
                }

                array[j] = current;
            }
            
            return string.Join(' ', array.Select(g => g.ToString()));
        }
    }
}