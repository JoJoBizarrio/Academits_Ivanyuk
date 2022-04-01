namespace TreeTask
{
    internal class TreeNode<T> : DataComparer<T> where T : IComparable<T>
    {
        public T? Data { get; set; }

        public TreeNode<T>? Left { get; set; }

        public TreeNode<T>? Right { get; set; }

        public TreeNode() { }

        public TreeNode(T? data)
        {
            Data = data;
        }

        public int CompareTo(T x)
        {
            return Comparer(x);
        }

        public static int Comparer(T x, T y)
        {
            return DataComparer<T>.Comparer(x, y);
        }
        //public TreeNode<T> GetLeftChild()
        //{
        //    return _left;
        //}

        //public TreeNode<T> GetRightChild()
        //{
        //    return _right;
        //}
    }
}