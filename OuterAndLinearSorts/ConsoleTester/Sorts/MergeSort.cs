namespace ConsoleTester.Sorts
{
    public class MergeSort
        : ISort
    {
        private ushort[] _array;
        
        public ushort[] Sort(ushort[] input)
        {
            _array = input;
            Merge(0, input.Length);

            return _array;
        }

        private void Merge(int l, int r)
        {
            if(l + 1 >= r)
                return;
            
            int x = (l + r) / 2;
            
            Merge(l, x);
            Merge(x, r);
            
            Merges(l, x, r);
        }

        private void Merges(int l, int mid, int r)
        {
            ushort[] tempArray = new ushort[r - l];

            int startIndex = 0;
            int idxL = l;
            int idxR = mid;
            while (idxL < mid && idxR < r)
            {
                if (_array[idxL] < _array[idxR])
                {
                    tempArray[startIndex++] = _array[idxL++];
                }
                else
                {
                    tempArray[startIndex++] = _array[idxR++];
                }
            }

            for (int i = idxL; i < mid; ++i)
                tempArray[startIndex++] = _array[idxL++];
            
            for (int i = idxR; i < r; ++i)
                tempArray[startIndex++] = _array[idxR++];
            
            startIndex = 0;
            for (int i = l; i < r; ++i)
                _array[i] = tempArray[startIndex++];
        }
    }
}