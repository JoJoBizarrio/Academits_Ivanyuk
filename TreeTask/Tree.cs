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
                throw new InvalidOperationException($"Tree {this} is empty.");
            }

            TreeNode<T> treeNode = _root;

            while (true)
            {
                if (data.CompareTo(treeNode.Data) == 0)
                {
                    return treeNode;
                }
                else if (data.CompareTo(treeNode.Data) < 0)
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

        private TreeNode<T> GetTreeNodeParent(T data)
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
            TreeNode<T> treeNodeParent = _root; // поскольку компилятор ругается на 122 строке если не присвоить переменную в этом месте пришлось присвоить.

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
            bool isLeftTurn = false;

            if (data.CompareTo(deletedNodeParent.Data) < 0)
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
                    Count--;

                    return true;
                }

                if (!isLeftTurn)
                {
                    deletedNodeParent.Right = null;
                    Count--;

                    return true;
                }
            }

            // нет левого
            if (deletedNode.Left == null)
            {
                if (isLeftTurn)
                {
                    deletedNodeParent.Left = deletedNode.Right;
                    Count--;

                    return true;
                }

                if (!isLeftTurn)
                {
                    deletedNodeParent.Right = deletedNode.Right;
                    Count--;

                    return true;
                }
            }

            // нет правого
            if (deletedNode.Right == null)
            {
                if (isLeftTurn)
                {
                    deletedNodeParent.Left = deletedNode.Left;
                    Count--;

                    return true;
                }

                if (!isLeftTurn)
                {
                    deletedNodeParent.Right = deletedNode.Left;
                    Count--;

                    return true;
                }
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
                Count--;

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

        public string WidthBypass()
        {
            CheckFirst();

            StringBuilder stringBuilder = new();
            stringBuilder.Append("[");

            Queue<TreeNode<T>> queue = new();
            queue.Enqueue(_root);

            TreeNode<T> treeNode;

            while (queue.Count != 0)
            {
                treeNode = queue.Dequeue();

                stringBuilder.Append(treeNode.Data);
                stringBuilder.Append(", ");

                if (treeNode.Left != null)
                {
                    queue.Enqueue(treeNode.Left);
                }

                if (treeNode.Right != null)
                {
                    queue.Enqueue(treeNode.Right);
                }
            }

            stringBuilder.Replace(", ", "]", stringBuilder.Length - 3, 3);

            return stringBuilder.ToString();
        }

        public string DeepBypass()
        {
            CheckFirst();

            StringBuilder stringBuilder = new();
            stringBuilder.Append("[");

            Stack<TreeNode<T>> stack = new();
            TreeNode<T> treeNode;

            stack.Push(_root);

            while (stack.Count != 0)
            {
                treeNode = stack.Pop();

                stringBuilder.Append(treeNode.Data);
                stringBuilder.Append(", ");

                if (treeNode.Right != null)
                {
                    stack.Push(treeNode.Right);
                }

                if (treeNode.Left != null)
                {
                    stack.Push(treeNode.Left);
                }
            }

            stringBuilder.Replace(", ", "]", stringBuilder.Length - 2, 2);

            return stringBuilder.ToString();
        }

        public void DeepRecursiveBypass()
        {
            Console.Write(_root.Data);
            Console.Write("  ");
            DeepRecursiveBypass(_root);
        }


        private void DeepRecursiveBypass(TreeNode<T> treeNode)
        {
            List<TreeNode<T>> list = new List<TreeNode<T>> { treeNode.Left, treeNode.Right };

            foreach (TreeNode<T> e in list)
            {
                if (e == null)
                {
                    continue;
                }

                Console.Write(e.Data);
                Console.Write("  ");

                DeepRecursiveBypass(e);
            }
        }
    }
}