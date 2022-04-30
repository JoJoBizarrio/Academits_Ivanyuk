namespace TreeTask.Comparers
{
    internal class DataComparer<T> : IComparer<T>
    {
        public int Compare(T data1, T data2)
        {
            if (Equals(data1, data2))
            {
                return 0;
            }

            if (data1 == null)
            {
                return -1;
            }

            if (data2 == null)
            {
                return 1;
            }

            IComparable<T> comparableData = data1 as IComparable<T>;

            return comparableData.CompareTo(data2);
        }
    }
}