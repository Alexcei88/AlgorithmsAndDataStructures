using System.Collections.Generic;
using System.Linq;

namespace ConsoleTester.Problems
{
    public class BruteForceFindSubStrProblem
        : IProblem
    {
        public string[] Solve(string[] input)
        {
            string inputStr = input[0];
            string pattern = input[1];

            return FindSubstr(inputStr, pattern).Select(g => g.ToString()).ToArray();
        }

        private IEnumerable<int> FindSubstr(string inputStr, string pattern)
        {
            int position = 0;
            while (position <= inputStr.Length - pattern.Length)
            {
                int p = 0;
                while (p < pattern.Length && inputStr[position + p] == pattern[p])
                    ++p;

                if (p == pattern.Length)
                    yield return position;
                
                ++position;
            }
        }
        
    }
}