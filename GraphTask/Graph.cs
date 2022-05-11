namespace GraphTask
{
    internal class Graph
    {
        private readonly int[,] _matrix;

        public int VertexesCount => _matrix.GetLength(0);

        public int this[int rowIndex, int columnIndex]
        {
            get
            {
                CheckRowIndex(rowIndex);
                CheckColumnIndex(columnIndex);

                return _matrix[rowIndex, columnIndex];
            }
            set
            {
                CheckRowIndex(rowIndex);
                CheckColumnIndex(columnIndex);

                if (rowIndex != columnIndex)
                {
                    _matrix[rowIndex, columnIndex] = value;
                }
            }
        }

        public Graph(int vertexesCount)
        {
            _matrix = new int[vertexesCount, vertexesCount];
        }

        public Graph(int[,] matrix)
        {
            _matrix = matrix;
        }

        public void ConnectVertexes(int vertex1Index, int vertex2Index)
        {
            if (vertex1Index != vertex2Index)
            {
                _matrix[vertex1Index, vertex2Index] = 1;
                _matrix[vertex2Index, vertex1Index] = 1;
            }
        }

        public void BypassByWidth(Action<int> action)
        {
            Queue<int> queue = new();
            bool[] visitedVertexes = new bool[VertexesCount];
            int visitedVertexesCount = 0;

            while (queue.Count > 0 || visitedVertexesCount < VertexesCount)
            {
                if (queue.Count == 0)
                {
                    queue.Enqueue(visitedVertexesCount);
                }

                int vertexIndex = queue.Dequeue();

                if (!visitedVertexes[vertexIndex])
                {
                    action(vertexIndex);

                    for (int i = 0; i < VertexesCount; ++i)
                    {
                        if (_matrix[vertexIndex, i] > 0)
                        {
                            queue.Enqueue(i);
                        }
                    }

                    visitedVertexes[vertexIndex] = true;
                    visitedVertexesCount++;
                }
            }
        }

        public void BypassByDeep(Action<int> action)
        {
            Stack<int> stack = new();
            bool[] visitedVertexes = new bool[VertexesCount];
            int visitedVertexesCount = 0;

            while (stack.Count > 0 || visitedVertexesCount < VertexesCount)
            {
                if (stack.Count == 0)
                {
                    stack.Push(visitedVertexesCount);
                }

                int vertexIndex = stack.Pop();

                if (!visitedVertexes[vertexIndex])
                {
                    for (int i = VertexesCount - 1; i >= 0; --i)
                    {
                        if (_matrix[vertexIndex, i] > 0)
                        {
                            stack.Push(i);
                        }
                    }

                    action(vertexIndex);
                    visitedVertexes[vertexIndex] = true;
                    visitedVertexesCount++;
                }
            }
        }

        public void BypassByRecursiveDeep(Action<int> action)
        {
            bool[] visitedVertexes = new bool[VertexesCount];
            int visitedVertexesCount = 0;

            action(0);
            BypassByRecursiveDeep(action, 0, visitedVertexes, visitedVertexesCount);
        }

        private void BypassByRecursiveDeep(Action<int> action, int vertexIndex, bool[] visitedVertexes, int visitedVertexesCount)
        {
            
                visitedVertexes[vertexIndex] = true;
                bool isDisconnectVertex = true;

                for (int i = 0; i < VertexesCount; i++)
                {
                    if (_matrix[vertexIndex, i] > 0)
                    {
                        isDisconnectVertex = false;
                    }
                }

                if (!isDisconnectVertex)
                {
                    for (int i = 0; i < VertexesCount; i++)
                    {
                        if (_matrix[vertexIndex, i] > 0 && !visitedVertexes[i])
                        {
                            action(i);
                            visitedVertexesCount++;

                            BypassByRecursiveDeep(action, i, visitedVertexes, visitedVertexesCount);
                        }
                    }
                }
                else
                {
                    action(vertexIndex);
                    visitedVertexesCount++;
                    visitedVertexes[vertexIndex] = true;
                }

            
        }

        private void CheckRowIndex(int index)
        {
            if (index < 0 || index >= _matrix.GetLength(0))
            {
                throw new IndexOutOfRangeException($"Row's index (= {index}) out of range [0; {_matrix.GetLength(0) - 1}]");
            }
        }

        private void CheckColumnIndex(int index)
        {
            if (index < 0 || index >= _matrix.GetLength(1))
            {
                throw new IndexOutOfRangeException($"Column's index (= {index}) out of range [0; {_matrix.GetLength(1) - 1}]");
            }
        }
    }
}