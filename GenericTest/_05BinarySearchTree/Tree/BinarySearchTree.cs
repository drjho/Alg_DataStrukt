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
        public int Depth { get; private set; }

        public int Size => Count;

        public Boolean IsBalanced => DepthDifference(Root) <= 1;

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
            if (comp > 0) // item.Value > node.Value => to the right!
            {
                if (node.Right == null)
                {
                    node.Right = item;
                    item.Parent = node;
                }
                else
                    Insert(node.Right, item);
            }
            else if (comp < 0)
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
            else
            {
                --Count;
                Console.WriteLine($"item '{item.Value}' already exists in the tree");
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

        public int DepthDifference(BinaryTreeNode<T> node)
        {
            int d1, d2;

            if (node.Left != null)
                d1 = SubTreeDepth(node.Left);
            else
                d1 = node.Depth;

            if (node.Right != null)
                d2 = SubTreeDepth(node.Right);
            else
                d2 = node.Depth;

            return Math.Abs(d1 - d2);
        }

        public int SubTreeDepth(BinaryTreeNode<T> node)
        {
            int d1, d2;

            if (node.Left != null)
                d1 = SubTreeDepth(node.Left);
            else
                d1 = node.Depth;

            if (node.Right != null)
                d2 = SubTreeDepth(node.Right);
            else
                d2 = node.Depth;

            return Math.Max(d1, d2);
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

        public List<T> ToSortedList()
        {
            if (Root != null)
            {
                return ToSortedList(Root, new List<T>());
            }
            else
            {
                return null;
            }
        }

        List<T> ToSortedList(BinaryTreeNode<T> node, List<T> list)
        {
            if (node.Left != null)
                list = ToSortedList(node.Left, list);

            list.Add(node.Value);

            if (node.Right != null)
                list = ToSortedList(node.Right, list);

            return list;
        }
    }
}
