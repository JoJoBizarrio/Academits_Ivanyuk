using System.Collections.Generic;

namespace TreeTask
{
    internal class TreeTask<T> 
    {
        private TreeNode<T> _root;

        public int Count { get; private set; }

        public TreeTask()
        {
            _root = new TreeNode<T>();
            Count++;
        }

        public TreeTask(T root)
        {
            _root = new TreeNode<T>(root);
            Count++;
        }

        public void Add(T data)
        {
            TreeNode<T> next = _root;

            while (true)
            {
                if (data < next.Data)
                {
                    if (next.Left == null)
                    {
                        next.Left = new TreeNode<T>(data);
                        Count++;
                        break;
                    }
                    else
                    {
                        next = next.Left;
                    }
                }
                else
                {
                    if (next.Right == null)
                    {
                        next.Right = new TreeNode<T>(data);
                        Count++;
                        break;
                    }
                    else
                    {
                        next = next.Right;
                    }
                }
            }
        }

        public bool HasData(T data)
        {
            TreeNode<T>? treeNode = GetTreeNode(data);

            return treeNode != null;
        }

        private TreeNode<T>? GetTreeNode(T data)
        {
            TreeNode<T> next = _root;

            while (true)
            {
                if (data == next.Data)
                {
                    return next;
                }
                else if (data < next.Data)
                {
                    if (next.Left == null)
                    {
                        return null;
                    }
                    else
                    {
                        next = next.Left;
                    }
                }
                else
                {
                    if (next.Right == null)
                    {
                        return null;
                    }
                    else
                    {
                        next = next.Right;
                    }
                }
            }
        }

        public bool RemoveAt(T data)
        {
            if (_root.Data == data)
            {
                RemoveRoot();
                return true;                
            }

            TreeNode<T> next = _root;
            TreeNode<T> parent;

            while (true)
            {
                bool previoslyLeft = false;

                if (next.CompareTo(data) < 0) { }
                if (DataComparer<IComparable<T>>.Comparer(data, next.Data) < 0)


                if (data < next.Data)
                {
                    if (next.Left == null)
                    {
                        return false;
                    }
                    else
                    {
                        previoslyLeft = true;
                        parent = next;
                        next = next.Left;
                    }
                }
                else
                {
                    if (next.Right == null)
                    {
                        return false;
                    }
                    else
                    {
                        parent = next;
                        next = next.Right;
                    }
                }

                if (data == next.Data)
                {
                    if (next.Left == null && next.Right == null)
                    {
                        if (previoslyLeft)
                        {
                            parent.Left = null;
                            return true;
                        }

                        if (!previoslyLeft)
                        {
                            parent.Right = null;
                            return true;
                        }
                    } 

                    if (next.Left != null && next.Right == null)
                    {
                        if (previoslyLeft)
                        {
                            parent.Left = next.Left;
                            return true;
                        }

                        if (!previoslyLeft)
                        {
                            parent.Right = next.Left;
                            return true;
                        }
                    }

                    if (next.Left == null && next.Right != null)
                    {
                        if (previoslyLeft)
                        {
                            parent.Left = next.Right;
                            return true;
                        }

                        if (!previoslyLeft)
                        {
                            parent.Right = next.Right;
                            return true;
                        }
                    }
                }
            }
        }

        public void RemoveRoot()
        {
            if (_root.Left == null & _root.Right == null)
            {
                _root.Data = default;
                return;
            }

            if (_root.Left != null && _root.Right == null)
            {
                _root = _root.Left;
                return;
            }

            if (_root.Left == null && _root.Right != null)
            {
                _root = _root.Right;
                return;
            }

            TreeNode<T> treeNode = _root.Right;

            while (true)
            {
                if (treeNode.Left == null)
                {
                    treeNode.Left = _root.Left;
                    return;
                }
                else
                {
                    treeNode = treeNode.Left;
                }
            }
        }
    }
}