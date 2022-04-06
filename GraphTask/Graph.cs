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

        public string WidthBypass()
        {
            NullifyDiagonal();


        }

        public string DeepBypass()
        {

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