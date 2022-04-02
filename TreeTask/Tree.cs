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

        private TreeNode<T>? GetTreeNodeParent(T data)
        {
            if (_root == null)
            {
                throw new InvalidOperationException($"Tree {this} is empty.");
            }

            if (data.Equals(_root.Data))
            {
                throw new ArgumentException($"{nameof(data)} is equal to data in first element (_data). First element doesn't have parent.");
            }

            TreeNode<T> treeNode = _root;
            TreeNode<T> treeNodeParent = _root; // поскольку компилятор ругается на 122 строке если не присвоить переменную пришлось присвоить.

            while (true)
            {
                if (data.CompareTo(treeNode.Data) == 0)
                {
                    return treeNodeParent; // нету такого исхода когда данная переменная не присвоена
                }
                else if (data.CompareTo(treeNode.Data) > 0)
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

        //public bool RemoveAt(T data)
        //{
        //    CheckFirst();

        //    if (data.Equals(_root.Data))
        //    {
        //        RemoveFirst();
        //        return true;
        //    }

        //    TreeNode<T> treeNode = _root;
        //    TreeNode<T> deletedNodeParent;
        //    bool isLeftTurn = false;

        //    while (data.CompareTo(treeNode.Data) != 0)
        //    {
        //        isLeftTurn = false;

        //        if (data.CompareTo(treeNode.Data) > 0)
        //        {
        //            if (treeNode.Left == null)
        //            {
        //                return false;
        //            }
        //            else
        //            {
        //                isLeftTurn = true;
        //                deletedNodeParent = treeNode;
        //                treeNode = treeNode.Left;
        //            }
        //        }
        //        else
        //        {
        //            if (treeNode.Right == null)
        //            {
        //                return false;
        //            }
        //            else
        //            {
        //                deletedNodeParent = treeNode;
        //                treeNode = treeNode.Right;
        //            }
        //        }
        //    }

        //    TreeNode<T> deletedNode = treeNode;

        //    // нет детей
        //    if (deletedNode.Left == null && deletedNode.Right == null)
        //    {
        //        if (isLeftTurn)
        //        {
        //            deletedNodeParent.Left = null; // нету такого исхода где данная переменная в этом месте не будет присвоена
        //            return true;
        //        }

        //        if (!isLeftTurn)
        //        {
        //            deletedNodeParent.Right = null;
        //            return true;
        //        }
        //    }

        //    // нет левого
        //    if (treeNode.Left == null)
        //    {
        //        if (isLeftTurn)
        //        {
        //            deletedNodeParent.Left = treeNode.Right;
        //            return true;
        //        }

        //        if (!isLeftTurn)
        //        {
        //            deletedNodeParent.Right = treeNode.Right;
        //            return true;
        //        }
        //    }

        //    // нет правого
        //    if (treeNode.Right == null)
        //    {
        //        if (isLeftTurn)
        //        {
        //            deletedNodeParent.Left = treeNode.Left;
        //            return true;
        //        }

        //        if (!isLeftTurn)
        //        {
        //            deletedNodeParent.Right = treeNode.Left;
        //            return true;
        //        }
        //    }

        //    // отсутсвие отсутствия (2 ребенка)
        //    TreeNode<T> minRightBranch = deletedNode.Right;
        //    TreeNode<T> minRightBranchParent = deletedNode;

        //    if (minRightBranch.Left != null)
        //    {
        //        while (minRightBranch.Left != null)
        //        {
        //            minRightBranchParent = minRightBranch;
        //            minRightBranch = minRightBranch.Left;
        //        }

        //        if (minRightBranch.Right == null) 
        //        {
        //            minRightBranchParent.Left = null; // занулили родителя левого правой ветки
        //        }
        //        else
        //        {
        //            minRightBranchParent.Left = minRightBranch.Right; // если есть соединили 
        //        }

        //        if (isLeftTurn) // смотрим куда идет поворот после родителя удаляемого нода
        //        {
        //            deletedNodeParent.Left = minRightBranch; // перенаправили ссылку родителя удаляемого на минамльного левого
        //        }
        //        else
        //        {
        //            deletedNodeParent.Right = minRightBranch;
        //        }

        //        minRightBranch.Left = deletedNode.Left; // минимальный левый принимает ссылки детей от удаляемого
        //        minRightBranch.Right = deletedNode.Right;

        //        deletedNode.Left = null; // зануляем удаляемый нод
        //        deletedNode.Right = null;
        //        deletedNode = null;
        //        return true;
        //    }

        //    if (isLeftTurn) 
        //    {
        //        deletedNodeParent.Left = deletedNode.Right;
        //    }
        //    else
        //    {
        //        deletedNodeParent.Right = deletedNode.Right;
        //    }

        //    deletedNode.Right.Left = deletedNode.Left;

        //    deletedNode.Left = null; // зануляем удаляемый нод
        //    deletedNode.Right = null;
        //    deletedNode = null;
        //    return true;
        //}

        public bool RemoveAt(T data)
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
            bool isLeftTurn = false;

            if (data.CompareTo(deletedNodeParent.Data) > 0)
            {
                deletedNode = deletedNodeParent.Left;
                isLeftTurn = true;
            }
            else
            {
                deletedNode = deletedNodeParent.Right;
            }

            // нет детей
            if (deletedNode.Left == null && deletedNode.Right == null)
            {
                if (isLeftTurn)
                {
                    deletedNodeParent.Left = null;
                    return true;
                }

                if (!isLeftTurn)
                {
                    deletedNodeParent.Right = null;
                    return true;
                }
            }

            // нет левого
            if (deletedNode.Left == null)
            {
                if (isLeftTurn)
                {
                    deletedNodeParent.Left = deletedNode.Right;
                    return true;
                }

                if (!isLeftTurn)
                {
                    deletedNodeParent.Right = deletedNode.Right;
                    return true;
                }
            }

            // нет правого
            if (deletedNode.Right == null)
            {
                if (isLeftTurn)
                {
                    deletedNodeParent.Left = deletedNode.Left;
                    return true;
                }

                if (!isLeftTurn)
                {
                    deletedNodeParent.Right = deletedNode.Left;
                    return true;
                }
            }

            // отсутсвие отсутствия (2 ребенка)
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
                    minRightBranchParent.Left = minRightBranch.Right; // если есть соединили 
                }

                if (isLeftTurn) // смотрим куда идет поворот после родителя удаляемого нода
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
                deletedNode = null;
                return true;
            }

            if (isLeftTurn)
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
            deletedNode = null;
            return true;
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