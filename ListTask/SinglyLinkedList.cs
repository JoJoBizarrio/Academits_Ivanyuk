using System;
using System.Text;

namespace ListTask
{
    internal class SinglyLinkedList<T>
    {
        private ListItem<T> _head;
        private int _count;

        // получение значение первого элемента
        public ListItem<T> Head => _head.Next;

        // получение размера списка
        public int Count => _count;

        public SinglyLinkedList(T? data)
        {       
            ListItem<T> firstItem = new(data, null);
            _head = new ListItem<T>(ref firstItem);
            _count++;
        }

        public SinglyLinkedList(params T[] data)
        {
            if (data.Length == 0)
            {
                throw new ArgumentException($"Empty array {nameof(data.Length)} = {data.Length}.", nameof(data.Length));
            }

            ListItem<T> item = new(data[0], null);
            _head = new ListItem<T>(ref item);
            _count = data.Length;

            for (int i = 1; i < data.Length; i++)
            {
                item.Next = new(data[i], null);
                item = item.Next;
            }
        }

        // получение размера списка
        public int GetCapacity()
        {
            return _count;
        }

        // получение значение первого элемента:
        // в виде ячейки
        public ListItem<T> GetHeadListItem()
        {
            return _head.Next;
        }
        // в виде значения из ячейки
        public T GetHeadData()
        {
            return _head.Next.Data;
        }

        // вспомогательное: возвращает ячейку по индексу в виде item
        public ListItem<T> GetListItem(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException($"{nameof(index)} out of range: [0, {_count - 1}].");
            }

            ListItem<T> item = _head.Next;

            for (int i = 0; i <= index && item != null; i++)
            {
                if (i == index)
                {
                    break;
                }

                item = item.GetNext();
            }

            return item;
        }

        // получение/изменение значения по указанному индексу.
        public T GetData(int index)
        {
            return GetListItem(index).Data;
        }

        public void SetData(int index, T value)
        {
            GetListItem(index).Data = value;
        }

        // вставка элемента в начало
        public void InsertValueInBegin(T? data)
        {
            _count++;
            ListItem<T> item = new(data, _head.Next);
            _head.Next = item;
        }

        // вставка элемента по индексу
        public void InsertValue(int index, T data)
        {
            if (index == 0)
            {
                InsertValueInBegin(data);
            }

            ListItem<T> item = new(data, null);

            if (index < _count)
            {
                item.Next = GetListItem(index + 1);
            }

            GetListItem(index).Next = item;

            _count++;
        }

        // удаление узла по значению, пусть выдает true, если элемент был удален
        public bool RemoveItem(int index)
        {
            if (index < 0 || index >= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, $"Argument out of range: [0; {_count - 1}].");
            }

            GetListItem(index - 1).Next = GetListItem(index + 1);
            return true;
        }

        // удаление первого элемента, пусть выдает значение элемента
        public T RemoveHead()
        {
            T removedData = _head.Next.Data;
            _head.Next = GetListItem(1);
            return removedData;
        }

        // разворот списка за линейное время
        public void Revert()
        {
            Revert(0, _count - 1);
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

        // вспомогательное
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            int i = 1;

            for (ListItem<T> item = _head.Next; item != null; item = item.GetNext())
            {
                stringBuilder.Append($"{i}item = {item}; ");
                ++i;
            }

            return stringBuilder.ToString();
        }
    }
}