using System.Collections.Generic;
using System.Linq;

namespace ConsoleTester.Queue
{
    public class PriorityQueue<T>
    {
        private SortedList<int, List<T>> _list = new ();
        
        public void Enqueue(int priority, T item)
        {
            if(_list.ContainsKey(priority))
                _list[priority].Add(item);
            else
                _list.Add(priority, new List<T> { item });                
        }

        public T Dequeue()
        {
            if (_list.Any())
            {
                var pair = _list.Last();
                T els = pair.Value.First();
                pair.Value.RemoveAt(0);
                if (!pair.Value.Any())
                    _list.Remove(pair.Key);
                return els;
            }
            return default;
        }
    }
}