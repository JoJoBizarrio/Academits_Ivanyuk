namespace TreeTask
{
    internal class TreeNode<T> 
    {
        public T? Data { get; set; }

        public TreeNode<T>? Left { get; set; }

        public TreeNode<T>? Right { get; set; }

        public TreeNode() { }

        public TreeNode(T? data)
        {
            Data = data;
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