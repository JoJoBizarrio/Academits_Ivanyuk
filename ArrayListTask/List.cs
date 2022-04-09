using System.Collections;
using System.Text;

namespace ListTask
{
    internal class List<T> : IList<T>
    {
        private const int DefaultCapacity = 10;

        private T[] _items;
        private int _modCount;

        public bool IsReadOnly => false;

        public int Count { get; private set; }

        public int Capacity
        {
            get => _items.Length;

            set
            {
                if (value < Count)
                {
                    throw new ArgumentException($"Capacity = {value} must be greater than count = {Count}.");
                }

                if (value == Count)
                {
                    return;
                }

                Array.Resize(ref _items, value);
            }
        }

        public T this[int index]
        {
            get
            {
                CheckIndex(index);

                return _items[index];
            }

            set
            {
                CheckIndex(index);

                _items[index] = value;
                _modCount++;
            }
        }

        public List()
        {
            _items = new T[DefaultCapacity];
        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException($"Capacity must be > 0 {nameof(capacity)} = {capacity}.", nameof(capacity));
            }

            _items = new T[capacity];
        }

        public List(params T[] items)
        {
            if (items.Length == 0)
            {
                throw new ArgumentException("Empty array.");
            }

            _items = new T[2 * items.Length];

            Array.Copy(items, _items, items.Length);

            Count = items.Length;
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(_items, item, 0, Count);
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, $"Index out of range: [0, {Count}].");
            }

            if (Capacity == Count)
            {
                Expand();
            }

            Array.Copy(_items, index, _items, index + 1, Count - index);

            _items[index] = item;

            Count++;
            _modCount++;
        }

        public void Add(T item)
        {
            Insert(Count, item);
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index);

            Array.Copy(_items, index + 1, _items, index, Count - index - 1);
            _items[^1] = default; // 1) это является занулением? я не понимаю как занулить ссылку вручную.
                                  // 2) вот если будет int[] то там будет ноль после дефолта, но ссылка будет все еще активна. Правильно понимаю?
                                  // ref _items[^1] = null; это тоже не работает. без ref аналогично. 

            Count--;
            _modCount++;
        }

        public void Clear()
        {
            if (Count == 0)
            {
                return;
            }

            Array.Clear(_items, 0, Count);
            Count = 0;
            _modCount++;
        }

        public bool Contains(T item) => IndexOf(item) >= 0;

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

        public void CopyTo(T[] array, int index)
        {
            if (index < 0 || index >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, $"Index out of range: [0, {Count - 1}].");
            }

            if (array == null)
            {
                throw new ArgumentNullException("Array is null.");
            }

            if (Count > array.Length - index)
            {
                throw new ArgumentException($"The number of elements in the source list ({nameof(_items)}) is greater than the available space " +
                                            $"from the position specified by index (= {index}) to the end of the destination {nameof(array)} ({nameof(array.Length)} = {array.Length}).");
            }

            Array.Copy(_items, 0, array, index, Count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            int initialModCount = _modCount;

            for (int i = 0; i < Count; ++i)
            {
                if (initialModCount != _modCount)
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
                Capacity = Count;
            }
        }

        public override string ToString()
        {
            if (Count == 0)
            {
                return "[]";
            }

            StringBuilder stringBuilder = new();

            stringBuilder.Append('[');

            foreach (T e in this)
            {
                stringBuilder.Append(e);
                stringBuilder.Append(", ");
            }

            stringBuilder.Replace(", ", "]", stringBuilder.Length - 2, 2);

            return stringBuilder.ToString();
        }

        public string GetInformation()
        {
            return $"{ToString()}; {Environment.NewLine}Capacity = {Capacity}; {Environment.NewLine}Count = {Count}; " +
                   $"{Environment.NewLine}EmptyItems = {Capacity - Count}.{Environment.NewLine}";
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, $"Index out of range: [0, {Count - 1}].");
            }
        }

        private void Expand()
        {
            if (Capacity == 0)
            {
                Capacity = DefaultCapacity;
                return;
            }

            Capacity = 2 * Count;
        }
    }
}