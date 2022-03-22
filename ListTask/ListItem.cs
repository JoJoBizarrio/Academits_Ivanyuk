namespace ListTask
{
    internal class ListItem<T>
    {
        private T? _data;
        private ListItem<T>? _next;
        // private ListItem<T>? _randomListItem;

        public T? Data { get => _data; set => _data = value; }

        public ListItem<T>? Next { get => _next; set => _next = value; }

        // public ListItem<T>? RandomListItem { get => _randomListItem; }

        public ListItem(T? data, ListItem<T>? next)
        {
            _data = data;
            _next = next;
        }

        public ListItem(ref ListItem<T> head)
        {
            _next = head;
        }
        public ListItem(T data)
        {
            _data = data;
            _next = null;
        }

        public ListItem(ListItem<T> listItem)
        {
            _data = listItem.Data;
            _next = listItem.Next;
        }

        public ListItem<T>? GetNext()
        {
            return _next;
        }

        public void CopyTo(ListItem<T> destinationItem)
        {
            destinationItem.Data = _data;
            destinationItem.Next = _next;
        }

        public override string ToString()
        {
            return _data.ToString();
        }
    }
}