namespace GraphTask
{
    internal class Graph
    {
        private readonly int[,] _bondsTable;

        public int VertexesCount => _bondsTable.GetLength(0);

        public int this[int rowIndex, int columnIndex]
        {
            get
            {
                CheckRowIndex(rowIndex);
                CheckColumnIndex(columnIndex);

                return _bondsTable[rowIndex, columnIndex];
            }
            set
            {
                CheckRowIndex(rowIndex);
                CheckColumnIndex(columnIndex);

                if (rowIndex != columnIndex)
                {
                    _bondsTable[rowIndex, columnIndex] = value;
                }
            }
        }

        public Graph(int vertexesCount)
        {
            _bondsTable = new int[vertexesCount, vertexesCount];
        }

        public Graph(int vertexesCount, params int[] vertexes)
        {
            _bondsTable = new int[vertexesCount, vertexesCount];

            for (int i = 0; i < vertexes.Length - 1; i++)
            {
                ConnectVertexes(vertexes[i], vertexes[i + 1]);
            }
        }

        public void ConnectVertexes(int vertex1Index, int vertex2Index)
        {
            if (vertex1Index != vertex2Index)
            {
                _bondsTable[vertex1Index, vertex2Index] = 1;
                _bondsTable[vertex2Index, vertex1Index] = 1;
            }
        }

        public void BypassByWidth(Action<int> func)
        {
            Queue<int> queue = new Queue<int>();
            bool[] visitedVertexes = new bool[VertexesCount];

            queue.Enqueue(0);

            while (queue.Count > 0)
            {
                int vertexIndex = queue.Dequeue();

                if (!visitedVertexes[vertexIndex])
                {
                    func(vertexIndex);
                }

                for (int i = 0; i < VertexesCount; ++i)
                {
                    if (_bondsTable[vertexIndex, i] > 0)
                    {
                        if (!visitedVertexes[i])
                        {
                            queue.Enqueue(i);
                        }
                    }
                }

                visitedVertexes[vertexIndex] = true;
            }
        }

        public void BypassByDeep(Action<int> func)
        {
            Stack<int> stack = new Stack<int>();
            bool[] visitedVertexes = new bool[VertexesCount];

            stack.Push(0);

            while (stack.Count > 0)
            {
                int vertexIndex = stack.Pop();

                if (!visitedVertexes[vertexIndex])
                {
                    func(vertexIndex);
                }

                for (int i = VertexesCount - 1; i >= 0; --i)
                {
                    if (_bondsTable[vertexIndex, i] > 0)
                    {
                        if (!visitedVertexes[i])
                        {
                            stack.Push(i);
                        }
                    }
                }

                visitedVertexes[vertexIndex] = true;
            }
        }

        public void BypassByRecursiveDeep(Action<int> func)
        {
            bool[] visitedVertexes = new bool[VertexesCount];

            func(0);
            visitedVertexes[0] = true;

            BypassByRecursiveDeep(func, 0, visitedVertexes);
            
        }

        private void BypassByRecursiveDeep(Action<int> func, int vertexIndex, bool[] visitedVertexes)
        {
            for (int i = 0; i < VertexesCount; i++)
            {
                if (_bondsTable[vertexIndex, i] > 0 && !visitedVertexes[i])
                {
                    func(i);
                    visitedVertexes[i] = true;

                    BypassByRecursiveDeep(func, i, visitedVertexes);
                }
            }
        }


        private void CheckRowIndex(int index)
        {
            if (index < 0 || index >= _bondsTable.GetLength(0))
            {
                throw new ArgumentOutOfRangeException($"Index out of range [0; {_bondsTable.GetLength(0) - 1}]");
            }
        }

        private void CheckColumnIndex(int index)
        {
            if (index < 0 || index >= _bondsTable.GetLength(1))
            {
                throw new ArgumentOutOfRangeException($"Index out of range [0; {_bondsTable.GetLength(1) - 1}]");
            }
        }
    }
}