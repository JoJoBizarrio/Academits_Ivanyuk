namespace ListTask
{
    internal class List<T> : IList<T>
    {
        private T[] _items = new T[10];
        private int _length;
        private int _modCount = 0;

        public bool IsReadOnly { get; }  // что это и зачем?
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
            this.Expand();

            Array.Copy(_items, index, _items, _length + 1, _length - index + 1);

            _items[index] = value;

            Array.Copy(_items, _length + 1, _items, index + 1, _length - index + 1);

            _length++;
            _modCount++;
        }

        public void RemoveAt(int index)
        {
            Array.Copy(_items, index + 1, _items, index, _length - index + 1);
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

            _modCount++;
        }

        public void Clear()
        {
            Array.Clear(_items);
        }

        //public void HandMadeClear()
        //{
        //    for (int i = 0; i < _length; ++i)
        //    {
        //        _items[i] = default;
        //    }
        //}

        public bool Contains(T value)
        {
            this.Expand();
            return _items.Contains(value);
        }

        //public int HandMadeContains(T value)
        //{
        //    int count = 0;

        //    foreach (T e in _items)
        //    {
        //        if (e.Equals(value))
        //        {
        //            count++;
        //        }
        //    }

        //    return count;
        //}

        public bool Remove(T value)
        {
            this.Expand();

            try
            {
                this.RemoveAt(this.IndexOf(value));
                _length--;
                _modCount++;
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
                    throw new InvalidOperationException("list changed");
                }

                yield return _items[i];
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Expand()
        {
            if (_items.Length / 3 <= _length)
            {
                Array.Resize(ref _items, 4 * _length);
            }
        }
    }
}