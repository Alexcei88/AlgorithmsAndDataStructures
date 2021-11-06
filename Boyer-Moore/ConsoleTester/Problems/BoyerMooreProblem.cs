using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTester.Problems
{
    public class BoyerMooreProblem
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
            int[] badShift = CreateBadShift(pattern);
            int[] goodShift = CreateGoodShift(pattern);

            int position = 0;
            while (position <= inputStr.Length - pattern.Length)
            {
                int p = pattern.Length - 1;
                int suffixLen = 0;
                while (p >= 0 && inputStr[position + p] == pattern[p])
                {
                    --p;
                    ++suffixLen;
                }

                if (p < 0)
                    yield return position;

                if (suffixLen > 0)
                {
                    var shift = Math.Max(badShift[inputStr[position + pattern.Length - 1]], goodShift[suffixLen - 1]);
                    position += shift;
                }
                else
                {
                    position += badShift[inputStr[position + pattern.Length - 1]];
                }
            }
        }

        private int[] CreateGoodShift(string pattern)
        {
            int[] shift = new int[pattern.Length];
            int lastPrefixPosition = pattern.Length;
            for (int i = pattern.Length - 1; i >= 0; --i)
            {
                if (IsPrefix(pattern, i))
                    lastPrefixPosition = i;

                shift[pattern.Length - 1 - i] = lastPrefixPosition;
            }

            for (int i = 0; i < pattern.Length - 1; ++i)
            {
                int slen = SuffixLength(pattern, i);
                shift[slen] = pattern.Length - 1 - i;
            }
            
            return shift;
        }

        //Функция, проверяющая, что подстрока x[p…m−1] является префиксом шаблона x
        private bool IsPrefix(string pattern, int pos)
        {
            int j = 0;
            for (int i = pos; i < pattern.Length; ++i)
            {
                if (pattern[i] != pattern[j])
                    return false;
                ++j;
            }

            return true;
        }
        
        //Функция, возвращающая для позиции p длину максимальной подстроки, которая является суффиксом шаблона x
        private int SuffixLength(string pattern, int pos)
        {
            int len = 0;
            int j = pattern.Length - 1;
            while (pos != 0 && pattern[--pos] == pattern[--j])
                ++len;

            return len;
        }

        private int[] CreateBadShift(string pattern)
        {
            int[] shift = new int[128]; // for all ASCII symbols
            Array.Fill(shift, pattern.Length);
            for (int i = 0; i < pattern.Length - 1; ++i)
                shift[pattern[i]] = pattern.Length - i - 1;

            return shift;
        }
    }
}