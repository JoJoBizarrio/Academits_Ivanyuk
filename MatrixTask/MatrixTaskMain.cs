using System;

namespace MatrixTask
{
    class MatrixTuskMain
    {
        static void Main(string[] args)
        {
            // 1a. Matrix(n, m) – матрица нулей размера n*m
            Matrix matrix1 = new Matrix(3, 2);

            // 1b. Matrix(Matrix) – конструктор копирования
            Matrix matrix2 = new Matrix(matrix1);

            // 1c. Matrix(double[][]) – из двумерного массива(в C# double[,])
            double[,] array1 = { { 2, 3 }, { 4, 5 } };
            matrix2 = new Matrix(array1);

            // 1d. Matrix(Vector[]) – из массива векторов-строк
            Vector[] vectorsArray = new Vector[2];

            for (int i = 0; i < vectorsArray.GetLength(0); i++)
            {
                vectorsArray[i] = new Vector(3);
            }

            Matrix matrix3 = new Matrix(vectorsArray);

            // 2a. Получение размеров матрицы
            Console.WriteLine("Кол-во элементов: " + matrix3.GetElements());
            Console.WriteLine("Кол-во строк: " + matrix3.GetRows());
            Console.WriteLine("Кол-во колонок: " + matrix3.GetColumns());
            Console.WriteLine();

            // 2b. Получение и задание вектора-строки по индексу	
            Console.WriteLine("Геттер строки: " + matrix3.GetRow(0));
            Vector vector1 = new Vector(3);
            vector1.SetElement(0, 1);
            matrix3.SetRow(0, vector1);
            Console.WriteLine("Таже строка после сеттера: " + matrix3.GetRow(0));
            Console.WriteLine();

            // 2с. Получение вектора-столбца по индексу 
            Console.WriteLine("Геттер столбца:" + matrix3.GetColumn(0));
            Console.WriteLine();

            // 2d. Транспонирование
            matrix3.SetRow(1, vector1);
            Console.WriteLine("транспонирование до: " + matrix3);
            matrix3.Transpose();
            Console.WriteLine("транспонирование после: " + matrix3);
            Console.WriteLine();

            // 2e.Умножение на скаляр
            vector1.SetElement(1, 3.3);
            matrix3.SetRow(0, vector1);
            Console.WriteLine($"Матрица: {matrix3}\t");

            matrix3.MultiplyByScalar(3);
            Console.WriteLine("Умножениe на скаляр 3,3: " + matrix3);
            Console.WriteLine();

            // 2h. Умножение матрицы на вектор
            double[] array2 = { 2, 3 };
            Vector vector = new Vector(array2);

            double[,] array3 = { { 3, 2 }, { 6, 2 }, { 1, 10 } };
            Matrix matrix4 = new Matrix(array3);

            Console.WriteLine($"Вектор: {vector} и матрица: {matrix4}");
            Console.WriteLine("После перемножения вектор * матрица = " + matrix4.MultiplyByVector(vector));
            Console.WriteLine();

            // 2.i + 2j Add; Substract
            double[,] array4 = { { 2, 3, 0 }, { 4, 5, 9.5 } };
            matrix1 = new Matrix(array4);
            Console.WriteLine("до операции: " + matrix1);
            matrix1.Add(matrix1);
            Console.WriteLine("Добавили такую же матрицу: " + matrix1);
            matrix1.Subtract(matrix1);
            Console.WriteLine("Отняли такую же матрицу: " + matrix1);

            // Стат метод сложения
            Matrix matrix5 = Matrix.GetSum(matrix1, matrix1);
            Matrix matrix6 = Matrix.GetSum(matrix1, matrix5);
            Matrix matrix7 = Matrix.GetMultiplication(matrix5, matrix6);
            Console.Write(matrix7);
        }
    }
}