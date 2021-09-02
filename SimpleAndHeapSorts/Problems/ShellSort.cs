using System;
using System.Linq;

namespace ConsoleTester.Problems
{
    public class ShellSort
        : IProblem
    {
        private long[] _array;
        private Func<int, int, int> _gapFunc;


        public ShellSort(Func<int, int, int> gapFunc)
        {
            _gapFunc = gapFunc;
        }
        public string Solve(string[] input)
        {
            int n = Int32.Parse(input[0]);
            _array = input[1].Split(' ').Select(long.Parse).ToArray();

            for (int it = 1;; ++it)
            {
                int gap = _gapFunc(it, n);
                if(gap <= 0)
                    break;
                for (int i = gap; i < _array.Length; i += gap)
                {
                    int j = i;
                    long current = _array[i];
                    while (j > 0 && current < _array[j - gap])
                    {
                        _array[j] = _array[j - gap];
                        j -= gap;
                    }

                    _array[j] = current;
                }
            }
            
            return string.Join(' ', _array.Select(g => g.ToString()));
        }
    }
}