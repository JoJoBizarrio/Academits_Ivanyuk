using System.Text;

namespace GraphTask
{
    internal class Graph
    {
        private int[,] _graph;

        public int PeeksCount { get => _graph.GetLength(0); private set => throw new NotImplementedException(); }

        public int this[int rowIndex, int columnIndex]
        {
            get { CheckRowIndex(rowIndex); CheckColumnIndex(columnIndex); return _graph[rowIndex, columnIndex]; }
            set { CheckRowIndex(rowIndex); CheckColumnIndex(columnIndex); if (rowIndex != columnIndex) { _graph[rowIndex, columnIndex] = value; } }
        }

        public Graph(int peeksCount)
        {
            _graph = new int[peeksCount, peeksCount];
        }

        public void ConnectPeeks(int peek1Number, int peek2Number)
        {
            if (peek1Number != peek2Number)
            {
                _graph[peek1Number, peek2Number] = 1;
                _graph[peek2Number, peek1Number] = 1;
            }
        }

        public string BypassByWidth()
        {
            NullifyDiagonal();

            return "empty";
        }

        public string BypassByDeep()
        {
            NullifyDiagonal();

            StringBuilder stringBuilder = new StringBuilder();
            Queue<int> queue = new Queue<int>();
            bool[] visited = new bool[PeeksCount];

            stringBuilder.Append('[');
            queue.Enqueue(0);

            while (queue.Count > 0)
            {
                int peekNumber = queue.Dequeue();
                stringBuilder.Append(peekNumber);
                stringBuilder.Append(", ");

                for (int i = 0; i < PeeksCount; ++i)
                {
                    if (!visited[i] && _graph[peekNumber, i] > 0)
                    {
                        queue.Enqueue(i);   
                    }
                }

                visited[peekNumber] = true;
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2);
            stringBuilder.Append(']');

            return stringBuilder.ToString();   
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

        private void NullifyDiagonal()
        {
            for (int i = 0; i < _graph.GetLength(0); ++i)
            {
                _graph[i, i] = 0;
            }
        }
    }
}