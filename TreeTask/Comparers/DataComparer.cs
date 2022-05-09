namespace TreeTask.Comparers
{
    internal class DataComparer<T> : IComparer<T>
    {
        public int Compare(T data1, T data2)
        {
            if (data1 == null && data2 == null)
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

            IComparable<T> comparableData = (IComparable<T>) data1;

            return comparableData.CompareTo(data2);
        }
    }
}