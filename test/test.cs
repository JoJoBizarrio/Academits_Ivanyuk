// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


double[] array1 = { 1, 2 };
double[,] array2 = { { 5, 2, 4 }, { 2, 3, 4 } };

Console.WriteLine(array1.GetLength(0));
Console.WriteLine(array1.Rank);
Console.WriteLine(array2.GetLength(0));
Console.WriteLine(array2.GetLength(1));
Console.WriteLine(array2.Rank);

double[,,] array3 = { { 1 }, { 2 } };