namespace ListTask
{
    internal class List<T> : IList<T>
    {
        private T[] _items = new T[10];
        private int _length;

        public int Count { get => _length; }

        public T this[int index]
        {
            get { return _items[index]; }
            set { _items[index] = value; }
        }

        public List()
        {
            _length = 0;
        }

        public List(int count)
        {
            _length = count;

            if (count <= _items.Length)
            {
                Array.Resize(ref _items, count + count);
            }
        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < _length; i++)
            {
                if (_items[i].Equals(value))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T value)
        {
            Array.Copy(_items, index, _items, _length + 1, _length - index + 1);

            _items[index] = value;

            Array.Copy(_items, _length + 1, _items, index + 1, _length - index + 1);

            _length += 1;
        }

        public void RemoveAt(int index)
        {
            Array.Copy(_items, index + 1, _items, index, _length - index + 1);
        }

        public void Add(T value)
        {
            _items[_length] = value;
            _length++;
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

        public void HandMadeClear()
        {
            for (int i = 0; i < _length; ++i)
            {
                _items[i] = default;
            }
        }


    }
}