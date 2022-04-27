using System;
using System.Text;

namespace ListTask
{
    internal class SinglyLinkedList<T>
    {
        private ListItem<T> _head;

        public int Count { get; private set; }

        public SinglyLinkedList()
        {
        }

        public SinglyLinkedList(T data)
        {
            _head = new ListItem<T>(data);
            Count++;
        }

        public SinglyLinkedList(params T[] array)
        {
            if (array.Length == 0)
            {
                return;
            }

            _head = new ListItem<T>(array[0]);
            Count = array.Length;
            ListItem<T> item = _head;

            for (int i = 1; i < array.Length; i++)
            {
                item.Next = new(array[i]);
                item = item.Next;
            }
        }

        // Получение значение первого элемента
        public T GetFirst()
        {
            CheckIsEmptyList();

            return _head.Data;
        }

        // Вставка элемента в начало
        public void InsertFirst(T data)
        {
            _head = new ListItem<T>(data, _head);
            Count++;
        }

        // Получение значения по указанному индексу
        public T GetData(int index)
        {
            CheckIndex(index);

            return GetListItem(index).Data;
        }

        // Изменение значения по указанному индексу
        public T SetData(int index, T data)
        {
            CheckIndex(index);

            ListItem<T> listItem = GetListItem(index);
            T oldData = listItem.Data;
            listItem.Data = data;

            return oldData;
        }

        // Вставка элемента по индексу
        public void Insert(int index, T data)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, $"Index is out of range: [0, {Count}].");
            }

            if (index == 0)
            {
                InsertFirst(data);
                return;
            }

            ListItem<T> previousItem = GetListItem(index - 1);

            previousItem.Next = new ListItem<T>(data, previousItem.Next);

            Count++;
        }

        // Удаление первого элемента, пусть выдает значение элемента
        public T RemoveFirst()
        {
            CheckIsEmptyList();

            T removedData = _head.Data;
            _head = _head.Next;
            Count--;

            return removedData;
        }

        // Удаление элемента по индексу, пусть выдает значение элемента
        public T RemoveAt(int index)
        {
            CheckIndex(index);

            if (index == 0)
            {
                return RemoveFirst();
            }

            ListItem<T> previousItem = GetListItem(index - 1);

            T removedData = previousItem.Next.Data;
            previousItem.Next = previousItem.Next.Next;

            Count--;
            return removedData;
        }

        // Удаление узла по значению, пусть выдает true, если элемент был удален
        public bool Remove(T data)
        {
            if (Equals(_head, null))
            {
                return false;
            }

            if (Equals(_head.Data, data))
            {
                RemoveFirst();
                return true;
            }

            for (ListItem<T> previousItem = _head, currentItem = _head.Next; currentItem != null; previousItem = currentItem, currentItem = currentItem.Next)
            {
                if (Equals(data, currentItem.Data))
                {
                    previousItem.Next = currentItem.Next;
                    Count--;
                    return true;
                }
            }

            return false;
        }

        // Разворот списка за линейное время
        public void Reverse()
        {
            if (Count == 0 || Count == 1)
            {
                return;
            }

            ListItem<T> previousItem = _head;
            ListItem<T> currentItem = _head.Next;
            ListItem<T> nextItem = _head.Next.Next;

            previousItem.Next = null;

            while (nextItem != null)
            {
                currentItem.Next = previousItem;
                previousItem = currentItem;
                currentItem = nextItem;

                nextItem = nextItem.Next;
            }

            currentItem.Next = previousItem;
            _head = currentItem;
        }


        // Копирование списка
        public SinglyLinkedList<T> Copy()
        {
            if (Count == 0)
            {
                return new SinglyLinkedList<T>();
            }

            SinglyLinkedList<T> listCopy = new(_head.Data);

            for (ListItem<T> item = _head.Next, itemCopy = listCopy._head; item != null; item = item.Next, itemCopy = itemCopy.Next)
            {
                itemCopy.Next = new ListItem<T>(item.Data);
            }

            listCopy.Count = Count;

            return listCopy;
        }

        // Вспомогательное: возвращает ячейку по индексу в виде ListItem<T>
        private ListItem<T> GetListItem(int index)
        {
            ListItem<T> item = _head;

            for (int i = 0; i < index; i++)
            {
                item = item.Next;
            }

            return item;
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException($"Index (= {index}) out of range: [0, {Count - 1}].");
            }
        }

        private void CheckIsEmptyList()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("List empty.");
            }
        }

        // Вспомогательное
        public override string ToString()
        {
            if (_head == null)
            {
                return "[]";
            }

            StringBuilder stringBuilder = new();
            stringBuilder.Append('[');

            for (ListItem<T> item = _head; item != null; item = item.Next)
            {
                if (item.Data == null)
                {
                    stringBuilder.Append("null, ");
                }
                else
                {
                    stringBuilder.Append(item.Data);
                    stringBuilder.Append(", ");
                }
            }

            return stringBuilder.Remove(stringBuilder.Length - 2, 2).Append(']').ToString();
        }
    }
}