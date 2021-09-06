using System;
using System.Linq;

namespace ConsoleTester.Problems
{
    public class HeapSort
        : IProblem
    {
        private long[] _array;
        public string Solve(string[] input)
        {
            int n = Int32.Parse(input[0]);
            _array = input[1].Split(' ').Select(long.Parse).ToArray();
            if (n != _array.Length)
                throw new Exception("Наш тестер читает непрально");
                
            for(int root = _array.Length / 2 - 1; root >= 0; --root)
                Heapify(root, _array.Length);
            
            for (int j = _array.Length - 1; j >= 0; --j)
            {
                Swap(0, j);
                Heapify(0, j);
            }
            
            return string.Join(' ', _array.Select(g => g.ToString()));
        }

        private void Heapify(int root, int size)
        {
            int L = 2 * root + 1;
            int R = 2 * root + 2;
            int X = root;
            if (L < size && _array[L] > _array[X]) X = L;
            if (R < size && _array[R] > _array[X]) X = R;
            if (X == root) return;
            
            Swap(root, X);
            Heapify(X, size);
        }

        private void Swap(int x, int y)
        {
            long tmp = _array[x];
            _array[x] = _array[y];
            _array[y] = tmp;
        }
    }
}