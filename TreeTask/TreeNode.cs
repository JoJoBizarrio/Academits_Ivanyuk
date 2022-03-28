namespace TreeTask
{
    internal class TreeNode<T>
    {
        private T? _data;
        private TreeNode<T>? _left;
        private TreeNode<T>? _right;

        public T? Data { get => _data; set => _data = value; }

        public TreeNode<T>? Left { get => _left; set => _left = value; }

        public TreeNode<T>? Right { get => _right; set => _right = value; }


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
