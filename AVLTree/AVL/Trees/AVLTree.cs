using System;
using System.Text;

namespace ConsoleTester.Trees
{
    public class AVLTree
        : ITree
    {
        private class Node
        {
            public int Value;
            public Node Left;
            public Node Right;
            public byte Height;
        }

        private Node _root;
        
        public void Insert(int x)
        {
            if (_root == null)
            {
                _root = new Node()
                {
                    Value = x,
                    Height = 1
                };
                return;
            }
            _root = Insert(_root, x);
        }

        public bool Search(int x)
        {
            var node = FindNode(x);
            return node != null;
        }

        public void Remove(int x)
        {
            _root = RemoveNode(x, _root);
        }

        private Node Insert(Node root, int x)
        {
            if (root == null)
            {
                root = new Node()
                {
                    Value = x,
                    Height = 1
                };
                return root;
            }

            if (x == root.Value)
                return root; // для тестов просто пропускаем вставку дубликатов
                //throw new Exception("Такое значение уже есть в дереве. Нельзя вставить такое же значение");
            
            if (x < root.Value)
                root.Left = Insert(root.Left, x);
            else
                root.Right = Insert(root.Right, x);

            return BalanceTree(root);
        }

        private Node FindNode(int x)
        {
            Node current = _root;
            while (current != null)
            {
                if (current.Value == x)
                    return current;
                if (x < current.Value)
                    current = current.Left;
                else
                    current = current.Right;
            }

            return null;
        }

        private Node RemoveNode(int x, Node node)
        {
            if (node == null)
                return null;

            if (x < node.Value)
                node.Left = RemoveNode(x, node.Left);
            else if (x > node.Value)
                node.Right = RemoveNode(x, node.Right);
            else if (x == node.Value)
            {
                if (node.Left == null && node.Right == null)
                    return null;

                // leaf
                if (node.Left != null && node.Right != null)
                {
                    int minX = 0;
                    node.Right = RemoveMinNode(node.Right, ref minX);
                    node.Value = minX;
                    return BalanceTree(node);
                }

                // one child
                if (node.Left != null)
                    return BalanceTree(node.Left);

                if (node.Right != null)
                    return BalanceTree(node.Right);
            }
            return BalanceTree(node);
        }
        
        public override string ToString()
        {
            if (_root == null)
                return string.Empty;
            StringBuilder builder = new StringBuilder();
            VisitNode(_root, builder);
            
            return builder.ToString().TrimEnd();
        }

        private void VisitNode(Node node, StringBuilder builder)
        {
            if(node == null)
                return;
            
            VisitNode(node.Left, builder);
            builder.Append(node.Value + " ");
            VisitNode(node.Right, builder);
        }
        
        private int BFactor(Node p)
        {
            int rightHeight = p?.Right?.Height ?? 0;
            int leftHeight = p?.Left?.Height ?? 0;
            return rightHeight - leftHeight;
        }

        private void SetHeight(Node p)
        {
            byte left = p?.Left?.Height ?? 0;
            byte right = p?.Right?.Height ?? 0;
            
            p.Height = (byte) (Math.Max(left, right) + 1);
        }

        private Node BalanceTree(Node p)
        {
            SetHeight(p);
            var balanceFactor = BFactor(p);
            if (balanceFactor == 2) // справа больше
            {
                if (BFactor(p.Right) < 0)
                    return BigLeftRotation(p);

                return SmallLeftRotation(p);
            }
            
            if (balanceFactor == -2) // слева больше
            {
                if (BFactor(p.Left) > 0)
                    return BigRightRotation(p);

                return SmallRightRotation(p);
            }
            return p;
        }

        private Node SmallRightRotation(Node p)
        {
            Node q = p.Left;

            p.Left = q.Right;
            q.Right = p;
           
            SetHeight(p);
            SetHeight(q);

            return q;
        }
        
        private Node SmallLeftRotation(Node p)
        {
            Node q = p.Right;

            p.Right = q.Left;
            q.Left = p;
            
            SetHeight(p);
            SetHeight(q);

            return q;
        }

        private Node BigLeftRotation(Node p)
        {
            p.Right = SmallRightRotation(p.Right);
            return SmallLeftRotation(p);
        }

        private Node BigRightRotation(Node p)
        {
            p.Left = SmallLeftRotation(p.Left);
            return SmallRightRotation(p);
        }
        
        private Node RemoveMinNode(Node node, ref int x)
        {
            if (node.Left == null)
            {
                x = node.Value;
                return node.Right;
            }

            node.Left = RemoveMinNode(node.Left, ref x);
            return BalanceTree(node);
        }
    }
}