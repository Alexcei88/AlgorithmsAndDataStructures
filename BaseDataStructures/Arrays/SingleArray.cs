using System;
using System.Text;

namespace ConsoleTester.Arrays
{
    public class SingleArray<T>
        : IArray<T>
    {
        private T[] _innerArray = { };
        public int Size()
        {
            return _innerArray.Length;
        }

        public void Add(T els)
        {
            StretchInnerArray();
            _innerArray[Size() - 1] = els;
        }

        public void Add(T els, int index)
        {
            if (index > Size())
                index = Size();
            StretchInnerArray();

            for (int i = Size() - 1; i > index; --i)
                _innerArray[i] = _innerArray[i - 1];
            _innerArray[index] = els;
        }

        public T Remove(int index)
        {
            if (index > Size())
                throw new ArgumentException("Index is out of range for array");
            
            T result = Get(index);
            for (int i = index; i < Size() - 1; ++i)
                _innerArray[i] = _innerArray[i + 1];

            CompressInnerArray();
            return result;
        }

        public T Get(int index)
        {
            if (index > Size())
                throw new ArgumentException("Index is out of range for array");

            return _innerArray[index];
        }

        private void StretchInnerArray()
        {
            T[] newArray = new T[Size() + 1];
            Array.Copy(_innerArray, newArray, _innerArray.Length);
            _innerArray = newArray;
        }
        
        private void CompressInnerArray()
        {
            T[] newArray = new T[Size() - 1];
            Array.Copy(_innerArray, newArray, _innerArray.Length - 1);
            _innerArray = newArray;
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            foreach (var a in _innerArray)
            {
                str.Append(a);
            }

            return str.ToString();
        }
    }
}