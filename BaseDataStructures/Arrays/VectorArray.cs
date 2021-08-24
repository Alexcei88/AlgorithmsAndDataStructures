using System;
using System.Linq;
using System.Text;

namespace ConsoleTester.Arrays
{
    public class VectorArray<T>
        : IArray<T>
    {
        private T[] _innerArray = { };
        private int _size = 0;
        private readonly int _changeSizeStep;
        
        public VectorArray()
            : this(2)
        {}

        public VectorArray(int step)
        {
            _changeSizeStep = step;
        }
        public int Size()
        {
            return _size;
        }

        public void Add(T els)
        {
            if(_innerArray.Length == _size)
                StretchInnerArray();
            ++_size;
            _innerArray[_size - 1] = els;
        }

        public void Add(T els, int index)
        {
            if (index > Size())
                index = Size();
            
            if(_innerArray.Length == _size)
                StretchInnerArray();

            ++_size;
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
            --_size;

            if(_innerArray.Length - _changeSizeStep == _size )
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
            T[] newArray = new T[Size() + _changeSizeStep];
            Array.Copy(_innerArray, newArray, _innerArray.Length);
            _innerArray = newArray;
        }
        
        private void CompressInnerArray()
        {
            T[] newArray = new T[_size];
            Array.Copy(_innerArray, newArray, _size);
            _innerArray = newArray;
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            foreach (var a in _innerArray.Take(_size))
            {
                str.Append(a);
            }

            return str.ToString();
        }
    }
}