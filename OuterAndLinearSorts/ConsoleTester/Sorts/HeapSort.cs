namespace ConsoleTester.Sorts
{
    public class HeapSort
        : ISort
    {
        private ushort[] _array;
        
        public ushort[] Sort(ushort[] input)
        {
            _array = input;     
            for(int root = _array.Length / 2 - 1; root >= 0; --root)
                Heapify(root, _array.Length);
            
            for (int j = _array.Length - 1; j >= 0; --j)
            {
                Swap(0, j);
                Heapify(0, j);
            }
            
            return _array;
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
            ushort tmp = _array[x];
            _array[x] = _array[y];
            _array[y] = tmp;
        }
    }
}