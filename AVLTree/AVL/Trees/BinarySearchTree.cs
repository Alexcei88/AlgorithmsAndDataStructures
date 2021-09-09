using System;
using System.Text;

namespace ConsoleTester.Trees
{
    
    public class BinarySearchTree
    {
        private class Node
        {
            public int Value;
            public Node Left;
            public Node Right;
            public Node Parent;
        }

        private Node _root;
        
        public void Insert(int x)
        {
            if (_root == null)
            {
                _root = new Node()
                {
                    Value = x
                };
                return;
            }
            Insert(_root, _root.Parent, x);
        }

        public bool Search(int x)
        {
            var node = FindNode(x);
            return node != null;

        }

        public bool Remove(int x)
        {
            var node = FindNode(x);
            if(node == null)
                return false;

            RemoveNode(node);
            return true;
        }

        private Node Insert(Node root, Node parent, int x)
        {
            if (root == null)
            {
                root = new Node()
                {
                    Value = x,
                    Parent = parent,
                };
                return root;
            }

            if (x == root.Value)
                throw new Exception("Такое значение уже есть в дереве. Нельзя вставить такое же значение");
            
            if (x < root.Value)
            {
                root.Left = Insert(root.Left, root, x);
            }
            else
            {
                root.Right = Insert(root.Right, root, x);
            }

            return root;
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

        private void RemoveNode(Node node)
        {
            // leaf
            if (node.Left == null && node.Right == null)
            {
                if (node.Parent.Left == node)
                    node.Parent.Left = null;
                else
                    node.Parent.Right = null;
            }    
            else if (node.Left != null && node.Right != null)
            {
                // find min in the right branch
                var minNode = node.Right;
                while (minNode.Left != null)
                    minNode = minNode.Left;
                
                // replace value of minNode and node
                node.Value = minNode.Value;
                // remove minNode
                RemoveNode(minNode);
            }
            // one child
            else if (node.Left != null)
            {
                if (node.Parent.Left == node)
                    node.Parent.Left = node.Left;
                else
                    node.Parent.Right = node.Left;
                node.Left.Parent = node.Parent;

            }
            else
            {
                if (node.Parent.Left == node)
                    node.Parent.Left = node.Right;
                else
                    node.Parent.Right = node.Right;
                node.Right.Parent = node.Parent;
            }
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
    }
}