using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02StackQueue;

namespace _05BinarySearchTree.Tree
{
    public class BinarySearchTree<T> : IMyCollection<T>
    {
        public int Depth { get; set; }

        public int Size => Count;

        public Boolean IsBalanced { get; set; }

        public int Count { get; private set; }

        public BinaryTreeNode<T> Root { get; private set; }

        public Func<T, T, int> Comparer { get; set; }

        public BinarySearchTree(Func<T, T, int> comparer)
        {
            Root = null;
            Comparer = comparer;
        }

        public void Add(T item)
        {
            var node = new BinaryTreeNode<T>(item);
            Count++;
            if (Root == null)
            {
                Root = node;
                node.IsRootNode = true;
            }
            else
            {
                Insert(Root, node);
            }
        }

        private void Insert(BinaryTreeNode<T> node, BinaryTreeNode<T> item)
        {
            if (Comparer == null)
            {
                Console.WriteLine("Please define the comparer.");
                return;
            }

            if (++item.Depth > Depth)
                Depth = item.Depth;

            int comp = Comparer(item.Value, node.Value);
            if (comp < 0)
            {
                if (node.Left == null)
                {
                    node.Left = item;
                    item.Parent = node;
                    item.IsLeftNode = true;
                }
                else
                    Insert(node.Left, item);
            }
            else if (comp > 0)
            {
                if (node.Right == null)
                {
                    node.Right = item;
                    item.Parent = node;
                }
                else
                    Insert(node.Right, item);
            }
            else
            {
                Console.WriteLine($"{item} already exists in the binary tree.");
            }
        }

        public int ExplicitCount(BinaryTreeNode<T> node, int counter)
        {
            if (node == null)
                return counter;
            if (node.Left != null)
            {
                counter = ExplicitCount(node.Left, counter);
            }
            if (node.Right != null)
            {
                counter = ExplicitCount(node.Right, counter);
            }
            return ++counter;
        }

        public void Clear()
        {
            Root.Clear();
            Root = null;
        }



        public BinaryTreeNode<T> Find(BinaryTreeNode<T> node, T item)
        {
            int comp = Comparer(item, node.Value);
            if (comp < 0)
            {
                return (node.Left == null) ? null : Find(node.Left, item);
            }
            else if (comp > 0)
            {
                return (node.Right == null) ? null : Find(node.Right, item);
            }
            else
            {
                return node;
            }
        }

        public bool Contains(T item)
        {
            return (Root == null) ? false : Find(Root, item) != null;
        }

        public T Get()
        {
            throw new NotImplementedException();
        }

        public T GetAndRemove()
        {
            throw new NotImplementedException();
        }
    }
}
