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
            _head = new ListItem<T>(default, null);
        }

        public SinglyLinkedList(T data)
        {
            _head = new ListItem<T>(data);
            Count++;
        }

        public SinglyLinkedList(params T[] dataset)
        {
            if (dataset.Length == 0)
            {
                new SinglyLinkedList<T>();
            }

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
            return _head.Data;
        }

        // вставка элемента в начало
        public void InsertFirst(T data)
        {
            ListItem<T> item = new(data, _head.Next);
            _head.Next = item;
            Count++;
        }

        // удаление первого элемента, пусть выдает значение элемента
        public T RemoveFirst()
        {
            T removedData = _head.Data;
            _head.Next = GetListItem(1);
            return removedData;
        }

        // получение/изменение значения по указанному индексу.
        public T GetData(int index)
        {
            if (index == 0)
            {
                return GetFirst();
            }

            return GetListItem(index).Data;
        }

        public void SetData(int index, T data)
        {
            if (index == 0)
            {
                _head.Data = data;
                return;
            }

            GetListItem(index).Data = data;
        }

        // вставка элемента по индексу
        public void Insert(int index, T data)
        {
            if (index == 0)
            {
                InsertFirst(data);
            }

            ListItem<T> insertedItem = new(data, null);
            ListItem<T> item = GetListItem(index);


            if (index < Count)
            {
                insertedItem.Next = item.Next;
            }

            item.Next = insertedItem;

            Count++;
        }

        // удаление элемента по индексу, пусть выдает значение элемента
        public T RemoveItem(int index)
        {
            this.CheckIndex(index);

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
                    return true;
                }

                previoslyItem = item;
            }

            return false;
        }


        // разворот списка за линейное время
        public void Revert()
        {
            Revert(0, Count - 1);
            // _head.Next = GetListItem(_count - 1);
        }

        private void Revert(int index1, int index2)
        {
            if (index2 - index1 <= 0)
            {
                return;
            }

            T temp1 = GetData(index1);
            T temp2 = GetData(index2);
            SetData(index2, temp1);
            SetData(index1, temp2);

            Revert(++index1, --index2);
        }

        // Копирование списка
        public SinglyLinkedList<T> Copy()
        {
            T[] array = new T[Count];

            for (int i = 0; i < Count; i++)
            {
                array[i] = GetData(i);
            }

            return new SinglyLinkedList<T>(array);
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException($"Index ({nameof(index)} = {index}) out of range: [0, {Count - 1}].");
            }
        }


        // вспомогательное: возвращает ячейку по индексу в виде item
        private ListItem<T> GetListItem(int index)
        {
            this.CheckIndex(index);

            ListItem<T> item = _head;

            for (int i = 0; i < index; i++)
            {
                item = item.Next;
            }

            return item;
        }

        // вспомогательное: возвращает ячейку по индексу в виде item
        private ListItem<T> GetListItem(T data)
        {
            

            return null;
        }

        // вспомогательное
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            int i = 1;

            for (ListItem<T> item = _head.Next; item != null; item = item.Next)
            {
                stringBuilder.Append($"{i}item = {item}; ");
                ++i;
            }

            return stringBuilder.ToString();
        }
    }
}