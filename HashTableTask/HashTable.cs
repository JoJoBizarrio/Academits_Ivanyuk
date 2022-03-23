using System.Collections;

namespace HashTableTask
{
    internal class HashTable<T> : ICollection<T>
    {
        private HashSet<T> _items { get; }

        public int Count => _items.Count;

        public bool IsReadOnly { get; }

        public HashTable(int count)
        {
            _items = new HashSet<T>(count);
        }

        public HashTable(params T[] items)
        {
            _items = new HashSet<T>(items.Length);

            for (int i = 0; i < items.Length; ++i)
            {
                if (!_items.Add(items[i]))
                {
                    --i;
                }
            }

            _items.TrimExcess();
        }

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        public bool Remove(T item)
        {
            return _items.Remove(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            T[] array = new T[Count];

            _items.CopyTo(array, 0);

            for (int i = 0; i < array.Length; ++i)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
