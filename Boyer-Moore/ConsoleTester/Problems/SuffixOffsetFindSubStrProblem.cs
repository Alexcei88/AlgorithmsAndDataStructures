using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTester.Problems
{
    public class SuffixOffsetFindSubStrProblem
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
            int[] shift = CreateShift(pattern);
            
            int position = 0;
            while (position <= inputStr.Length - pattern.Length)
            {
                int p = pattern.Length - 1;
                while (p >= 0 && inputStr[position + p] == pattern[p])
                    --p;

                if (p < 0)
                    yield return position;

                position += shift[inputStr[position + pattern.Length - 1]];
            }
        }

        private int[] CreateShift(string pattern)
        {
            int[] shift = new int[128]; // for all ASCII symbols
            Array.Fill(shift, pattern.Length);
            for(int i = 0; i < pattern.Length - 1; ++i)
                shift[pattern[i]] = pattern.Length - i - 1;
            
            return shift;
        }
    }
}