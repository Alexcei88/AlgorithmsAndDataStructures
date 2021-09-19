using System;
using System.Collections.Generic;

namespace ConsoleTester
{
    public class HashTable<K, V>
    {
        private sealed class Bucket
        {
            public readonly K Key;
            public readonly V Value;

            public Bucket(K key, V value)
            {
                Key = key;
                Value = value;
            }

            public override int GetHashCode()
            {
                return Key.GetHashCode() + Value.GetHashCode();
            }
        }
        
        private const uint Randomhashfactor = 43123578;
        private double _fillFactor = 0.75;
        private LinkedList<Bucket>[] _table;
        private int _resizeThreshold;
        private static int DEFAULT_CAPACITY = 16;
        
        private int _size;

        public HashTable()
            : this(DEFAULT_CAPACITY)
        { }
        
        public HashTable(int capacity)
        {
            _table = new LinkedList<Bucket>[capacity];
            _resizeThreshold = (int) (_table.Length * _fillFactor);
        }

        public int Size() => _size;
        
        public void Put(K key, V obj)
        {
            if (key == null)
                throw new ArgumentException($"{nameof(key)} is null");
            
            var newBucket = new Bucket(key, obj);
            if (++_size > _resizeThreshold)
                Expand();
            
            uint idx = CalculateHash(key);
            
            LinkedList<Bucket> curBucket = _table[idx];
            if (curBucket == null)
            {
                _table[idx] = new LinkedList<Bucket>();
                _table[idx].AddFirst(newBucket);
            }
            else
            {
                curBucket.AddFirst(newBucket);
            }
        }

        public bool Contains(V obj)
        {
            foreach (var lst in _table)
            {
                if (lst != null)
                {
                    foreach (var item in lst)
                        if (item.Value.Equals(obj))
                            return true;
                }
            }

            return false;
        }

        public bool ContainsKey(K key)
        {
            uint idx = CalculateHash(key);
            LinkedList<Bucket> bucket = _table[idx];
            if (bucket == null)
                return false;

            foreach (var item in bucket)
            {
                if (item.Key.Equals(key))
                    return true;
            }
            return false;
        }

        public V Get(K key)
        {
            uint idx = CalculateHash(key);
            LinkedList<Bucket> bucket = _table[idx];
            if (bucket == null)
                return default;

            foreach (var item in bucket)
            {
                if (item.Key.Equals(key))
                    return item.Value;
            }
            return default;
        }

        public V Remove(K key)
        {
            uint idx = CalculateHash(key);
            LinkedList<Bucket> bucket = _table[idx];
            if (bucket == null)
                return default;
            
            foreach (var item in bucket)
            {
                if (item.Key.Equals(key))
                {
                    bucket.Remove(item);
                    --_size;
                    return item.Value;
                }
            }

            return default;
        }
        
        public void Clear()
        {
            _table = new LinkedList<Bucket>[DEFAULT_CAPACITY];
            _size = 0;
            _resizeThreshold = (int) (DEFAULT_CAPACITY * _fillFactor);
        }

        private void Expand()
        {
            Resize(_table.Length * 2 + 1);
        }
        
        private uint CalculateHash(K key)
        {
            return (uint) (((uint)key.GetHashCode() * Randomhashfactor) % _table.Length);
        }

        private void Resize(int size)
        {
            LinkedList<Bucket>[] oldTable = _table;
            _resizeThreshold = (int) (size * _fillFactor);
            _table = new LinkedList<Bucket>[size];

            for (int i = oldTable.Length - 1; i >=0; --i)
            {
                LinkedList<Bucket> oldBucket = oldTable[i];
                if (oldBucket != null)
                {
                    foreach (var item in oldBucket)
                    {
                        uint idx = CalculateHash(item.Key);
                        var newBucket = _table[idx];
                        if (newBucket == null)
                            _table[idx] = new LinkedList<Bucket>();

                        _table[idx].AddLast(item);
                    }
                }
            }
        }
    }
}