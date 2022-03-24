using System.Collections;
using System.Text;

namespace HashTableTask
{
    internal class HashTable<T> : ICollection<T>
    {
        private List<T>[] _items { get; }

        public int Count => _items.Length;

        public bool IsReadOnly { get; }

        public int ElementsCount
        {
            get
            {
                int elementsCount = 0;

                for (int i = 0; i < Count; ++i)
                {
                    elementsCount += _items[i].Count;
                }

                return elementsCount;
            }
        }

        public HashTable(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), length, "Argument must be more zero");
            }

            _items = new List<T>[length];

            for (int i = 0; i < length; ++i)
            {
                _items[i] = new List<T>(10);
            }
        }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Argument is null");
            }

            int index = Math.Abs(item.GetHashCode()) % Count;

            _items[index].Add(item);
        }

        public void Clear()
        {
            for (int i = 0; i < Count; ++i)
            {
                _items[i].Clear();
            }
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; ++i)
            {
                if (_items[i].Contains(item))
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
                if (_items[i].IndexOf(item) >= 0)
                {
                    return _items[i].Remove(item);
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array.Length - arrayIndex < ElementsCount)
            {
                throw new ArgumentException("Array is too small or Array index is too big");
            }

            int startIndex = arrayIndex;

            for (int i = 0; i < Count; ++i)
            {
                _items[i].CopyTo(array, startIndex);

                startIndex += _items[i].Count;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; ++i)
            {
                for (int j = 0; j < _items[i].Count; ++j)
                {
                    yield return _items[i][j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder info = new();

            for (int i = 0; i < Count; ++i)
            {
                if (_items[i].Count == 0)
                {
                    continue;
                }

                info.Append($"List {i}: ");

                foreach (T e in _items[i])
                {
                    info.Append($"{e}; ");
                }

                info.Append("\n");
            }

            return info.ToString();
        }
    }
}