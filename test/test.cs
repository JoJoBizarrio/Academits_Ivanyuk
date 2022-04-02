// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


double[] array1 = { 1, 2 };
double[,] array2 = { { 5, 2, 4 }, { 2, 3, 4 } };

Console.WriteLine(array1.GetLength(0));
Console.WriteLine(array1.Rank);
Console.WriteLine(array2.GetLength(0));
Console.WriteLine(array2.GetLength(1));
Console.WriteLine(array2.Rank);



double[,] array4 = { { 2, 1, 4 }, { 11, 11, 2 }, { 3, 5, 2 }, {2, 4, 7 } };

Console.WriteLine();
Console.WriteLine(array4.Rank);
Console.WriteLine(array4.GetLength(0));
Console.WriteLine(array4.GetLength(1));

Console.WriteLine(3.2.GetHashCode());



//public bool RemoveAt(T data)
//{
//    CheckFirst();

//    if (data.Equals(_root.Data))
//    {
//        RemoveFirst();
//        return true;
//    }

//    TreeNode<T> treeNode = _root;
//    TreeNode<T> deletedNodeParent;
//    bool isLeftTurn = false;

//    while (data.CompareTo(treeNode.Data) != 0)
//    {
//        isLeftTurn = false;

//        if (data.CompareTo(treeNode.Data) > 0)
//        {
//            if (treeNode.Left == null)
//            {
//                return false;
//            }
//            else
//            {
//                isLeftTurn = true;
//                deletedNodeParent = treeNode;
//                treeNode = treeNode.Left;
//            }
//        }
//        else
//        {
//            if (treeNode.Right == null)
//            {
//                return false;
//            }
//            else
//            {
//                deletedNodeParent = treeNode;
//                treeNode = treeNode.Right;
//            }
//        }
//    }

//    TreeNode<T> deletedNode = treeNode;

//    // нет детей
//    if (deletedNode.Left == null && deletedNode.Right == null)
//    {
//        if (isLeftTurn)
//        {
//            deletedNodeParent.Left = null; // нету такого исхода где данная переменная в этом месте не будет присвоена
//            return true;
//        }

//        if (!isLeftTurn)
//        {
//            deletedNodeParent.Right = null;
//            return true;
//        }
//    }

//    // нет левого
//    if (treeNode.Left == null)
//    {
//        if (isLeftTurn)
//        {
//            deletedNodeParent.Left = treeNode.Right;
//            return true;
//        }

//        if (!isLeftTurn)
//        {
//            deletedNodeParent.Right = treeNode.Right;
//            return true;
//        }
//    }

//    // нет правого
//    if (treeNode.Right == null)
//    {
//        if (isLeftTurn)
//        {
//            deletedNodeParent.Left = treeNode.Left;
//            return true;
//        }

//        if (!isLeftTurn)
//        {
//            deletedNodeParent.Right = treeNode.Left;
//            return true;
//        }
//    }

//    // отсутсвие отсутствия (2 ребенка)
//    TreeNode<T> minRightBranch = deletedNode.Right;
//    TreeNode<T> minRightBranchParent = deletedNode;

//    if (minRightBranch.Left != null)
//    {
//        while (minRightBranch.Left != null)
//        {
//            minRightBranchParent = minRightBranch;
//            minRightBranch = minRightBranch.Left;
//        }

//        if (minRightBranch.Right == null) 
//        {
//            minRightBranchParent.Left = null; // занулили родителя левого правой ветки
//        }
//        else
//        {
//            minRightBranchParent.Left = minRightBranch.Right; // если есть соединили 
//        }

//        if (isLeftTurn) // смотрим куда идет поворот после родителя удаляемого нода
//        {
//            deletedNodeParent.Left = minRightBranch; // перенаправили ссылку родителя удаляемого на минамльного левого
//        }
//        else
//        {
//            deletedNodeParent.Right = minRightBranch;
//        }

//        minRightBranch.Left = deletedNode.Left; // минимальный левый принимает ссылки детей от удаляемого
//        minRightBranch.Right = deletedNode.Right;

//        deletedNode.Left = null; // зануляем удаляемый нод
//        deletedNode.Right = null;
//        deletedNode = null;
//        return true;
//    }

//    if (isLeftTurn) 
//    {
//        deletedNodeParent.Left = deletedNode.Right;
//    }
//    else
//    {
//        deletedNodeParent.Right = deletedNode.Right;
//    }

//    deletedNode.Right.Left = deletedNode.Left;

//    deletedNode.Left = null; // зануляем удаляемый нод
//    deletedNode.Right = null;
//    deletedNode = null;
//    return true;
//}
