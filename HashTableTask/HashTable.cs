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
            _lists = Array.Empty<List<T>>();
        }

        public HashTable(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), length, "Argument must be greater then zero");
            }

            _lists = new List<T>[length];
        }

        private int GetHashIndex(T item)
        {
            if (item == null)
            {
                return 0;
            }

            return Math.Abs(item.GetHashCode()) % Capacity;
        }

        public void Add(T item)
        {
            int index = GetHashIndex(item);

            if (_lists[index] == null)
            {
                _lists[index] = new List<T>();
            }

            _lists[index].Add(item);
            Count++;
            ModCount++;
        }

        public void Clear()
        {
            for (int i = 0; i < Capacity; ++i)
            {
                if (_lists[i] == null)
                {
                    continue;
                }

                _lists[i].Clear();
            }

            Count = default;
            ModCount++;
        }

        public bool Contains(T item)
        {
            if (_lists[GetHashIndex(item)].Contains(item))
            {
                return true;
            }

            return false;
        }

        public bool Remove(T item)
        {
            int index = GetHashIndex(item);

            if (_lists[index].IndexOf(item) >= 0)
            {
                Count--;
                ModCount++;
                return _lists[index].Remove(item);
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} is {null}");
            }

            if (arrayIndex < 0 || arrayIndex > array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), arrayIndex, $"Index is out of range: [0; {array.Length - 1}]");
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException($"The count of elements in the source Collection<T> is greater than the available space from the position specified " +
                                            $"by {nameof(arrayIndex)} (= {arrayIndex}) to the end of the destination {nameof(array)}.");
            }

            int startIndex = arrayIndex;

            for (int i = 0; i < Capacity; ++i)
            {
                if (_lists[i] == null)
                {
                    continue;
                }

                _lists[i].CopyTo(array, startIndex);

                startIndex += _lists[i].Count;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currentModCount = ModCount;

            for (int i = 0; i < Capacity; ++i)
            {
                if (_lists[i] != null)
                {
                    foreach (T e in _lists[i])
                    {
                        if (currentModCount != ModCount)
                        {
                            throw new InvalidOperationException("HashTable changed.");
                        }

                        yield return e;
                    }
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

            for (int i = 0; i < Capacity; ++i)
            {
                if (_lists[i] == null || _lists[i].Count == 0)
                {
                    continue;
                }

                stringBuilder.Append("List ");
                stringBuilder.Append(i);
                stringBuilder.Append(": ");

                foreach (T e in _lists[i])
                {
                    stringBuilder.Append(e);
                    stringBuilder.Append(", ");
                }

                stringBuilder.Replace(", ", ".", stringBuilder.Length - 2, 2);
                stringBuilder.Append(Environment.NewLine);
            }

            return stringBuilder.ToString();
        }
    }
}