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
            T[] temp = new T[_length - index];

            Array.Copy(_items, index, temp, 0, _length - index + 1);

            _items[index] = value;

            Array.Copy(temp, 0, _items, index + 1, _length - index + 1);

            _length += 1;
        }

        public void RemoveAt(int index)
        {
            int i = _length - index;
            int j = index;

            while (i > 0)
            {
                (_items[j]) = (_items[j+1]);

                ++j;
                --i;
            }

            _length -= 1;
        }


    }
}