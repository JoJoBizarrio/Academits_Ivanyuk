using System.Collections.Generic;

namespace TreeTask
{
    internal class Tree<T> where T : IComparable<T>
    {
        private TreeNode<T>? _root;

        public int Count { get; private set; }

        public Tree() { }

        public Tree(T root)
        {
            _root = new TreeNode<T>(root);
            Count++;
        }

        public void Add(T data)
        {
            if (_root == null)
            {
                _root = new TreeNode<T>(data);
                Count++;
                return;
            }

            TreeNode<T> treeNode = _root;

            while (true)
            {
                if (data.CompareTo(treeNode.Data) > 0)
                {
                    if (treeNode.Left == null)
                    {
                        treeNode.Left = new TreeNode<T>(data);
                        Count++;
                        return;
                    }
                    else
                    {
                        treeNode = treeNode.Left;
                    }
                }
                else
                {
                    if (treeNode.Right == null)
                    {
                        treeNode.Right = new TreeNode<T>(data);
                        Count++;
                        return;
                    }
                    else
                    {
                        treeNode = treeNode.Right;
                    }
                }
            }
        }

        public bool HasData(T data) => GetTreeNode(data) != null;

        private TreeNode<T>? GetTreeNode(T data)
        {
            if (_root == null)
            {
                throw new InvalidOperationException($"Tree {this} is empty.");
            }

            TreeNode<T> treeNode = _root;

            while (true)
            {
                if (data.CompareTo(treeNode.Data) == 0)
                {
                    return treeNode;
                }
                else if (data.CompareTo(treeNode.Data) > 0)
                {
                    if (treeNode.Left == null)
                    {
                        return null;
                    }
                    else
                    {
                        treeNode = treeNode.Left;
                    }
                }
                else
                {
                    if (treeNode.Right == null)
                    {
                        return null;
                    }
                    else
                    {
                        treeNode = treeNode.Right;
                    }
                }
            }
        }

        public bool RemoveAt(T data)
        {
            CheckFirst();

            if (data.Equals(_root.Data))
            {
                RemoveFirst();
                return true;
            }

            TreeNode<T> treeNode = _root;
            TreeNode<T> parent;

            while (true)
            {
                bool previoslyLeft = false;

                if (data.CompareTo(treeNode.Data) > 0)
                {
                    if (treeNode.Left == null)
                    {
                        return false;
                    }
                    else
                    {
                        previoslyLeft = true;
                        parent = treeNode;
                        treeNode = treeNode.Left;
                    }
                }
                else
                {
                    if (treeNode.Right == null)
                    {
                        return false;
                    }
                    else
                    {
                        parent = treeNode;
                        treeNode = treeNode.Right;
                    }
                }

                if (data.CompareTo(treeNode.Data) == 0)
                {
                    if (treeNode.Left == null && treeNode.Right == null)
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

                    if (treeNode.Left != null && treeNode.Right == null)
                    {
                        if (previoslyLeft)
                        {
                            parent.Left = treeNode.Left;
                            return true;
                        }

                        if (!previoslyLeft)
                        {
                            parent.Right = treeNode.Left;
                            return true;
                        }
                    }

                    if (treeNode.Left == null && treeNode.Right != null)
                    {
                        if (previoslyLeft)
                        {
                            parent.Left = treeNode.Right;
                            return true;
                        }

                        if (!previoslyLeft)
                        {
                            parent.Right = treeNode.Right;
                            return true;
                        }
                    }
                }
            }
        }

        private void RemoveFirst()
        {
            if (_root.Left == null & _root.Right == null)
            {
                _root.Data = default;
                return;
            }

            if (_root.Left == null)
            {
                _root = _root.Right;
                return;
            }

            if (_root.Right == null)
            {
                _root = _root.Left;
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

        private void CheckFirst()
        {
            if (_root == null)
            {
                throw new NullReferenceException($"Tree {this} is empty.");
            }
        }
    }
}