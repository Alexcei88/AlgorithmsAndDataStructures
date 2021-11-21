using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTester.Problems
{
    public class SlowPrefixCalcFindSubStrProblem
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
            for (int q = 1; q <= pattern.Length; ++q)
            {
                string line = pattern.Left(q);
                for(int len = 1; len < q; ++len)
                    if (line.Left(len) == line.Right(len))
                        pi[q] = len;
            }

            return pi;
        }
    }
}