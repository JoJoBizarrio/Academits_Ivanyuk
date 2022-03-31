using System.Collections;
using System.Text;

namespace HashTableTask
{
    internal class HashTable<T> : ICollection<T>
    {
        private List<T>[] _lists;

        public int Count { get; private set; }

        public int Capacity => _lists.Length;

        public bool IsReadOnly => false;

        private int ModCount { get; set; }

        private HashTable()
        {
            _lists = new List<T>[0];
        }

        public HashTable(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), length, "Argument must be greater then zero");
            }

            _lists = new List<T>[length];

            for (int i = 0; i < length; ++i)
            {
                _lists[i] = new List<T>(10);
            }
        }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Argument is null");
            }

            int index = Math.Abs(item.GetHashCode()) % Count;

            _lists[index].Add(item);
            Count++;
        }

        public void Clear()
        {
            for (int i = 0; i < Count; ++i)
            {
                _lists[i].Clear();
            }

            Count = default;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; ++i)
            {
                if (_lists[i].Contains(item))
                {
                    return true;
                }

            }

            return false;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < Count; ++i)
            {
                if (_lists[i].IndexOf(item) >= 0)
                {
                    Count--;
                    return _lists[i].Remove(item);
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("Array is too small or Array index is too big");
            }

            int startIndex = arrayIndex;

            for (int i = 0; i < Count; ++i)
            {
                _lists[i].CopyTo(array, startIndex);

                startIndex += _lists[i].Count;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; ++i)
            {
                for (int j = 0; j < _lists[i].Count; ++j)
                {
                    yield return _lists[i][j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();

            for (int i = 0; i < Count; ++i)
            {
                if (_lists[i].Count == 0)
                {
                    continue;
                }

                stringBuilder.Append($"List {i}: ");

                foreach (T e in _lists[i])
                {
                    stringBuilder.Append($"{e}; ");
                }

                stringBuilder.Append(Environment.NewLine);
            }

            return stringBuilder.ToString();
        }
    }
}