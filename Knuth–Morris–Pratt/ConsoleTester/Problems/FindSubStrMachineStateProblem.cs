using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTester.Problems
{
    public class FindSubStrMachineStateProblem
        : IProblem
    {
        private readonly char[] alphabet = Enumerable.Range('A', 'z' - 'A' + 1).Select(i => (Char)i).ToArray();
        
        public string[] Solve(string[] input)
        {
            string inputStr = input[0];
            string pattern = input[1];

            List<string> result = new();
            int[,] delta = CreateDelta(pattern);
            int q = 0;
            for (int j = 0; j < inputStr.Length; ++j)
            {
                q = delta[q, inputStr[j] - alphabet[0]];
                if (q == pattern.Length)
                {
                    j = j - pattern.Length + 1;
                    result.Add(j.ToString());
                    q = 0;
                }
            }

            return result.ToArray();
        }

        private int[,] CreateDelta(string pattern)
        {
            int[,] delta = new int[pattern.Length, alphabet.Length];

            for (int q = 0; q < pattern.Length; ++q)
            {
                foreach (var a in alphabet)
                {
                    string line = pattern.Left(q) + a;
                    int k = q + 1;
                    while (pattern.Left(k) != line.Right(k))
                        --k;
                    delta[q, a - alphabet[0]] = k;
                }
            }

            return delta;
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