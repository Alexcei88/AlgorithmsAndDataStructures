using System;
using System.Text;

namespace ConsoleTester.Trees
{
    public class BTree
        : ITree
    {
        private class Node
        {
            public Node[] Children { get; }
            private readonly bool _isLeaf;
            private readonly int[] _keys;
            private int _keyCount;

            public Node(int minDegree, bool isLeaf)
            {
                Children = new Node[minDegree * 2];
                _isLeaf = isLeaf;
                _keys = new int[minDegree * 2 - 1];
            }

            public bool IsFull()
            {
                return _keyCount == Children.Length - 1;
            }
            
            public void InsertKey(int key)
            {
                if (_isLeaf)
                {
                    AddKeyToLeaf(key);
                    return;
                }
                // find position
                int idx = _keyCount - 1;
                while (idx >= 0 && _keys[idx] > key)
                    --idx;
                if (Children[idx + 1].IsFull())
                {
                    SplitChild(idx + 1, Children[idx + 1], out int midKey);
                    if (midKey < key)
                        ++idx;
                }
                Children[idx + 1].InsertKey(key);
            }

            public bool Search(int x)
            {
                for (int i = 0; i < _keyCount; ++i)
                {
                    if (_keys[i] == x)
                        return true;
                    if (_keys[i] > x && Children[i] != null)
                        return Children[i].Search(x);
                }
                if(Children[_keyCount] != null)
                    return Children[_keyCount].Search(x);

                return false;
            }

            public void Remove(int x)
            {
                
            }
            
            public override string ToString()
            {
                StringBuilder builder = new StringBuilder();                
                for (int i = 0; i < _keyCount; ++i)
                {
                    builder.Append(Children[i]?.ToString() ?? string.Empty);
                    builder.Append(_keys[i] + " ");
                }

                builder.Append(Children[_keyCount]?.ToString() ?? string.Empty);
                return builder.ToString();
            }
            
            public void SplitChild(int idx, Node child, out int midKey)
            {
                int t = Children.Length >> 1;
                var newChild = new Node(t, child._isLeaf);
                for (int i = 0; i < t - 1; ++i)
                    newChild._keys[i] = child._keys[t + i];
                newChild._keyCount = t - 1;

                if (child._isLeaf == false)
                {
                    for (int j = 0; j < t; ++j)
                        newChild.Children[j] = child.Children[t + j];
                }
                
                for (int i = _keyCount; i >= idx + 1; i--)
                    Children[i + 1] = Children[i];
                
                // Link the new child to this node
                Children[idx + 1] = newChild;
                child._keyCount = t - 1;
                
                // middle element
                for (int i = _keyCount; i > idx; --i)
                    _keys[i] = _keys[i - 1];

                midKey = child._keys[t - 1];
                _keys[idx] = midKey;
                ++_keyCount;
            }
            
            public void AddKeyToLeaf(int key)
            {
                int idx = 0;
                while (idx < _keyCount && key > _keys[idx])
                    ++idx;
                
                for (int i = _keyCount; i > idx; --i)
                    _keys[i] = _keys[i - 1];

                _keys[idx] = key;
                ++_keyCount;
            }

            private int GetMaximumFromChild(int idx)
            {
                Node cur = Children[idx];
                while (!cur._isLeaf)
                    cur = cur.Children[cur._keyCount];
  
                // Return the last key of the leaf
                return cur._keys[cur._keyCount - 1];
            }
            
            private int GetMinimumFromChild(int idx)
            {
                Node cur = Children[idx];
                while (!cur._isLeaf)
                    cur = cur.Children[0];
  
                // Return the last key of the leaf
                return cur._keys[0];
            }

            private void MergeSibling(int idx)
            {
                int t = Children.Length >> 1;
                
                Node left = Children[idx];
                Node right = Children[idx+1];

                left._keys[t - 1] = _keys[idx];
                
                // Copying the keys from C[idx+1] to C[idx] at the end
                for (int i = 0; i < right._keyCount; ++i)
                    left._keys[i+t] = right._keys[i];
                
                // Copying the child pointers from C[idx+1] to C[idx]
                if (!left._isLeaf)
                {
                    for(int i = 0; i <= left._keyCount; ++i)
                        left.Children[i + t] = right.Children[i];
                }
                
                // Moving all keys after idx in the current node one step before -
                // to fill the gap created by moving keys[idx] to C[idx]
                for (int i = idx + 1; i < _keyCount; ++i)
                    _keys[i - 1] = _keys[i];
                
                // Moving the child pointers after (idx+1) in the current node one
                // step before
                for (int i = idx + 1; i < _keyCount; ++i)
                    Children[i] = Children[i + 1];

                left._keyCount += right._keyCount + 1;
                --_keyCount;
            }
            
            private void RemoveFromLeaf(int idx)
            {
                for (int i = idx + 1; i < _keyCount; ++i)
                    _keys[i - 1] = _keys[i];
  
                --_keyCount;
            }

            private void RemoveFromNonLeaf(int idx)
            {
                int t = Children.Length >> 1;
                int k = _keys[idx];

                if (Children[idx]._keyCount >= t)
                {
                    int min = GetMinimumFromChild(idx);
                    _keys[idx] = min;
                }
            }
            
            private int SearchKey(int key)
            {
                int idx = 0;
                while (idx < _keyCount && _keys[idx] < key)
                    ++idx;
                return idx;
            }
        }

        private Node _root;
        private readonly Random _random = new();

        private readonly int _minDegree;

        public BTree()
            : this(20)
        {}
        
        public BTree(int degree)
        {
            _minDegree = degree;
        }
        public void Insert(int x)
        {
            if (_root == null)
            {
                _root = new Node(_minDegree, true);
                _root.AddKeyToLeaf(x);
                return;
            }

            if (_root.IsFull())
            {
                var newRoot = new Node(_minDegree, false);
                newRoot.Children[0] = _root;
                
                newRoot.SplitChild(0, _root, out int midKey);
                
                // there are two child, we need to insert key one of them
                int idx = midKey > x ? 0 : 1;
                newRoot.Children[idx].InsertKey(x);
                _root = newRoot;
            }
            else
            {
                _root.InsertKey(x);
            }
        }

        public bool Search(int x)
        {
            if (_root == null)
                return false;
            return _root.Search(x);
        }

        public void Remove(int x)
        {
        }
        
        public override string ToString()
        {
            if (_root == null)
                return string.Empty;
            
            return _root.ToString().TrimEnd();
        }
    }
}