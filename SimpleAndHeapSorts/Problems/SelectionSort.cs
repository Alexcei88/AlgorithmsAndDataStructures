using System;
using System.Linq;

namespace ConsoleTester.Problems
{
    public class SelectionSort
        : IProblem
    {
        private long[] _array;
        public string Solve(string[] input)
        {
            int n = Int32.Parse(input[0]);
            _array = input[1].Split(' ').Select(long.Parse).ToArray();

            MoveMaxToRoot(0, _array.Length);
            for (int i = _array.Length - 1; i >= 0; --i)
            {
                Swap(0, i);
                MoveMaxToRoot(0, i);
            }
            return string.Join(' ', _array.Select(g => g.ToString()));
        }

        private void MoveMaxToRoot(int root, int size)
        {
            for(int i = 0; i < size; ++i)
                if(_array[root] < _array[i])
                    Swap(root, i);
        }

        private void Swap(int i, int j)
        {
            long temp = _array[j];
            _array[j] = _array[i];
            _array[i] = temp;
        }
    }
}