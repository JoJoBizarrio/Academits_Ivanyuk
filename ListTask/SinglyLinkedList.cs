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
                new SinglyLinkedList<T>();
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
            if (Count == 0)
            {
                throw new InvalidOperationException("Empty list.");
            }

            return _head.Data;
        }

        // Вставка элемента в начало
        public void InsertFirst(T data)
        {
            _head = new ListItem<T>(data, _head);
            Count++;
        }

        // Удаление первого элемента, пусть выдает значение элемента
        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Empty list.");
            }

            T removedValue = _head.Data;
            _head = _head.Next;
            Count--;

            return removedValue;
        }

        // Получение значения по указанному индексу.
        public T GetData(int index)
        {
            CheckIndex(index);

            return GetListItem(index).Data;
        }

        // Изменение значения по указанному индексу.
        public void SetData(int index, T data)
        {
            CheckIndex(index);

            GetListItem(index).Data = data;
        }

        // Вставка элемента по индексу
        public void Insert(int index, T data)
        {
            CheckIsEmptyList();

            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, $"Index is out of range: [0, {Count}].");
            }

            if (index == 0)
            {
                InsertFirst(data);
                return;
            }

            CheckIndex(index);

            ListItem<T> item = GetListItem(index - 1);
            ListItem<T> insertedItem = new(data, item.Next);

            item.Next = insertedItem;

            Count++;
        }

        // Удаление элемента по индексу, пусть выдает значение элемента
        public T RemoveAt(int index)
        {
            CheckIsEmptyList();

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
            CheckIsEmptyList();

            if ((_head.Data == null && data == null) || _head.Data.Equals(data))
            {
                RemoveFirst();
                return true;
            }

            for (ListItem<T> previousItem = _head, currentitem = _head.Next; currentitem != null; previousItem = currentitem, currentitem = currentitem.Next)
            {
                if ((data == null && currentitem.Data == null) || (currentitem.Data != null && currentitem.Data.Equals(data)))
                {
                    previousItem.Next = currentitem.Next;
                    Count--;
                    return true;
                }
            }

            return false;
        }

        // Разворот списка за линейное время
        public void Reverse()
        {
            CheckIsEmptyList();

            if (_head.Next == null)
            {
                return;
            }

            ListItem<T> previousItem = _head;
            ListItem<T> currentItem = _head.Next;
            ListItem<T> counter = _head.Next.Next;

            previousItem.Next = null;

            while (counter != null)
            {
                currentItem.Next = previousItem;
                previousItem = currentItem;
                currentItem = counter;

                counter = counter.Next;
            }

            currentItem.Next = previousItem;
            _head = currentItem;
        }


        // Копирование списка
        public SinglyLinkedList<T> Copy()
        {
            CheckIsEmptyList();

            SinglyLinkedList<T> listCopy = new(_head.Data);
            ListItem<T> itemCopy = listCopy._head;

            for (ListItem<T> item = _head.Next; item != null; item = item.Next)
            {
                itemCopy.Next = new ListItem<T>(item.Data);
                itemCopy = itemCopy.Next;
            }

            listCopy.Count = Count;

            return listCopy;
        }

        // Вспомогательное: возвращает ячейку по индексу в виде ListItem<T>
        private ListItem<T> GetListItem(int index)
        {
            CheckIndex(index);

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