using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTester.Arrays
{
    public class ListArray<T>
        : IArray<T>
    {
        private List<T> _innerArray = new();
        public int Size()
        {
            return _innerArray.Count;
        }

        public void Add(T els)
        {
            _innerArray.Add(els);
        }

        public void Add(T els, int index)
        {
            _innerArray.Insert(index, els);
        }

        public T Remove(int index)
        {
            var el = _innerArray.ElementAt(index);
            _innerArray.RemoveAt(index);
            return el;
        }

        public T Get(int index)
        {
            return _innerArray.ElementAt(index);
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