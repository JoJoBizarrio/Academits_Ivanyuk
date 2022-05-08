using TreeTask.Comparers;

namespace TreeTask
{
    internal class Tree<T>
    {
        private Node<T> _root;

        private readonly IComparer<T> _comparer;

        public int Count { get; private set; }

        public Tree() { }

        public Tree(T root)
        {
            _root = new Node<T>(root);
            _comparer = new DataComparer<T>();

            Count++;
        }

        public Tree(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        public Tree(T root, IComparer<T> comparer)
        {
            _root = new Node<T>(root);
            _comparer = comparer;

            Count++;
        }

        public void Add(T data)
        {
            if (_root == null)
            {
                _root = new Node<T>(data);

                Count++;
                return;
            }

            Node<T> node = _root;

            while (true)
            {
                if (_comparer.Compare(data, node.Data) < 0)
                {
                    if (node.Left == null)
                    {
                        node.Left = new Node<T>(data);

                        Count++;
                        return;
                    }

                    node = node.Left;
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = new Node<T>(data);

                        Count++;
                        return;
                    }

                    node = node.Right;

                }
            }
        }

        public bool Contains(T data) => GetNode(data) != null;

        private Node<T> GetNode(T data)
        {
            if (_root == null)
            {
                return null;
            }

            if (_comparer.Compare(data, _root.Data) == 0)
            {
                return _root;
            }

            Node<T> node = GetNodeParent(data);

            if (_comparer.Compare(node.Left.Data, data) == 0)
            {
                return node.Left;
            }

            if (_comparer.Compare(node.Right.Data, data) == 0)
            {
                return node.Right;
            }

            return null;
        }

        private Node<T> GetNodeParent(T data)
        {
            if (_root == null || _comparer.Compare(data, _root.Data) == 0)
            {
                return null;
            }

            Node<T> node = _root;

            while (true)
            {
                Node<T> nodeParent = node;

                int comparisonResult = _comparer.Compare(data, node.Data);

                if (comparisonResult < 0)
                {
                    if (node.Left == null)
                    {
                        return null;
                    }

                    node = node.Left;
                }

                if (comparisonResult == 0)
                {
                    return nodeParent;
                }

                if (comparisonResult > 0)
                {
                    if (node.Right == null)
                    {
                        return null;
                    }

                    node = node.Right;
                }
            }
        }

        public bool Remove(T data)
        {
            if (_root == null)
            {
                return false;
            }

            Node<T> deletedNode;
            Node<T> deletedNodeParent;
            bool isLeftChild = false;

            if (_comparer.Compare(data, _root.Data) == 0)
            {
                deletedNode = _root;
            }
            else
            {
                deletedNodeParent = GetNodeParent(data);

                if (deletedNodeParent == null)
                {
                    return false;
                }

                if (_comparer.Compare(data, deletedNodeParent.Data) < 0)
                {
                    deletedNode = deletedNodeParent.Left;
                    isLeftChild = true;
                }
                else
                {
                    deletedNode = deletedNodeParent.Right;
                }
            }

            // нет детей
            if (deletedNode.Left == null && deletedNode.Right == null)
            {
                if (isLeftChild)
                {
                    deletedNodeParent.Left = null;
                }
                else
                {
                    deletedNodeParent.Right = null;
                }

                Count--;
                return true;
            }

            // нет левого
            if (deletedNode.Left == null)
            {
                if (isLeftChild)
                {
                    deletedNodeParent.Left = deletedNode.Right;
                }
                else
                {
                    deletedNodeParent.Right = deletedNode.Right;
                }

                Count--;
                return true;
            }

            // нет правого
            if (deletedNode.Right == null)
            {
                if (isLeftChild)
                {
                    deletedNodeParent.Left = deletedNode.Left;
                }
                else
                {
                    deletedNodeParent.Right = deletedNode.Left;
                }

                Count--;
                return true;
            }

            // 2 ребенка
            Node<T> rightBranchMinNode = deletedNode.Right;
            Node<T> rightBranchMinNodeParent = deletedNode;

            if (rightBranchMinNode.Left != null)
            {
                while (rightBranchMinNode.Left != null)
                {
                    rightBranchMinNodeParent = rightBranchMinNode;
                    rightBranchMinNode = rightBranchMinNode.Left;
                }

                if (rightBranchMinNode.Right == null)
                {
                    rightBranchMinNodeParent.Left = null; // занулили родителя левого правой ветки
                }
                else
                {
                    rightBranchMinNodeParent.Left = rightBranchMinNode.Right; // если есть ребенок соединили 
                }

                if (isLeftChild) // смотрим куда идет поворот после родителя удаляемого нода
                {
                    deletedNodeParent.Left = rightBranchMinNode; // перенаправили ссылку родителя удаляемого на минамльного левого
                }
                else
                {
                    deletedNodeParent.Right = rightBranchMinNode;
                }

                rightBranchMinNode.Left = deletedNode.Left; // минимальный левый принимает ссылки детей от удаляемого
                rightBranchMinNode.Right = deletedNode.Right;

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

        public void BypassByWidth(Action<T> action)
        {
            if (_root == null)
            {
                return;
            }

            Queue<Node<T>> queue = new();
            queue.Enqueue(_root);

            while (queue.Count != 0)
            {
                Node<T> node = queue.Dequeue();

                action(node.Data);

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
        }

        public void BypassByDeep(Action<T> action)
        {
            if (_root == null)
            {
                return;
            }

            Stack<Node<T>> stack = new();
            stack.Push(_root);

            while (stack.Count != 0)
            {
                Node<T> node = stack.Pop();

                action(node.Data);

                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }

                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
            }
        }

        public void BypassByDeepRecursive(Action<T> action)
        {
            if (_root == null)
            {
                return;
            }

            BypassByDeepRecursive(action, _root);
        }

        private void BypassByDeepRecursive(Action<T> action, Node<T> node)
        {
            action(node.Data);

            if (node.Left != null)
            {
                BypassByDeepRecursive(action, node.Left);
            }

            if (node.Right != null)
            {
                BypassByDeepRecursive(action, node.Right);
            }
        }

        private static int Comparison(T data1, T data2)
        {
            if (data1 == null && data2 == null)
            {
                return 0;
            }

            if (data1 == null)
            {
                return -1;
            }

            if (data2 == null)
            {
                return 1;
            }

            IComparable<T> comparableData = (IComparable<T>)data1;

            return comparableData.CompareTo(data2);
        }
    }
}