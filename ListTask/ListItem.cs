namespace ListTask
{
    partial class ListItem<T> // как спрятать класс, сделать его узкодоступным, то есть чтобы класс ListItem мог видеть только SinglyLinkedList. Может ли в этом помочь partial ?
                              // спрятать класс я хочу исходя из того что ListItem является внутренней реализацией SinglyLinkedList. Правилен ли мой ход мысли? 
    {
        public T Data { get; set; }
        public ListItem<T> Next { get; set; }

        public ListItem(T data)
        {
            Data = data;
        }

        public ListItem(T data, ListItem<T> next)
        {
            Data = data;
            Next = next;
        }

        //public ListItem<T>? GetNext()
        //{
        //    return _next;
        //}
    }
}