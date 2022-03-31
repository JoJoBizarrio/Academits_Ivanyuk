using System.Collections;
using System.Text;

namespace ListTask
{
    internal class List<T> : IList<T>
    {
        private T[] _items;

        private const int DefaultCapacity = 10;

        private int ModCount { get; set; }

        public bool IsReadOnly => false;

        public int Count { get; private set; }

        public int Capacity
        {
            get => _items.Length;

            set
            {
                if (value <= Count)
                {
                    throw new ArgumentException($"Capacity = {value} must be more Count {Count}");
                }

                Array.Resize(ref _items, value);
            }
        }

        public T this[int index]
        {
            get { CheckIndex(index); return _items[index]; }
            set { CheckIndex(index); _items[index] = value; ModCount++; }
        }

        public List()
        {
            _items = new T[DefaultCapacity];
        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException($"Count must be > 0 {nameof(capacity)} = {capacity}", nameof(capacity));
            }

            _items = new T[capacity];
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(_items, item, 0, Count);
        }

        public void Insert(int index, T item)
        {
            CheckIndex(index);

            if (Capacity - 1 <= Count)
            {
                Expand();
            }

            Array.Copy(_items, index, _items, index + 1, Count - index + 1);

            _items[index] = item;

            Count++;
            ModCount++;
        }

        public void Add(T item)
        {
            if (Capacity - 1 <= Count)
            {
                Expand();
            }

            Insert(Count, item);
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index);

            Array.Copy(_items, index + 1, _items, index, Count - index + 1);
            Count--;
            ModCount++;
        }

        public void Add(params T[] item)
        {
            for (int i = 0; i < item.Length; ++i)
            {
                Add(item[i]);
            }
        }

        public void Clear()
        {
            Array.Clear(_items, 0, Count);
            Count = 0;
            ModCount++;
        }

        public bool Contains(T item) =>  IndexOf(item) >= 0;

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index < 0)
            {
                return false;
            }

            RemoveAt(index);
            return true;
        }

        public void CopyTo(T[] arrayList, int index)
        {
            CheckIndex(index);

            Array.Copy(_items, index, arrayList, 0, Count - index + 1);
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currentModCount = ModCount;

            for (int i = 0; i < Count; ++i)
            {
                if (currentModCount != ModCount)
                {
                    throw new InvalidOperationException($"List changed.");
                }

                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void TrimExcess()
        {
            if ((double)Count / (double)Capacity <= 0.9)
            {
                Array.Resize(ref _items, Count);
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();

            stringBuilder.Append('[');
            stringBuilder.Append(string.Join(", ", this));
            stringBuilder.Remove(stringBuilder.Length - 2, 2).Append(']');

            return stringBuilder.ToString();
        }

        public string GetInformation()
        {
            return $"{string.Join(", ", this)}. {Environment.NewLine}Capacity = {Capacity}; {Environment.NewLine}Count = {Count}; " +
                   $"{Environment.NewLine}EmptyItems = {Capacity - Count};{Environment.NewLine}";
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, $"Index out of range: [0, {Count - 1}]");
            }
        }

        //private void CheckCapacity()
        //{
        //    if (Capacity - 1 <= Count)
        //    {
        //        Expand();
        //    }
        //}

        private void Expand()
        {
            if (Capacity == 0)
            {
                Array.Resize(ref _items, DefaultCapacity);
                return;
            }

            Array.Resize(ref _items, 2 * Count);
        }
    }
}