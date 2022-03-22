using System.Collections;

namespace ListTask
{
    internal class List<T> : IList<T>
    {
        public T[] _items;
        private int _length;
        private int _modCount = 0;

        public bool IsReadOnly { get; }  // что это и зачем?
        public int Count { get => _length; }
        public int Capacity { get => _items.Length; }

        public T this[int index]
        {
            get { return _items[index]; }
            set { _items[index] = value; }
        }

        public List()
        {
            _items = new T[10];
            _length = 0;
        }

        public List(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException($"Count mast be > 0 {nameof(count)} = {count}", nameof(count));
            }

            _items = new T[count];
            _length = 0;
        }

        public int IndexOf(T value)
        {
            return Array.IndexOf(_items, value);
        }

        public void Insert(int index, T value)
        {
            if (index <= 0 || index >= _length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, $"Argument out of range: [0, {_length - 1}]");
            }

            this.Expand();

            // вот такая реализация вставки не использутеся? то есть используем сам лист как буфер обмена но тогда capacity всегда должен быть в 2 раза больше длины:
            Array.Copy(_items, index, _items, _length + 2, _length - index + 1);

            _items[index] = value;

            Array.Copy(_items, _length + 2, _items, index + 1, _length - index + 1);

            _length++;
            _modCount++;
        }

        public void RemoveAt(int index)
        {
            if (index <= 0 || index >= _length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, $"Argument out of range: [0, {_length - 1}]");
            }

            Array.Copy(_items, index + 1, _items, index, _length - index + 1);
            _length--;
            _modCount++;
        }

        public void Add(T value)
        {
            this.Expand();

            _items[_length] = value;
            _length++;
            _modCount++;
        }

        public void Add(params T[] value)
        {
            for (int i = 0; i < value.Length; ++i)
            {
                Add(value[i]);
            }
        }

        public void Clear()
        {
            Array.Clear(_items);
        }

        public bool Contains(T value)
        {
            this.Expand();
            return _items.Contains(value);
        }

        public bool Remove(T value)
        {
            this.Expand();

            try
            {
                this.RemoveAt(this.IndexOf(value));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void CopyTo(T[] arrayList, int index)
        {
            _items.CopyTo(arrayList, index);
        }

        public IEnumerator<T> GetEnumerator()
        {
            _modCount = 0;
            int modCount = _modCount;

            for (int i = 0; i < _length; ++i)
            {
                if (modCount != _modCount)
                {
                    throw new InvalidOperationException($"List changed. Step:{i}");
                }

                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Expand()
        {
            if (_items.Length / 3 <= _length)
            {
                Array.Resize(ref _items, 6 * _length);
            }
        }

        public void TrimExcess()
        {
            if (_length / Capacity <= 0.9)
            {
                Array.Resize(ref _items, (int)(_length / 0.9));
            }
        }

        public override string ToString()
        {
            return $"{String.Join(", ", this)}.";
        }

        public string GetInformation()
        {
            return $"{String.Join(", ", this)}. \nCapacity = {Capacity} \nCount = {Count} \nEmptyItems = {Capacity - Count}\n";
        }
    }
}