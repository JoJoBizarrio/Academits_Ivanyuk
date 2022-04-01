namespace TreeTask
{
    internal class DataComparer<T> where T : IComparable<T>
    {
        T obj;

       public int Comparer(T other)
        {
            return obj.CompareTo(other);
        }

        public static int Comparer(T x, T y)
        {
            return x.CompareTo(y);
        }
    }
}