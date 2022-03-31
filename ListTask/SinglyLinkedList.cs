using System;
using System.Text;

namespace ListTask
{
    internal class SinglyLinkedList<T>
    {
        private ListItem<T> _head;

        public int Count { get; private set; }

        public SinglyLinkedList() { }

        public SinglyLinkedList(T data)
        {
            _head = new ListItem<T>(data);
            Count++;
        }

        public SinglyLinkedList(params T[] dataset)
        {
            _head = new ListItem<T>(dataset[0]);
            Count = dataset.Length;
            ListItem<T> item = _head;

            for (int i = 1; i < dataset.Length; i++)
            {
                item.Next = new(dataset[i]);
                item = item.Next;
            }
        }

        // получение значение первого элемента
        public T GetFirst()
        {
            if (Count == 0)
            {
                throw new ArgumentNullException("Empty list.");
            }

            return _head.Data;
        }

        // вставка элемента в начало
        public void InsertFirst(T data)
        {
            ListItem<T> oldHead = _head;
            _head = new ListItem<T>(data, oldHead);
            Count++;
        }

        // удаление первого элемента, пусть выдает значение элемента
        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new ArgumentNullException("Empty list.");
            }

            T removed = _head.Data;
            _head = _head.Next;
            Count--;

            return removed;
        }

        // получение/изменение значения по указанному индексу.
        public T GetData(int index)
        {
            if (index == 0)
            {
                return GetFirst();
            }

            CheckIndex(index);

            return GetListItem(index).Data;
        }

        public void SetData(int index, T data)
        {
            if (index == 0)
            {
                _head.Data = data;
                return;
            }

            CheckIndex(index);

            GetListItem(index).Data = data;
        }

        // вставка элемента по индексу
        public void Insert(int index, T data)
        {
            if (index == 0)
            {
                InsertFirst(data);
                return;
            }

            CheckIndex(index);

            ListItem<T> insertedItem = new(data, null);
            ListItem<T> item = GetListItem(index);

            insertedItem.Next = item.Next;
            item.Next = insertedItem;

            Count++;
        }

        // удаление элемента по индексу, пусть выдает значение элемента
        public T RemoveItem(int index)
        {
            if (index == 0)
            {
                return RemoveFirst();
            }

            CheckIndex(index);

            ListItem<T> listItem = GetListItem(index - 1);

            T removed = listItem.Next.Data;
            listItem.Next = listItem.Next.Next;

            Count--;
            return removed;
        }

        //удаление узла по значению, пусть выдает true, если элемент был удален
        public bool RemoveItem(T data)
        {
            if (_head.Data.Equals(data))
            {
                RemoveFirst();
                return true;
            }

            ListItem<T> previoslyItem = _head;

            for (ListItem<T> item = _head.Next; item != null; item = item.Next)
            {
                if (item.Data.Equals(data))
                {
                    previoslyItem.Next = item.Next;
                    Count--;
                    return true;
                }

                previoslyItem = item;
            }

            return false;
        }

        // разворот списка за линейное время
        public void Revert()
        {
            if (_head.Next == null)
            {
                return;
            }

            ListItem<T> item1 = _head;
            ListItem<T> item2 = _head.Next;

            if (_head.Next.Next == null)
            {
                item1.Next = null;
                item2.Next = item1;
                _head = item2;
            }
            else
            {
                ListItem<T> counter = _head.Next.Next;
                item1.Next = null;

                while (counter != null)
                {
                    item2.Next = item1;
                    item1 = item2;
                    item2 = counter;

                    counter = counter.Next;
                }

                item2.Next = item1;
                _head = item2;
            }
        }

        // Копирование списка
        public SinglyLinkedList<T> Copy()
        {
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

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException($"Index ({nameof(index)} = {index}) out of range: [0, {Count - 1}].");
            }
        }

        // вспомогательное: возвращает ячейку по индексу в виде ListItem<T>
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

        // вспомогательное
        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.Append('[');

            if (Count == 0)
            {
                return stringBuilder.Append(']').ToString();
            }

            for (ListItem<T> item = _head; item != null; item = item.Next)
            {
                if (item == null)
                {
                    stringBuilder.Append("null");
                    stringBuilder.Append(", ");
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