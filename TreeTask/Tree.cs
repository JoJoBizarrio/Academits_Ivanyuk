using System.Text;

namespace TreeTask
{
    internal class Tree<T> where T : IComparable<T>
    {
        private TreeNode<T> _root;

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
                if (data.CompareTo(treeNode.Data) < 0)
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

        private TreeNode<T> GetTreeNode(T data)
        {
            if (_root == null)
            {
                return null;
            }

            if ((data == null && _root.Data == null) || data.Equals(_root.Data))
            {
                return _root;
            }

            TreeNode<T> treeNode = GetTreeNodeParent(data);

            if (treeNode.Left != null && treeNode.Left.Data.Equals(data))
            {
                return treeNode.Left;
            }

            if (treeNode.Right != null && treeNode.Right.Data.Equals(data))
            {
                return treeNode.Right;
            }

            return null;
        }

        private TreeNode<T> GetTreeNodeParent(T data)
        {
            if (_root == null || data.Equals(_root.Data))
            {
                return null;
            }

            if (data == null & _root.Data == null)
            {
                return null;
            }

            TreeNode<T> treeNode = _root;
            TreeNode<T> treeNodeParent = _root; // поскольку компилятор ругается на 122 строке если не присвоить переменную в этом месте пришлось присвоить.

            if (data == null)
            {
                while (treeNode != null)
                {
                    if (treeNode.Data == null)
                    {
                        return treeNodeParent;
                    }
                    else
                    {
                        treeNodeParent = treeNode;
                        treeNode = treeNode.Left;
                    }
                }

                return null;
            }

            while (true)
            {
                if (data.CompareTo(treeNode.Data) == 0)
                {
                    return treeNodeParent; // нету такого исхода когда данная переменная не присвоена если не присваивать на 116
                }
                else if (data.CompareTo(treeNode.Data) < 0)
                {
                    if (treeNode.Left == null)
                    {
                        return null;
                    }
                    else
                    {
                        treeNodeParent = treeNode;
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
                        treeNodeParent = treeNode;
                        treeNode = treeNode.Right;
                    }
                }
            }
        }

        public bool Remove(T data)
        {
            CheckFirst();

            if (data.Equals(_root.Data))
            {
                RemoveFirst();
                return true;
            }

            TreeNode<T> deletedNodeParent = GetTreeNodeParent(data);

            if (deletedNodeParent == null)
            {
                return false;
            }

            TreeNode<T> deletedNode;
            bool isLeftChild = false;

            if (data.CompareTo(deletedNodeParent.Data) < 0)
            {
                deletedNode = deletedNodeParent.Left;
                isLeftChild = true;
            }
            else
            {
                deletedNode = deletedNodeParent.Right;
            }

            // нет детей
            if (deletedNode.Left == null && deletedNode.Right == null)
            {
                if (isLeftChild)
                {
                    deletedNodeParent.Left = null;
                    Count--;
                }
                else
                {
                    deletedNodeParent.Right = null;
                    Count--;
                }

                return true;
            }

            // нет левого
            if (deletedNode.Left == null)
            {
                if (isLeftChild)
                {
                    deletedNodeParent.Left = deletedNode.Right;
                    Count--;
                }
                else
                {
                    deletedNodeParent.Right = deletedNode.Right;
                    Count--;
                }

                return true;
            }

            // нет правого
            if (deletedNode.Right == null)
            {
                if (isLeftChild)
                {
                    deletedNodeParent.Left = deletedNode.Left;
                    Count--;
                }
                else
                {
                    deletedNodeParent.Right = deletedNode.Left;
                    Count--;
                }

                return true;
            }

            // 2 ребенка
            TreeNode<T> minRightBranch = deletedNode.Right;
            TreeNode<T> minRightBranchParent = deletedNode;

            if (minRightBranch.Left != null)
            {
                while (minRightBranch.Left != null)
                {
                    minRightBranchParent = minRightBranch;
                    minRightBranch = minRightBranch.Left;
                }

                if (minRightBranch.Right == null)
                {
                    minRightBranchParent.Left = null; // занулили родителя левого правой ветки
                }
                else
                {
                    minRightBranchParent.Left = minRightBranch.Right; // если есть ребенок соединили 
                }

                if (isLeftChild) // смотрим куда идет поворот после родителя удаляемого нода
                {
                    deletedNodeParent.Left = minRightBranch; // перенаправили ссылку родителя удаляемого на минамльного левого
                }
                else
                {
                    deletedNodeParent.Right = minRightBranch;
                }

                minRightBranch.Left = deletedNode.Left; // минимальный левый принимает ссылки детей от удаляемого
                minRightBranch.Right = deletedNode.Right;

                deletedNode.Left = null; // зануляем удаляемый нод
                deletedNode.Right = null;
                Count--;

                return true;
            }

            if (isLeftChild)
            {
                deletedNodeParent.Left = deletedNode.Right;
            }
            else
            {
                deletedNodeParent.Right = deletedNode.Right;
            }

            deletedNode.Right.Left = deletedNode.Left;

            deletedNode.Left = null; // зануляем удаляемый нод
            deletedNode.Right = null;
            Count--;

            return true;
        }

        private void RemoveFirst()
        {
            if (_root.Left == null & _root.Right == null)
            {
                _root = null;
                Count--;

                return;
            }

            if (_root.Left == null)
            {
                _root = _root.Right;
                Count--;

                return;
            }

            if (_root.Right == null)
            {
                _root = _root.Left;
                Count--;

                return;
            }

            TreeNode<T> treeNode = _root.Right;

            while (true)
            {
                if (treeNode.Left == null)
                {
                    treeNode.Left = _root.Left;
                    _root = treeNode; // в данном случае затираются старые _root.Left and _root.Right и сборщик их убирет или нужно вручную занулить их перед присваиванием?
                    Count--;

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

        public void BypassInWidth(Func<T, T> func)
        {
            CheckFirst();

            Queue<TreeNode<T>> queue = new();

            TreeNode<T> treeNode = _root;
            queue.Enqueue(treeNode);

            while (queue.Count != 0)
            {
                treeNode = queue.Dequeue();

                treeNode.Data = func(treeNode.Data);

                if (treeNode.Left != null)
                {
                    queue.Enqueue(treeNode.Left);
                }

                if (treeNode.Right != null)
                {
                    queue.Enqueue(treeNode.Right);
                }
            }
        }

        public void BypassInDeep(Func<T, T> func)
        {
            CheckFirst();

            Stack<TreeNode<T>> stack = new();
            TreeNode<T> treeNode = _root;

            stack.Push(treeNode);

            while (stack.Count != 0)
            {
                treeNode = stack.Pop();

                treeNode.Data = func(treeNode.Data);

                if (treeNode.Right != null)
                {
                    stack.Push(treeNode.Right);
                }

                if (treeNode.Left != null)
                {
                    stack.Push(treeNode.Left);
                }
            }
        }

        public void BypassInRecursiveDeep(Func<T, T> func)
        {
            BypassInRecursiveDeep(func, _root);
        }

        private void BypassInRecursiveDeep(Func<T, T> func, TreeNode<T> treeNode)
        {
            treeNode.Data = func(treeNode.Data);

            if (treeNode.Left != null)
            {
                BypassInRecursiveDeep(func, treeNode.Left);
            }

            if (treeNode.Right != null)
            {
                BypassInRecursiveDeep(func, treeNode.Right);
            }
        }
    }
}