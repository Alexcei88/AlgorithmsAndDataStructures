using System;
using System.Linq;
using System.Text;

namespace ConsoleTester.Arrays
{
    public class MatrixArray<T>
        : IArray<T>
    {
        private T[][] _innerArray = { };
        private int _rowNumber;
        private int _currentColumn;
        private readonly int _maxColumnSize;
        private readonly int _changeRowSizeStep = 10;
        
        public MatrixArray()
            : this(2)
        {}

        public MatrixArray(int maxColumnSize)
        {
            _maxColumnSize = maxColumnSize;
            _rowNumber = 0;
        }
        
        public int Size()
        {
            return _maxColumnSize * _rowNumber + _currentColumn;
        }

        public int Capacity()
        {
            return _maxColumnSize * _innerArray.Length;
        }
        
        public void Add(T els)
        {
            if(Capacity() == Size())
                StretchInnerArray();

            _innerArray[_rowNumber][_currentColumn] = els;
            
            ++_currentColumn;
            if (_currentColumn == _maxColumnSize)
            {
                _currentColumn = 0;
                ++_rowNumber;
            }
        }

        public void Add(T els, int index)
        {
            if (index > Size())
                index = Size();
            
            if(Capacity() == Size())
                StretchInnerArray();
            
            int rowNumberWithIndex = index / _maxColumnSize;
            int columnWithIndex = index % _maxColumnSize;
            if (_currentColumn == 0 && _rowNumber > 0)
                _innerArray[_rowNumber][0] = _innerArray[_rowNumber - 1][_maxColumnSize - 1];
            for (int row = _rowNumber - 1; row > rowNumberWithIndex; --row)
            {
                for (int column = _maxColumnSize - 1; column > 0; --column)
                    _innerArray[row][column] = _innerArray[row][column - 1];
                _innerArray[row][0] = _innerArray[row - 1][_maxColumnSize - 1];
            }

            for (int i = _maxColumnSize - 1; i > columnWithIndex; --i)
                _innerArray[rowNumberWithIndex][i] = _innerArray[rowNumberWithIndex][i - 1];
            
            _innerArray[rowNumberWithIndex][columnWithIndex] = els;
            
            ++_currentColumn;
            if (_currentColumn == _maxColumnSize)
            {
                _currentColumn = 0;
                ++_rowNumber;
            }
        }

        public T Remove(int index)
        {
            if (index > Size())
                index = Size();
            
            T result = Get(index);

            if (_currentColumn == 0)
            {
                _currentColumn = _maxColumnSize;
                --_rowNumber;
            }
            --_currentColumn;

            int rowNumberWithIndex = index / _maxColumnSize;
            int columnWithIndex = index % _maxColumnSize;
            
            for (int i = columnWithIndex; i < _maxColumnSize - 1; ++i)
                _innerArray[rowNumberWithIndex][i] = _innerArray[rowNumberWithIndex][i + 1];
            if(rowNumberWithIndex < _rowNumber)
                _innerArray[rowNumberWithIndex][_maxColumnSize - 1] = _innerArray[rowNumberWithIndex + 1][0];
            
            for (int row = rowNumberWithIndex + 1; row < _rowNumber; ++row)
            {
                for (int column = 0; column < _maxColumnSize - 1; ++column)
                    _innerArray[row][column] = _innerArray[row][column + 1];
                _innerArray[row][_maxColumnSize - 1] = _innerArray[row + 1][0];
            }

            for (int column = 0; column < _currentColumn - 1; ++column)
                _innerArray[_rowNumber][column] = _innerArray[_rowNumber][column + 1];

            int capacity = Capacity();
            int size = Size();
            if (size > 0 && capacity / size > 2)
                CompressInnerArray();
            
            return result;
        }

        public T Get(int index)
        {
            if (index > Size())
                throw new ArgumentException("Index is out of range for array");

            int rowNumberWithIndex = index / _maxColumnSize;
            int columnWithIndex = index % _maxColumnSize;
            return _innerArray[rowNumberWithIndex][columnWithIndex];
        }

        private void StretchInnerArray()
        {
            T[][] newArray = new T[_innerArray.Length + _changeRowSizeStep][];
            for (int i = _innerArray.Length; i < _innerArray.Length + _changeRowSizeStep; ++i)
                newArray[i] = new T[_maxColumnSize];
            Array.Copy(_innerArray, newArray, _innerArray.Length);
            _innerArray = newArray;
        }
        
        private void CompressInnerArray()
        {
            T[][] newArray = new T[_rowNumber + 1][];
            Array.Copy(_innerArray, newArray, _rowNumber + 1);
            _innerArray = newArray;
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            for(int i = 0; i < _rowNumber; ++i)
            for (int j = 0; j < _maxColumnSize; ++j)
                str.Append(_innerArray[i][j]);

            for (int j = 0; j < _currentColumn; ++j)
                str.Append(_innerArray[_rowNumber][j]);
            return str.ToString();
        }
    }
}