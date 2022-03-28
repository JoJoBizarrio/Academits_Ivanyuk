using System.Collections.Generic;

namespace TreeTask
{
    internal class TreeTask<T> : IComparable<T>
    {
        private TreeNode<T> _root;

        private TreeNode<T> _treeNode;

        public TreeTask(T root)
        {
            _root = new TreeNode<T>();
            _root.Data = root;
        }

        public void Add(T value)
        {
            TreeNode<T> nextLeft = _root;
            TreeNode<T> nextRight = _root;
            //nextLeft = nextLeft.GetLeftChild();
            //nextRight = nextRight.GetLeftChild();

            Compa

            while (true)
            {
                if ( value < nextLeft.Data)
                {
                    if (nextLeft.Left == null)
                    {
                        nextLeft.Left.Data = value;
                        break;
                    }
                    else
                    {
                        nextLeft = nextLeft.Left;
                    }
                }
                else
                {
                    if (nextRight.Left == null)
                    {
                        nextRight.Left.Data = value;
                        break;
                    }
                    else
                    {
                        nextRight = nextRight.Left;
                    }
                }
            }
        }

        public int CompareTo(T? x)
        {
            return base.Comparer.
        }

    }
}
