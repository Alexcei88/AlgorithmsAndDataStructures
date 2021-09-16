using System;
using System.Text;

namespace ConsoleTester.Trees
{
    public class RandomSearchTree
        : ITree
    {
        private class Node
        {
            public int Value;
            public Node Left;
            public Node Right;
            public int Size;
        }

        private Node _root;
        private readonly Random _random = new();

        public void Insert(int x)
        {
            if (_root == null)
            {
                _root = new Node()
                {
                    Value = x,
                    Size = 1,
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
                    Size = 1,
                };
                return root;
            }

            if (_random.Next() % (root.Size + 1) == 0)
            {
                root = InsertInRoot(root, x);
            }
            else
            {
                if (x == root.Value)
                    return root; // для тестов сделаем, что мы просто ничего не вставляем
                //throw new Exception("Такое значение уже есть в дереве. Нельзя вставить такое же значение");

                if (x < root.Value)
                    root.Left = Insert(root.Left, x);
                else
                    root.Right = Insert(root.Right, x);
            }

            UpdateSize(root);
            return root;
        }

        private Node InsertInRoot(Node root, int x)
        {
            if (root == null)
            {
                root = new Node()
                {
                    Value = x,
                    Size = 1,
                };
                return root;
            }
            
            if (x == root.Value)
                return root; // для тестов сделаем, что мы просто ничего не вставляем
            //throw new Exception("Такое значение уже есть в дереве. Нельзя вставить такое же значение");
            
            if (x < root.Value)
            {
                root.Left = InsertInRoot(root.Left, x);
                return SmallRightRotation(root);
            }

            root.Right = InsertInRoot(root.Right, x);
            return SmallLeftRotation(root);
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
                    if ((node.Right != null || node.Left != null) && _random.Next() % (node.Left?.Size + node.Right?.Size) < (int) node.Left?.Size)
                    {
                        // node.Left will be root
                        return SmallRightRotation(node);
                    }
                    return node;
                }

                // one child
                if (node.Left != null)
                    return node.Left;

                if (node.Right != null)
                    return node.Right;
            }

            return node;
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
            if (node == null)
                return;

            VisitNode(node.Left, builder);
            builder.Append(node.Value + " ");
            VisitNode(node.Right, builder);
        }

        private Node RemoveMinNode(Node node, ref int x)
        {
            if (node.Left == null)
            {
                x = node.Value;
                return node.Right;
            }

            node.Left = RemoveMinNode(node.Left, ref x);
            return node;
        }
        
        private Node SmallRightRotation(Node p)
        {
            Node q = p.Left;

            p.Left = q.Right;
            q.Right = p;
           
            UpdateSize(p);
            return q;
        }
        
        private Node SmallLeftRotation(Node p)
        {
            Node q = p.Right;

            p.Right = q.Left;
            q.Left = p;
            
            UpdateSize(p);
            return q;
        }

        private void UpdateSize(Node p)
        {
            int leftSize = p.Left?.Size ?? 0;
            int rightSize = p.Right?.Size ?? 0;
            p.Size = leftSize + rightSize + 1;
        }
    }
}