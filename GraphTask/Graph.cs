namespace GraphTask
{
    internal class Graph
    {
        private double[,] _graph;

        public int PeeksCount { get => _graph.GetLength(0); }

        public double this[int rowIndex, int columnIndex]
        {
            get
            {
                CheckRowIndex(rowIndex);
                CheckColumnIndex(columnIndex);

                return _graph[rowIndex, columnIndex];
            }
            set
            {
                CheckRowIndex(rowIndex);
                CheckColumnIndex(columnIndex);

                if (rowIndex != columnIndex)
                {
                    _graph[rowIndex, columnIndex] = value;
                }
            }
        }

        public Graph(int peeksCount)
        {
            _graph = new double[peeksCount, peeksCount];
        }

        public void ConnectPeeks(int peek1Number, int peek2Number)
        {
            if (peek1Number != peek2Number)
            {
                _graph[peek1Number, peek2Number] = 1;
                _graph[peek2Number, peek1Number] = 1;
            }
        }

        public void BypassByWidth(Func<double, double> func)
        {
            Queue<int> queue = new Queue<int>();
            bool[] visited = new bool[PeeksCount];

            queue.Enqueue(0);

            while (queue.Count > 0)
            {
                int peekNumber = queue.Dequeue();

                for (int i = 0; i < PeeksCount; ++i)
                {
                    if (_graph[peekNumber, i] > 0)
                    {
                        _graph[peekNumber, i] = func(_graph[peekNumber, i]);

                        if (!visited[i])
                        {
                            queue.Enqueue(i);
                        }
                    }
                }

                visited[peekNumber] = true;
            }
        }

        public void BypassByDeep(Func<double, double> func)
        {
            Stack<int> stack = new Stack<int>();
            bool[] visited = new bool[PeeksCount];

            stack.Push(0);

            while (stack.Count > 0)
            {
                int peekNumber = stack.Pop();

                for (int i = PeeksCount - 1; i >= 0; --i)
                {
                    if (_graph[peekNumber, i] > 0)
                    {
                        _graph[peekNumber, i] = func(_graph[peekNumber, i]);

                        if (!visited[i])
                        {
                            stack.Push(i);
                        }
                    }
                }

                visited[peekNumber] = true;
            }
        }

        private void CheckRowIndex(int index)
        {
            if (index < 0 || index >= _graph.GetLength(0))
            {
                throw new ArgumentOutOfRangeException($"Index out of range [0; {_graph.GetLength(0) - 1}]");
            }
        }

        private void CheckColumnIndex(int index)
        {
            if (index < 0 || index >= _graph.GetLength(1))
            {
                throw new ArgumentOutOfRangeException($"Index out of range [0; {_graph.GetLength(1) - 1}]");
            }
        }
    }
}