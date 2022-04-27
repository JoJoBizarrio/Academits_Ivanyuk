using System.Collections;
using System.Text;

namespace HashTableTask
{
    internal class HashTable<T> : ICollection<T>
    {
        private const int DefaultCapacity = 10;

        private readonly List<T>[] _lists;
        private int _modCount;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        private HashTable()
        {
            _lists = new List<T>[DefaultCapacity];
        }

        public HashTable(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), length, "Argument must be greater then zero");
            }

            _lists = new List<T>[length];
        }

        private int GetIndex(T item)
        {
            if (item == null)
            {
                return 0;
            }

            return Math.Abs(item.GetHashCode()) % _lists.Length;
        }

        public void Add(T item)
        {
            int index = GetIndex(item);

            if (_lists[index] == null)
            {
                _lists[index] = new List<T>();
            }

            _lists[index].Add(item);
            Count++;
            _modCount++;
        }

        public void Clear()
        {
            foreach (List<T> list in _lists)
            {
                if (list == null)
                {
                    continue;
                }

                list.Clear();
            }

            Count = 0;
            _modCount++;
        }

        public bool Contains(T item)
        {
            int listIndex = GetIndex(item);

            return _lists[listIndex] != null && _lists[listIndex].Contains(item);
        }

        public bool Remove(T item)
        {
            int listIndex = GetIndex(item);


            if (_lists[listIndex] != null && _lists[listIndex].Remove(item))
            {
                Count--;
                _modCount++;
                return true;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), $"{nameof(array)} is {null}");
            }

            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), arrayIndex, $"Index is out of range: [0; {array.Length - 1}]");
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("The count of elements in the source Collection<T> is greater than the available space from the position specified " +
                                            $"by {nameof(arrayIndex)} (= {arrayIndex}) to the end of the destination {nameof(array)}.");
            }

            int startIndex = arrayIndex;

            foreach (List<T> e in _lists)
            {
                if (e == null)
                {
                    continue;
                }

                e.CopyTo(array, startIndex);

                startIndex += e.Count;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int initialModCount = _modCount;

            foreach (List<T> list in _lists)
            {
                if (list != null)
                {
                    foreach (T e in list)
                    {
                        if (initialModCount != _modCount)
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

            foreach (List<T> list in _lists)
            {
                if (list == null)
                {
                    continue;
                }

                foreach (T e in list)
                {
                    stringBuilder.Append(e);
                    stringBuilder.Append(", ");
                }

                stringBuilder.Replace(", ", ".", stringBuilder.Length - 2, 2);
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}