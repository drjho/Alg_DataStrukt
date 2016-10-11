using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05BinarySearchTree.Tree
{
    public class BinaryTreeNode<T>
    {
        public T Value { get; set; }

        public BinaryTreeNode(T item)
        {
            Value = item;
        }

        public BinaryTreeNode<T> Parent { get; set; } = null;

        public BinaryTreeNode<T> Left { get; set; } = null;

        public BinaryTreeNode<T> Right { get; set; } = null;

        public Boolean IsRootNode { get; set; } = false;

        public Boolean IsLeftNode { get; set; } = false;

        public Int32 Depth { get; set; } = 0;

        public void Clear()
        {
            Value = default(T);
            Left?.Clear();
            Right?.Clear();
            Parent = null;
            Left = null;
            Right = null;
        }


    }
}
