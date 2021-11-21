using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTester.Problems
{
    public class FastPrefixCalcFindSubStrProblem
        : IProblem
    {
        public string[] Solve(string[] input)
        {
            string inputStr = input[0];
            string pattern = input[1];

            int[] pi = CreatePiSlow(pattern);
            List<string> result = new List<string>();

            int q = 0;
            for (int j = 0; j < inputStr.Length; ++j)
            {
                if (inputStr[j] == pattern[q])
                {
                    ++q;
                    if (q == pattern.Length)
                    {
                        result.Add((j - pattern.Length + 1).ToString());

                        q = pi[q];
                        if (inputStr[j] == pattern[q])
                            ++q;
                    }
                }
                else
                {
                    q = pi[q];
                    if (inputStr[j] == pattern[q])
                        ++q;
                }
            }

            return result.ToArray();
        }

        private int[] CreatePiSlow(string pattern)
        {
            int[] pi = new int[pattern.Length + 1];
            pi[1] = 0;
            for (int q = 1; q < pattern.Length; ++q)
            {
                int len = pi[q];
                while (len > 0 && pattern[len] != pattern[q])
                    len = pi[len];

                if (pattern[len] == pattern[q])
                    ++len;

                pi[q + 1] = len;
            }

            return pi;
        }
    }
}